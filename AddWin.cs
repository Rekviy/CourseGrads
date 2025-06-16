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
using CourseGrads.Data;
using CourseGrads.Models;

namespace CourseGrads {
	public partial class AddWin : Form {
		public event Action<GraduateDTO>? GraduateCreated;
		private List<Group> _groups;

		public AddWin() {
			InitializeComponent();

			_groups = UniversityDBHelper.GetTable<Group>(new UniversityContext()).Where(gr => gr.GroupName != null).ToList();
			cboGroup.DataSource = _groups.Select(gr => gr.GroupName).ToList();
		}

		private void btnAddGraduate_Click(object sender, EventArgs e) {
			try {
				GraduateDTO newGrad = new GraduateDTO {
					DipNum = int.Parse(txtDiplomaNumber.Text),
					FullName = txtFullName.Text,
					Sex = cboSex.Text.FirstOrDefault(),
					Address = txtAddress.Text,
					GroupName = cboGroup.Text,
					SpecialityName = specTxt.Text,
					EnrollmentYear = dtpEnrollmentYear.Value,
					GraduationYear = dtpGraduationYear.Value,
					DiplomaQualification = txtQualification.Text,
					GraduationSubject = txtGraduationSubject.Text,
					SubjectNames = txtSubjects.Text,
					ProfessorNames = txtProfessors.Text,
					Grades = txtGrades.Text
				};
				GraduateCreated?.Invoke(newGrad);
				this.Close();
			}
			catch (Exception ex) {
				MessageBox.Show($"Ошибка добавления выпускника: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cboGroup_SelectedIndexChanged(object sender, EventArgs e) {
			var selectedGroup = _groups.FirstOrDefault(gr => gr.GroupName == cboGroup.SelectedItem?.ToString());
			specTxt.Text = selectedGroup?.Speciality?.SpecialityName ?? "";
		}
	}
}
