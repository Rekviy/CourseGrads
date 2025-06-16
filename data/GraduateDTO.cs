using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseGrads.Data {

	public class GraduateDTO : INotifyPropertyChanged {
		private int _dipNum;
		private string? _fullName;
		private char _sex;
		private string? _address;

		private int? _groupId;
		private string? _groupName;

		private string? _specialityName;

		private DateTime _enrollmentYear;
		private DateTime _graduationYear;

		private string? _diplomaQualification;
		private string? _graduationSubject;

		private string? _subjectNames;
		private string? _professorNames;
		private string? _grades;
		public double AvgGrade { get; private set; }

		public int DipNum {
			get => _dipNum;
			set { if (_dipNum != value) { _dipNum = value; OnPropertyChanged(); } }
		}

		public string? FullName {
			get => _fullName;
			set { if (_fullName != value) { _fullName = value; OnPropertyChanged(); } }
		}

		public char Sex {
			get => _sex;
			set { if (_sex != value) { _sex = value; OnPropertyChanged(); } }
		}

		public string? Address {
			get => _address;
			set { if (_address != value) { _address = value; OnPropertyChanged(); } }
		}

		public int? GroupId {
			get =>_groupId;
			set { if (_groupId != value) { _groupId = value; OnPropertyChanged(); } }
		}

		public string? GroupName {
			get => _groupName;
			set { if (_groupName != value) { _groupName = value; OnPropertyChanged(); } }
		}

		public string? SpecialityName {
			get => _specialityName;
			set { if (_specialityName != value) { _specialityName = value; OnPropertyChanged(); } }
		}

		public DateTime EnrollmentYear {
			get => _enrollmentYear;
			set { if (_enrollmentYear != value) { _enrollmentYear = value; OnPropertyChanged(); } }
		}

		public DateTime GraduationYear {
			get => _graduationYear;
			set { if (_graduationYear != value) { _graduationYear = value; OnPropertyChanged(); } }
		}

		public string? DiplomaQualification {
			get => _diplomaQualification;
			set { if (_diplomaQualification != value) { _diplomaQualification = value; OnPropertyChanged(); } }
		}

		public string? GraduationSubject {
			get => _graduationSubject;
			set { if (_graduationSubject != value) { _graduationSubject = value; OnPropertyChanged(); } }
		}

		public string? SubjectNames {
			get => _subjectNames;
			set { if (_subjectNames != value) { _subjectNames = value; OnPropertyChanged(); } }
		}

		public string? ProfessorNames {
			get => _professorNames;
			set { if (_professorNames != value) { _professorNames = value; OnPropertyChanged(); } }
		}

		public string? Grades {
			get => _grades;
			set { if (_grades != value) { _grades = value; AvgGrade = CalculateAvgScore(); OnPropertyChanged(); } }
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private double CalculateAvgScore() {
			double returnVal = 0.0d;
			if (_grades != null) {
				var gradesArr = _grades.Split(';');
				try {
					foreach (var grade in gradesArr) {
						if (grade == "") continue;
						returnVal += byte.Parse(grade);
					}
					returnVal /= gradesArr.Length;
				}
				catch (Exception e) {
					MessageBox.Show("Ошибка при расчете среднего балла!\n" + e.Message, "Ошибка",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					returnVal = 0.0d;
				}
			}

			return returnVal;
		}
	}
}
