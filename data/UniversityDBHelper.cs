using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CourseGrads.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections;

namespace CourseGrads.Data {
	public static class UniversityDBHelper {
		public static List<T> GetTable<T>(DbContext context) where T : class {
			var query = context.Set<T>().AsNoTracking().ToList();
			return query;
		}
		public static List<T> GetByKey<T>(object[] keys, DbContext context) where T : class {
			List<T> result = new();
			//var entities = context.Set<T>()
			//	.Where(e => keys.Contains(keySelector(e)))
			//	.ToList();
			foreach (var key in keys) {
				var query = context.Set<T>().Find(key);
				if (query != null) result.Add(query);
			}
			return result;
		}

		public static void AddEntry<T>(IEnumerable<T> entities, DbContext context) where T : class {
			context.Set<T>().AddRange(entities);
			context.SaveChanges();
		}

		public static void UpdateTable<T>(IEnumerable<T> entities, DbContext context) where T : class {
			foreach (var entity in entities) {
				context.Entry(entity).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public static List<T> DeleteEntry<T>(object[] keys, DbContext context) where T : class {
			var result = GetByKey<T>(keys, context);
			foreach (var item in result) {
				context.Set<T>().Remove(item);
			}
			context.SaveChanges();
			return result;
		}

		public static void DeleteEntry(Type entityType, object[][] keys, DbContext context) {
			foreach (var key in keys) {
				var entity = context.Find(entityType, key);
				if (entity != null)
					context.Remove(entity);
			}
			context.SaveChanges();
		}

		public static List<GraduateDTO> GetTable(UniversityContext context) {
			var query = context.Graduates
				.Include(g => g.Group)
					.ThenInclude(gr => gr!.Speciality)
				.Include(g => g.SubjectsGraduates)
					.ThenInclude(sg => sg.Subject)
						.ThenInclude(s => s.Professor)
				.Include(g => g.Thesis)

				.Select(g => MapGraduateToDTO(g)).AsNoTracking().ToList();

			return query;
		}

		public static GraduateDTO MapGraduateToDTO(Graduate entity) {
			if (entity != null) {
				entity.Group ??= new Group();
				entity.Group.Speciality ??= new Speciality();
				entity.Thesis??=new Thesis();

				return new GraduateDTO {
					DipNum = entity.DipNum,
					FullName = entity.FullName,
					Sex = entity.Sex,
					Address = entity.Address,
					GroupId = entity.GroupId,
					GroupName = entity.Group!.GroupName,
					SpecialityName = entity.Group.Speciality.SpecialityName,
					EnrollmentYear = entity.EnrollmentYear,
					GraduationYear = entity.GraduationYear,
					DiplomaQualification = entity.Thesis.DiplomaQualification,
					GraduationSubject = entity.Thesis.GraduationSubject,

					SubjectNames = string.Join(";",
						entity.SubjectsGraduates
						 .Select(sg => sg.Subject.SubjectName)),

					ProfessorNames = string.Join(";",
						entity.SubjectsGraduates
						 .Select(sg => sg.Subject.Professor.FullName)),

					Grades = string.Join(";",
						entity.SubjectsGraduates
						 .Select(sg => sg.Grade.ToString()))
				};
			}

			throw new ArgumentNullException(nameof(entity));
		}
		public static Graduate MapDTOToGraduate(GraduateDTO entity, UniversityContext context) {
			if (entity != null) {
				var entityGroup = context.Find<Group>(entity.GroupId);
				if (entityGroup == null) {
					entityGroup = context.Groups.Include(g => g.Speciality)
												.FirstOrDefault(g => g.GroupName == entity.GroupName);
					if (entityGroup == null) {
						var entitySpeciality = context.Specialities.FirstOrDefault(s => s.SpecialityName == entity.SpecialityName);

						if (entitySpeciality == null) {
							entitySpeciality = new Speciality { SpecialityName = entity.SpecialityName };
							context.Specialities.Add(entitySpeciality);
						}

						entityGroup = new Group {
							GroupName = entity.GroupName,
							Speciality = entitySpeciality
						};
						context.Groups.Add(entityGroup);
					}
				}

				var subjectNames = entity.SubjectNames?.Split(';') ?? [];
				var professorNames = entity.ProfessorNames?.Split(';') ?? [];
				var grades = entity.Grades?.Split(';').Select((str) => {
					if (str != "") return byte.Parse(str);
					return (byte)0;
				}).ToArray() ?? [];

				var subjectGraduateList = new List<SubjectGraduate>();
				int sgLength = int.Max(int.Max(subjectNames.Length, professorNames.Length), grades.Length);
				for (int i = 0; i < sgLength; i++) {
					string? subjName = i < subjectNames.Length ? subjectNames[i] : null;
					string? profName = i < professorNames.Length ? professorNames[i] : null;
					byte grade = i < grades.Length ? grades[i] : (byte)0;

					var prof = context.Professors.FirstOrDefault(p => p.FullName == profName);
					if (prof == null) {
						prof = new Professor { FullName = profName };
						context.Professors.Add(prof);
					}

					var subj = context.Subjects.FirstOrDefault(s => s.SubjectName == subjName);
					if (subj == null || subj.ProfessorId != prof.ProfessorId) {
						subj = new Subject {
							SubjectName = subjName,
							Professor = prof
						};
						context.Subjects.Add(subj);
					}

					subjectGraduateList.Add(new SubjectGraduate {
						Subject = subj,
						Grade = grade
					});
				}

				var graduate = context.Graduates
				.Include(g => g.Thesis)
				.Include(g => g.SubjectsGraduates)
				.FirstOrDefault(g => g.DipNum == entity.DipNum)
				?? new Graduate { DipNum = entity.DipNum };

				graduate.FullName = entity.FullName;
				graduate.Sex = entity.Sex;
				graduate.Address = entity.Address;
				graduate.EnrollmentYear = entity.EnrollmentYear;
				graduate.GraduationYear = entity.GraduationYear;
				graduate.Group = entityGroup;
				graduate.Thesis ??= new Thesis();
				graduate.Thesis.DiplomaQualification = entity.DiplomaQualification;
				graduate.Thesis.GraduationSubject = entity.GraduationSubject;

				context.SubjectsGraduates.RemoveRange(graduate.SubjectsGraduates);
				graduate.SubjectsGraduates.Clear();
				subjectGraduateList.ForEach(graduate.SubjectsGraduates.Add);
				return graduate;
			}

			throw new ArgumentNullException(nameof(entity));
		}
	}
}

