using CourseGrads.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseGrads.Models {

	public class Speciality : INotifyPropertyChanged {
		private int _specialityId;
		private string? _specialityName;
		public virtual ObservableCollectionListSource<Group> Groups { get; } = new();

		public Speciality() {
			Groups.CollectionChanged += (sender, e) => OnPropertyChanged();
		}

		[Key]
		public int SpecialityId {
			get => _specialityId;
			set { if (_specialityId != value) { _specialityId = value; OnPropertyChanged(); } }
		}

		public string? SpecialityName {
			get => _specialityName;
			set { if (_specialityName != value) { _specialityName = value; OnPropertyChanged(); } }
		}
		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class Group : INotifyPropertyChanged {
		private int _groupId;
		private string? _groupName;
		private int _specialityId;
		public virtual Speciality? Speciality { get; set; }

		public virtual ObservableCollectionListSource<Graduate> Graduates { get; } = new();

		[Key]
		public int GroupId {
			get => _groupId;
			set { if (_groupId != value) { _groupId = value; OnPropertyChanged(); } }
		}

		public string? GroupName {
			get => _groupName;
			set { if (_groupName != value) { _groupName = value; OnPropertyChanged(); } }
		}

		public int SpecialityId {
			get => _specialityId;
			set { if (_specialityId != value) { _specialityId = value; OnPropertyChanged(); } }
		}

		public Group() {
			Graduates.CollectionChanged += (sender, e) => OnPropertyChanged();
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class Graduate : INotifyPropertyChanged {
		private int _dipNum;
		private string? _fullName;
		private char _sex;
		private string? _address;
		private int? _groupId;

		public virtual Group? Group { get; set; }

		private DateTime _enrollmentYear;
		private DateTime _graduationYear;

		public virtual Thesis? Thesis { get; set; }

		public virtual ObservableCollectionListSource<SubjectGraduate> SubjectsGraduates { get; } = new();

		[Key]
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
			get => _groupId;
			set { if (_groupId != value) { _groupId = value; OnPropertyChanged(); } }
		}
		public DateTime EnrollmentYear {
			get => _enrollmentYear;
			set { if (_enrollmentYear != value) { _enrollmentYear = value; OnPropertyChanged(); } }
		}
		public DateTime GraduationYear {
			get => _graduationYear;
			set { if (_graduationYear != value) { _graduationYear = value; OnPropertyChanged(); } }
		}

		public Graduate() {
			SubjectsGraduates.CollectionChanged += (sender, e) => OnPropertyChanged();
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class Thesis : INotifyPropertyChanged {
		private int _dipNum;
		private string? _diplomaQualification { get; set; }
		private string? _graduationSubject { get; set; }
		public virtual Graduate? Graduate { get; set; } = null;

		[Key]
		public int DipNum {
			get => _dipNum;
			set { if (_dipNum != value) { _dipNum = value; OnPropertyChanged(); } }
		}
		public string? DiplomaQualification {
			get => _diplomaQualification;
			set { if (_diplomaQualification != value) { _diplomaQualification = value; OnPropertyChanged(); } }
		}
		public string? GraduationSubject {
			get => _graduationSubject;
			set { if (_graduationSubject != value) { _graduationSubject = value; OnPropertyChanged(); } }
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class Professor : INotifyPropertyChanged {
		private int _professorId;
		private string? _fullName;

		public virtual ObservableCollectionListSource<Subject> Subjects { get; } = new();

		[Key]
		public int ProfessorId {
			get => _professorId;
			set { if (_professorId != value) { _professorId = value; OnPropertyChanged(); } }
		}
		public string? FullName {
			get => _fullName;
			set { if (_fullName != value) { _fullName = value; OnPropertyChanged(); } }
		}

		public Professor() {
			Subjects.CollectionChanged += (sender, e) => OnPropertyChanged();
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class Subject : INotifyPropertyChanged {
		private int _subjectId;
		private string? _subjectName;
		private int _professorId;
		public virtual Professor? Professor { get; set; }

		public virtual ObservableCollectionListSource<SubjectGraduate>? SubjectsGraduates { get; } = new();

		[Key]
		public int SubjectId {
			get => _subjectId;
			set { if (_subjectId != value) { _subjectId = value; OnPropertyChanged(); } }
		}
		public string? SubjectName {
			get => _subjectName;
			set { if (_subjectName != value) { _subjectName = value; OnPropertyChanged(); } }
		}
		public int ProfessorId {
			get => _professorId;
			set { if (_professorId != value) { _professorId = value; OnPropertyChanged(); } }
		}

		public Subject() {
			SubjectsGraduates.CollectionChanged += (sender, e) => OnPropertyChanged();
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class SubjectGraduate : INotifyPropertyChanged {
		private int _dipNum;
		private int _subjectId;
		public byte _grade;

		public virtual Subject? Subject { get; set; } 
		public virtual Graduate? Graduate { get; set; } 

		public int DipNum {
			get => _dipNum;
			set { if (_dipNum != value) { _dipNum = value; OnPropertyChanged(); } }
		}

		public int SubjectId {
			get => _subjectId;
			set { if (_subjectId != value) { _subjectId = value; OnPropertyChanged(); } }
		}

		public byte Grade {
			get => _grade;
			set { if (_grade != value) { _grade = value; OnPropertyChanged(); } }
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
