using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseGrads.Models;
using Microsoft.EntityFrameworkCore.Metadata;


namespace CourseGrads.Data {


	public class UniversityContext : DbContext {
		public DbSet<Graduate> Graduates { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Speciality> Specialities { get; set; }
		public DbSet<Thesis> Theses { get; set; }
		public DbSet<Professor> Professors { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<SubjectGraduate> SubjectsGraduates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Speciality>()
				.HasMany(s => s.Groups)
				.WithOne(g => g.Speciality)
				.HasForeignKey(g => g.SpecialityId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Group>()
				.HasMany(g => g.Graduates)
				.WithOne(gr => gr.Group)
				.HasForeignKey(gr => gr.GroupId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Graduate>(b=> {
				b.HasOne(g => g.Thesis)
				.WithOne(t => t.Graduate)
				.HasForeignKey<Thesis>(t => t.DipNum)
				.OnDelete(DeleteBehavior.Cascade);

				b.HasMany(g => g.SubjectsGraduates)
				.WithOne(sg => sg.Graduate)
				.HasForeignKey(sg => sg.DipNum)
				.OnDelete(DeleteBehavior.Cascade);
			});				

			modelBuilder.Entity<Thesis>(b =>
			{
				b.HasKey(t => t.DipNum);
				b.Property(t => t.DipNum)
				 .ValueGeneratedNever();

				b.HasOne(t => t.Graduate)
				 .WithOne(g => g.Thesis)
				 .HasForeignKey<Thesis>(t => t.DipNum);
			});

			modelBuilder.Entity<Professor>()
				.HasMany(p => p.Subjects)
				.WithOne(s => s.Professor)
				.HasForeignKey(s => s.ProfessorId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subject>()
			   .HasMany(s => s.SubjectsGraduates)
			   .WithOne(sg => sg.Subject)
			   .HasForeignKey(sg => sg.SubjectId)
			   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<SubjectGraduate>(b => {
				b.HasKey(sg => new { sg.DipNum, sg.SubjectId });

				b.Property(sg => sg.DipNum)
					.ValueGeneratedNever();

				b.Property(sg => sg.SubjectId)
					.ValueGeneratedNever();
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer("Server=.;Database=university;Trusted_Connection=True;TrustServerCertificate=True;");
		}
	}
}
