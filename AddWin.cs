using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace CourseGrads {
    public partial class AddWin : Form {
        public AddWin() {
            InitializeComponent();
            DataTable result = new DataTable();
            MainWindow.retrieveData(result, "SELECT GroupName FROM Groups");
            foreach (DataRow item in result.Rows)
                cboGroup.Items.Add(item["GroupName"]);
        }

        private void btnAddGraduate_Click(object sender, EventArgs e) {
            try {
                DataRow newRow = MainWindow.dataSet.Tables[0].NewRow();

                newRow[0] = int.Parse(txtDiplomaNumber.Text);
                newRow[1] = txtFullName.Text;
                newRow[2] = cboSex.Text;
                newRow[3] = txtAddress.Text;
                newRow[4] = cboGroup.Text;
                newRow[5] = specTxt.Text;
                newRow[6] = dtpEnrollmentYear.Value;
                newRow[7] = dtpGraduationYear.Value;
                newRow[8] = txtQualification.Text;
                newRow[9] = txtGraduationSubject.Text;
                newRow[10] = txtSubjects.Text;
                newRow[11] = txtProfessors.Text;
                newRow[12] = txtGrades.Text;
                MainWindow.dataSet.Tables[0].Rows.Add(newRow);
                for (int i = 0; i < MainWindow.dataSet.Tables[0].Columns.Count; i++)
                    if (newRow[i] as string == "")
                        newRow[i] = null;
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка добавления выпускника: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e) {
            DataTable result = new DataTable();
            MainWindow.retrieveData(result, "SELECT Speciality FROM Groups WHERE GroupName = @GroupName", "GroupName", cboGroup.Text);
            specTxt.Text = result.Rows[0][0].ToString();

        }
    }
}
