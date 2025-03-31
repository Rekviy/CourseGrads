using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;
using System.ComponentModel;

namespace CourseGrads {
    public partial class MainWindow : Form {

        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

        static internal SqlConnection connection;

        [DefaultValue(null)]
        static internal DataSet dataSet { get; set; }

        [DefaultValue(null)]
        static internal string txtinput { get; set; }
        private string loadQuery = @"
                            SELECT 
                                g.DipNum, 
                                g.FullName, 
                                g.Sex, 
                                g.[Address], 
                                gr.GroupName, 
                                gr.Speciality, 
                                g.[Enrollment year], 
                                g.[Graduation year], 
                                g.[Diploma qualification], 
                                g.[Graduation subject],
                                STUFF((
                                    SELECT ';' + s.SubjectName
                                    FROM SubjectsGraduatesTable sg 
                                    JOIN Subjects s ON sg.SubjectID = s.SubjectID
                                    WHERE sg.DipNum = g.DipNum
                                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS SubjectNames,
                                STUFF((
                                    SELECT ';' + s.ProfessorFullName
                                    FROM SubjectsGraduatesTable sg 
                                    JOIN Subjects s ON sg.SubjectID = s.SubjectID
                                    WHERE sg.DipNum = g.DipNum
                                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS ProfessorNames,
                                STUFF((
                                    SELECT ';' + CAST(s.Grade AS VARCHAR)
                                    FROM SubjectsGraduatesTable sg 
                                    JOIN Subjects s ON sg.SubjectID = s.SubjectID
                                    WHERE sg.DipNum = g.DipNum
                                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') AS Grades,
                                (SELECT AVG(CAST(s.Grade AS FLOAT))
                                    FROM SubjectsGraduatesTable sg 
                                    JOIN Subjects s ON sg.SubjectID = s.SubjectID
                                    WHERE sg.DipNum = g.DipNum) AS AvgGrade
                            FROM 
                                GraduatesTable g
                            LEFT JOIN 
                                Groups gr ON g.GroupName = gr.GroupName ";
        private string loadQueryEnd = @" GROUP BY
                                g.DipNum, g.FullName, g.Sex, g.[Address], gr.GroupName, gr.Speciality,
                                g.[Enrollment year], g.[Graduation year], g.[Diploma qualification], g.[Graduation subject]";

        public MainWindow() {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
        }

        private void InitializeDatabase() {
            try {
                sqlBuilder.DataSource = @"localhost";
                sqlBuilder.IntegratedSecurity = true;
                sqlBuilder.TrustServerCertificate = true;
                string DataDirectory = @"D:\SQL\DATA";
                sqlBuilder.AttachDBFilename = DataDirectory + @"\graduates.mdf";
                connection = new SqlConnection(sqlBuilder.ConnectionString);
                dataSet = new DataSet();

            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка инициализации базы данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData() {
            try {
                dataSet.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter(loadQuery + loadQueryEnd + "ORDER BY g.DipNum", connection);
                adapter.Fill(dataSet, "Data");

                GradTable.DataSource = dataSet.Tables["Data"];
                FormatDataGridView();
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatDataGridView() {
            GradTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            GradTable.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            GradTable.RowHeadersVisible = false;
        }

        static public void retrieveData(in DataTable result, string command, string? field = null, object? data = null) {
            SqlCommand cmd = new SqlCommand(command, connection);
            if (field != null && data != null)
                cmd.Parameters.AddWithValue("@" + field, data);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);
        }

        private void SaveChanges() {
            try {
                if (dataSet.Tables["Data"].GetChanges() != null) {
                    foreach (DataRow row in dataSet.Tables["Data"].GetChanges().Rows) {
                        switch (row.RowState) {
                            case DataRowState.Added:
                                UpdateGraduate(row, @"
                                    INSERT INTO GraduatesTable 
                                    (DipNum, FullName, Sex, [Address], GroupName, [Enrollment year], [Graduation year], 
                                    [Diploma qualification], [Graduation subject])
                                    VALUES 
                                    (@DipNum, @FullName, @Sex, @Address, @GroupName, @EnrollmentYear, @GraduationYear, 
                                    @Qualification, @GraduationSubject)");
                                row.AcceptChanges();
                                break;

                            case DataRowState.Deleted:
                                DeleteGraduate(row);
                                break;

                            case DataRowState.Modified:
                                UpdateGraduate(row, @"
                                    UPDATE GraduatesTable
                                    SET 
                                    FullName = @FullName,
                                    Sex = @Sex,
                                    [Address] = @Address,
                                    GroupName = @GroupName,
                                    [Enrollment year] = @EnrollmentYear,
                                    [Graduation year] = @GraduationYear,
                                    [Diploma qualification] = @Qualification,
                                    [Graduation subject] = @GraduationSubject
                                    WHERE DipNum = @DipNum");
                                row.AcceptChanges();
                                break;
                        }
                    }

                    MessageBox.Show("Данные успешно сохранены", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else {
                    MessageBox.Show("Нет изменений для сохранения", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateGraduate(DataRow row, string command) {
            SqlTransaction transaction = null;

            try {
                DataTable result = new DataTable();
                retrieveData(result, "SELECT GroupName FROM Groups");

                connection.Open();
                transaction = connection.BeginTransaction();
                bool isExist = false;
                foreach (DataRow item in result.Rows) {
                    if (item[0] == row["GroupName"])
                        isExist = true;
                    break;
                }
                if (!isExist) {
                    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO Groups (GroupName, Speciality) VALUES (@GroupName, @Speciality)",
                                              connection, transaction)) {
                        cmd.Parameters.AddWithValue("@GroupName", row["GroupName"]);
                        cmd.Parameters.AddWithValue("@Speciality", row["Speciality"]);

                        cmd.ExecuteNonQuery();
                    }
                }


                using (SqlCommand cmd = new SqlCommand(command, connection, transaction)) {
                    cmd.Parameters.AddWithValue("@DipNum", row["DipNum"]);
                    cmd.Parameters.AddWithValue("@FullName", row["FullName"]);
                    cmd.Parameters.AddWithValue("@Sex", row["Sex"]);
                    cmd.Parameters.AddWithValue("@Address", row["Address"]);
                    cmd.Parameters.AddWithValue("@GroupName", row["GroupName"]);
                    cmd.Parameters.AddWithValue("@EnrollmentYear", row["Enrollment year"]);
                    cmd.Parameters.AddWithValue("@GraduationYear", row["Graduation year"]);
                    cmd.Parameters.AddWithValue("@Qualification", row["Diploma qualification"]);
                    cmd.Parameters.AddWithValue("@GraduationSubject", row["Graduation subject"]);

                    cmd.ExecuteNonQuery();
                }

                if (row["SubjectNames"] != DBNull.Value && row["ProfessorNames"] != DBNull.Value && row["Grades"] != DBNull.Value) {
                    string[] subjectNames = row["SubjectNames"].ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] professorNames = row["ProfessorNames"].ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] grades = row["Grades"].ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                    if (subjectNames.Length == professorNames.Length && professorNames.Length == grades.Length) {
                        string deleteSubjectsQuery = "DELETE FROM SubjectsGraduatesTable WHERE DipNum = @DipNum";
                        using (SqlCommand cmd = new SqlCommand(deleteSubjectsQuery, connection, transaction)) {
                            cmd.Parameters.AddWithValue("@DipNum", row["DipNum"]);
                            cmd.ExecuteNonQuery();
                        }
                        object[] subjectId = GetOrCreateSubject(subjectNames, professorNames, grades, transaction);

                        string addSubjectGraduateQuery = @"
                                INSERT INTO SubjectsGraduatesTable (DipNum, SubjectID)
                                VALUES ((select DipNum from GraduatesTable where DipNum = @DipNum), 
                                (select SubjectID from Subjects where SubjectID = @SubjectID))";
                        int count = subjectId.Length;
                        while (count > 0) {
                            using (SqlCommand cmd = new SqlCommand(addSubjectGraduateQuery, connection, transaction)) {
                                cmd.Parameters.AddWithValue("@DipNum", row["DipNum"]);
                                cmd.Parameters.AddWithValue("@SubjectID", subjectId[count - 1]);
                                cmd.ExecuteNonQuery();
                            }
                            count--;
                        }
                    }
                }
                transaction.Commit();
            }
            catch (Exception ex) {
                if (transaction != null)
                    transaction.Rollback();
                throw new Exception($"Ошибка обновления данных: {ex.Message}");
            }
            finally {
                connection.Close();
            }
        }
        private object[] GetOrCreateSubject(string[] subjectName, string[] professorName, string[] grade, SqlTransaction transaction) {
            string Query = @"
                SELECT SubjectID FROM Subjects 
                WHERE SubjectName = @SubjectName AND ProfessorFullName = @ProfessorName AND Grade = @Grade";
            int count = grade.Length;
            int rescount = 0;
            object[] result = new object[grade.Length];
            while (count > 0) {
                using (SqlCommand cmd = new SqlCommand(Query, connection, transaction)) {
                    cmd.Parameters.AddWithValue("@SubjectName", subjectName[count - 1]);
                    cmd.Parameters.AddWithValue("@ProfessorName", professorName[count - 1]);
                    cmd.Parameters.AddWithValue("@Grade", Convert.ToInt32(grade[count - 1]));
                    result[rescount] = cmd.ExecuteScalar();
                    if (result[count - 1] != null)
                        rescount++;
                    count--;
                }
            }

            if (rescount == grade.Length)
                return result;
            else {
                int subjectId;
                Query = @"SELECT SubjectID 
                              FROM Subjects 
                              ORDER BY SubjectID DESC";
                using (SqlCommand insertCmd = new SqlCommand(Query, connection, transaction)) {
                    subjectId = Convert.ToInt32(insertCmd.ExecuteScalar());
                }
                Query = @"
                        INSERT INTO Subjects (SubjectID, SubjectName, ProfessorFullName, Grade)
                        VALUES (@SubjectID, @SubjectName, @ProfessorName, @Grade);";
                count = grade.Length;
                while (count > 0) {
                    if (result[count - 1] == null) {
                        using (SqlCommand insertCmd = new SqlCommand(Query, connection, transaction)) {
                            insertCmd.Parameters.AddWithValue("@SubjectID", ++subjectId);
                            insertCmd.Parameters.AddWithValue("@SubjectName", subjectName[count - 1]);
                            insertCmd.Parameters.AddWithValue("@ProfessorName", professorName[count - 1]);
                            insertCmd.Parameters.AddWithValue("@Grade", Convert.ToInt32(grade[count - 1]));
                            insertCmd.ExecuteNonQuery();
                            result[count - 1] = subjectId;
                        }  
                    }
                    count--;
                }
            }

            return result;
        }
        private void DeleteGraduate(DataRow row) {
            try {
                int diplomaNumber = Convert.ToInt32(row["DipNum"]);
                string deleteQuery = "DELETE FROM SubjectsGraduatesTable WHERE DipNum = @DipNum";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection)) {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@DipNum", diplomaNumber);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                deleteQuery = "DELETE FROM GraduatesTable WHERE DipNum = @DipNum";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection)) {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@DipNum", diplomaNumber);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка удаления выпускника: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();

            }
        }


        private void btnSearchRedDiploma_Click(object sender, EventArgs e) {
            try {
                DataTable result = new DataTable();
                retrieveData(result, loadQuery + @"WHERE
                                        g.DipNum IN (
                                        SELECT g2.DipNum
                                        FROM GraduatesTable g2
                                        JOIN SubjectsGraduatesTable sg2 ON g2.DipNum = sg2.DipNum
                                        JOIN Subjects s2 ON sg2.SubjectID = s2.SubjectID
                                        GROUP BY g2.DipNum
                                        HAVING AVG(CAST(s2.Grade AS FLOAT)) > 4.7)"
                                        + loadQueryEnd);
                GradTable.DataSource = result;
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchGraduateByDiploma(int diplomaNumber) {
            try {
                DataTable result = new DataTable();
                retrieveData(result, loadQuery + "WHERE g.DipNum = @DipNum" + loadQueryEnd, "DipNum", diplomaNumber);
                if (result.Rows.Count > 0)
                    GradTable.DataSource = result;

                else
                    MessageBox.Show("Выпускник с указанным номером диплома не найден", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchGraduate_Click(object sender, EventArgs e) {
            try {
                using (txtForm txt = new txtForm())
                    txt.ShowDialog();

                if (int.TryParse(txtinput, out int diplomaNumber))
                    SearchGraduateByDiploma(diplomaNumber);
                else
                    MessageBox.Show("Введите корректный номер диплома", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchBySpeciality_Click(object sender, EventArgs e) {
            try {
                using (txtForm txt = new txtForm())
                    txt.ShowDialog();

                string speciality = txtinput;

                if (!string.IsNullOrEmpty(speciality)) {
                    DataTable result = new DataTable();
                    retrieveData(result, loadQuery + "WHERE gr.Speciality = @Speciality " + loadQueryEnd, "Speciality", speciality);

                    GradTable.DataSource = result;
                }
                else
                    MessageBox.Show("Введите название специальности", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGraduatesCount_Click(object sender, EventArgs e) {
            try {
                DataTable result = new DataTable();
                retrieveData(result, @"SELECT 
                                            gr.Speciality, 
                                            COUNT(DISTINCT g.DipNum) AS GraduatesCount
                                        FROM 
                                            Groups gr
                                        LEFT JOIN 
                                            GraduatesTable g ON gr.GroupName = g.GroupName
                                        GROUP BY 
                                            gr.Speciality");
                GradTable.DataSource = result;
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void Add_Click(object sender, EventArgs e) {
            AddWin addWin = new AddWin();
            addWin.ShowDialog();
            SaveChanges();
            LoadData();
        }

        private void btnDeleteGraduate_Click(object sender, EventArgs e) {
            if (GradTable.SelectedCells.Count > 0) {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите удалить выбранного выпускника?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    DeleteGraduate(dataSet.Tables[0].Rows[GradTable.SelectedCells[0].RowIndex]);
                    MessageBox.Show("Выпускник успешно удален", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                }
            }
            else
                MessageBox.Show("Выберите выпускника для удаления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveChanges();
        }

        private void btnRawView_Click(object sender, EventArgs e) {
            RawViewForm rawViewForm = new RawViewForm();
            rawViewForm.Show();
        }
    }
}
