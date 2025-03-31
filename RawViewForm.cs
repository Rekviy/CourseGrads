using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseGrads {
    public partial class RawViewForm : Form {
        private DataSet dataSet;
        SqlDataAdapter graduatesAdapter;
        SqlDataAdapter groupsAdapter;
        SqlDataAdapter subjectsAdapter;
        SqlDataAdapter subjectsGraduatesAdapter;

        public RawViewForm() {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
        }
        private void InitializeDatabase() {
            try {
                graduatesAdapter = new SqlDataAdapter("SELECT * FROM GraduatesTable", MainWindow.connection);
                groupsAdapter = new SqlDataAdapter("SELECT * FROM Groups", MainWindow.connection);
                subjectsAdapter = new SqlDataAdapter("SELECT * FROM Subjects", MainWindow.connection);
                subjectsGraduatesAdapter = new SqlDataAdapter("SELECT * FROM SubjectsGraduatesTable", MainWindow.connection);

                SqlCommandBuilder graduatesBuilder = new SqlCommandBuilder(graduatesAdapter);
                SqlCommandBuilder groupsBuilder = new SqlCommandBuilder(groupsAdapter);
                SqlCommandBuilder subjectsBuilder = new SqlCommandBuilder(subjectsAdapter);
                SqlCommandBuilder subjectsGraduatesBuilder = new SqlCommandBuilder(subjectsGraduatesAdapter);

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

                groupsAdapter.Fill(dataSet, "Groups");
                graduatesAdapter.Fill(dataSet, "GraduatesTable");
                subjectsAdapter.Fill(dataSet, "Subjects");
                subjectsGraduatesAdapter.Fill(dataSet, "SubjectsGraduatesTable");

                DataRelation graduateToGroup = new DataRelation("GraduateToGroup",
                    dataSet.Tables["Groups"].Columns["GroupName"],
                    dataSet.Tables["GraduatesTable"].Columns["GroupName"]);

                DataRelation graduateToSubjects = new DataRelation("GraduateToSubjects",
                    dataSet.Tables["GraduatesTable"].Columns["DipNum"],
                    dataSet.Tables["SubjectsGraduatesTable"].Columns["DipNum"]);

                DataRelation subjectToGraduates = new DataRelation("SubjectToGraduates",
                    dataSet.Tables["Subjects"].Columns["SubjectID"],
                    dataSet.Tables["SubjectsGraduatesTable"].Columns["SubjectID"]);

                if (!dataSet.Relations.Contains("GraduateToGroup"))
                    dataSet.Relations.Add(graduateToGroup);
                if (!dataSet.Relations.Contains("GraduateToSubjects"))
                    dataSet.Relations.Add(graduateToSubjects);
                if (!dataSet.Relations.Contains("SubjectToGraduates"))
                    dataSet.Relations.Add(subjectToGraduates);
                GradTable.DataSource = dataSet.Tables["GraduatesTable"];
                Groups.DataSource = dataSet.Tables["Groups"];
                Subjects.DataSource = dataSet.Tables["Subjects"];
                SubjectsGraduates.DataSource = dataSet.Tables["SubjectsGraduatesTable"];
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatDataGridView(DataGridView dgw) {
            dgw.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgw.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgw.RowHeadersVisible = false;
            dgw.AllowUserToAddRows = false;
        }
        private void SaveData() {
            try {
                graduatesAdapter.Update(dataSet, "GraduatesTable");
                groupsAdapter.Update(dataSet, "Groups");
                subjectsAdapter.Update(dataSet, "Subjects");
                subjectsGraduatesAdapter.Update(dataSet, "SubjectsGraduatesTable");
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete(DataRow row) {
            try {
                string primkey;
                string deleteQuery;
                foreach (DataRelation item in row.Table.ChildRelations) {
                    for (int i = item.ChildTable.Columns.Count - 1, j = row.Table.Columns.Count - 1; i > 0 && j > 0; i--) {
                        if (item.ChildTable.Columns[i].ToString() == row.Table.Columns[j].ToString()) {
                            primkey = item.ChildTable.Columns[i].ToString();
                            deleteQuery = "UPDATE " + item.ChildTable.ToString() + " SET " + primkey + " = NULL WHERE " + primkey + " = @" + primkey;
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, MainWindow.connection)) {
                                MainWindow.connection.Open();
                                cmd.Parameters.AddWithValue("@" + primkey, row[j]);
                                cmd.ExecuteNonQuery();
                            }
                            j--;
                        }
                    }


                }

                primkey = row.Table.Columns[0].ToString();
                deleteQuery = "DELETE FROM " + row.Table.ToString() + " WHERE " + primkey + " = @" + primkey;
                using (SqlCommand cmd = new SqlCommand(deleteQuery, MainWindow.connection)) {
                    MainWindow.connection.Open();
                    cmd.Parameters.AddWithValue("@" + primkey, row[0]);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка удаления ряда: {ex.Message}", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                MainWindow.connection.Close();
            }
            
        }
        private void btnSave_Click(object sender, EventArgs e) {
            SaveData();
            MessageBox.Show("Данные успешно сохранены", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void RawViewForm_Load(object sender, EventArgs e) {
            FormatDataGridView(GradTable);
            FormatDataGridView(Groups);
            FormatDataGridView(Subjects);
            FormatDataGridView(SubjectsGraduates);
        }

        private void btnDeleteGraduate_Click(object sender, EventArgs e) {
            if (GradTable.SelectedCells.Count > 0) {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите удалить выбранный ряд?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    Delete(dataSet.Tables[0].Rows[GradTable.SelectedCells[0].RowIndex]);

                    MessageBox.Show("ряд успешно удален", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                }
            }
            else
                MessageBox.Show("Выберите ряд для удаления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
