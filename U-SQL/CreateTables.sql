	create DATABASE university;

	create table Specialities(
	SpecialityId int primary key,
	SpecialityName nvarchar(50)
	)

	create table Groups(
	GroupId int primary key,
	GroupName nvarchar(15),
	SpecialityId int foreign key references Specialities(specialityId)
	)

	create table Graduates(
	DipNum int primary key,
	FullName nvarchar(80),
	Sex nchar(1),
	[Address] nvarchar(100),
	GroupId int foreign key references Groups(groupId),
	[Enrollment year] smalldatetime,
	[Graduation year] smalldatetime,
	)
	create table Theses(
	DipNum int primary key references Graduates(DipNum),
	[Diploma qualification] nvarchar(30),
	[Graduation subject] nvarchar(30)
	)
	
	create table Professors(
	ProfessorId int primary key,
	FullName nvarchar(80)
	)
	create table Subjects(
	SubjectId int primary key,
	SubjectName nvarchar(30),
	ProfessorId int foreign key references Professors(ProfessorId)
	)

	create table SubjectsGraduates(
	DipNum int foreign key references Graduates(DipNum),
	SubjectId int foreign key references Subjects(SubjectID),
	Grade tinyint,

	primary key (DipNum, SubjectID)
	)