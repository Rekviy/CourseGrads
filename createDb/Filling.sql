insert into Groups values ('abcd', 'Advance')
insert into Groups values ('SOS', 'Hiring')
insert into Groups values ('1234', 'TEST')

insert into GraduatesTable values (1,'Токарев Василий Иванович','М','ул. Уличная г. Городской','abcd','06.07.1912','06.06.2000','WebDev','Vibe-voding')
insert into GraduatesTable values (2,'Васильев Григорий Романович','М','ул. Взрывная г. Разрущенск','abcd','04.30.2079','05.06.2079','NVIDIA','A.I.A.I.A.I.A.I.A.I.A.I.A.I.')
insert into GraduatesTable values (3,'Присед Анна Егоровна','Ж','ул. Существенная г. Которого-Нет','SOS','12.08.2007','06.06.2012','H.R.','LinkedIn')

insert into Subjects values(1, 'Something','I already forgot hes name',0)
insert into Subjects values(2, 'Something Sequel','I already forgot hes name 2',2)
insert into Subjects values(3, 'Математика','Профессоров',5)

insert into SubjectsGraduatesTable values(1, 2)
insert into SubjectsGraduatesTable values(1, 3)
insert into SubjectsGraduatesTable values(2, 1)
insert into SubjectsGraduatesTable values(3, 1)
insert into SubjectsGraduatesTable values(3, 2)
insert into SubjectsGraduatesTable values(3, 3)
