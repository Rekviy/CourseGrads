	create DATABASE graduates;


	create table Groups(
	GroupName nvarchar(15) primary key,
	Speciality nvarchar(30)
	)

create table GraduatesTable(
	DipNum int primary key,
	FullName nvarchar(80),
	Sex nchar(1),
	[Address] nvarchar(100),
	GroupName nvarchar(15) foreign key references Groups(GroupName),
	[Enrollment year] smalldatetime,
	[Graduation year] smalldatetime,
	[Diploma qualification] nvarchar(30),
	[Graduation subject] nvarchar(30)
	)

	create table Subjects(
	SubjectID int primary key,
	SubjectName nvarchar(30),
	ProfessorFullName nvarchar(80),
	Grade tinyint
	)

	create table SubjectsGraduatesTable(
	DipNum int foreign key references GraduatesTable(DipNum),
	SubjectID int foreign key references Subjects(SubjectID)
	)