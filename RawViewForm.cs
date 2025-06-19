using CourseGrads.Data;
using CourseGrads.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace CourseGrads {
	public partial class RawViewForm : Form {
		Dictionary<string, dynamic> _trackers = new();

		public RawViewForm() {
			InitializeComponent();
		}
		private void RawViewForm_FormClosing(object sender, FormClosingEventArgs e) {
			foreach (TabPage page in RawViewTabControl.TabPages) {
				var grid = page.Controls.OfType<DataGridView>().First();
				if (grid != null)
					SaveChanges(page.Text, grid);
			}
			MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private void RawViewForm_Load(object sender, EventArgs e) {
			InitializeGrids();
			InitializeDatabase();

			foreach (TabPage page in RawViewTabControl.TabPages) {
				var grid = page.Controls.OfType<DataGridView>().First();
				if (grid != null) InitData(page.Text, grid);
			}
		}

		private void FormatDataGrid(DataGridView grid) {
			grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
			grid.RowHeadersVisible = false;
		}
		private void InitializeGrids() {
			GraduatesGrid.Tag = typeof(Graduate);
			GroupsGrid.Tag = typeof(Group);
			SpecialitiesGrid.Tag = typeof(Speciality);
			ThesesGrid.Tag = typeof(Thesis);
			ProfessorsGrid.Tag = typeof(Professor);
			SubjectsGrid.Tag = typeof(Subject);
			SubjectsGraduatesGrid.Tag = typeof(SubjectGraduate);
		}
		private void InitializeDatabase() {
			using var context = new UniversityContext();
			context.Database.Migrate();
		}

		private void InitTab<T>(string key, DataGridView grid, Func<T, object[]> keySelector) where T : class, INotifyPropertyChanged {
			var tracker = new ChangeTracker<T>();

			tracker.Initialize(UniversityDBHelper.GetTable<T>(new UniversityContext()), keySelector);
			_trackers[key] = tracker;
			grid.DataSource = tracker.List;
		}
		private void InitData(string key, DataGridView grid) {
			Type modelType = (Type)grid.Tag!;

			switch (modelType.Name) {
				case nameof(Graduate):
					InitTab<Graduate>(key, grid, g => new object[] { g.DipNum });
					break;
				case nameof(Group):
					InitTab<Group>(key, grid, g => new object[] { g.GroupId });
					break;
				case nameof(Speciality):
					InitTab<Speciality>(key, grid, s => new object[] { s.SpecialityId });
					break;
				case nameof(Thesis):
					InitTab<Thesis>(key, grid, t => new object[] { t.DipNum });
					break;
				case nameof(Professor):
					InitTab<Professor>(key, grid, p => new object[] { p.ProfessorId });
					break;
				case nameof(Subject):
					InitTab<Subject>(key, grid, s => new object[] { s.SubjectId });
					break;
				case nameof(SubjectGraduate):
					InitTab<SubjectGraduate>(key, grid, sg => new object[] { sg.DipNum, sg.SubjectId });
					break;
				default:
					throw new InvalidOperationException($"Неизвестный тип {modelType.Name}");
			}
		}

		private dynamic LoadData(DataGridView grid) {
			Type modelType = (Type)grid.Tag!;

			switch (modelType.Name) {
				case nameof(Graduate):
					return UniversityDBHelper.GetTable<Graduate>(new UniversityContext());
				case nameof(Group):
					return UniversityDBHelper.GetTable<Group>(new UniversityContext());
				case nameof(Speciality):
					return UniversityDBHelper.GetTable<Speciality>(new UniversityContext());
				case nameof(Thesis):
					return UniversityDBHelper.GetTable<Thesis>(new UniversityContext());
				case nameof(Professor):
					return UniversityDBHelper.GetTable<Professor>(new UniversityContext());
				case nameof(Subject):
					return UniversityDBHelper.GetTable<Subject>(new UniversityContext());
				case nameof(SubjectGraduate):
					return UniversityDBHelper.GetTable<SubjectGraduate>(new UniversityContext());

				default:
					throw new InvalidOperationException($"Неизвестный тип {modelType.Name}");
			}
		}

		private bool SaveChanges(string key, DataGridView grid) {
			dynamic tracker = _trackers[key];
			using var context = new UniversityContext();
			var transaction = context.Database.BeginTransaction();

			try {
				IEntityType entityType = context.Model.FindEntityType(tracker.GetEntityType());
				if (entityType.FindPrimaryKey()!.Properties.Any(p => p.ValueGenerated == ValueGenerated.OnAdd)) {

					var schema = entityType.GetSchema() ?? "dbo";
					var tableName = entityType.GetTableName();
					var fullName = $"[{schema}].[{tableName}]";

					context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {fullName} ON");
					UniversityDBHelper.AddEntry(tracker.Added, context);
					UniversityDBHelper.UpdateTable(tracker.Modified, context);
					context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {fullName} OFF");
				}
				else {
					UniversityDBHelper.AddEntry(tracker.Added, context);
					UniversityDBHelper.UpdateTable(tracker.Modified, context);
				}

				var deletedKeys = new List<object[]>();
				foreach (var item in tracker.Deleted)
					deletedKeys.Add(tracker.KeyOf(item));

				UniversityDBHelper.DeleteEntry((Type)grid.Tag!, deletedKeys.ToArray(), context);


				transaction.Commit();
				tracker.ClearChanges();

				return true;
			}
			catch (Exception ex) {
				transaction.Rollback();
				MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool DeleteRow(string key, DataGridViewRow row) {
			var itemToDelete = _trackers[key].ConvertTo(row.DataBoundItem);
			try {
				var result = MessageBox.Show(
				$"Удалить запись: {_trackers[key].KeyOf(itemToDelete)}?",
				"Подтверждение удаления",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

				if (result == DialogResult.Yes) {
					_trackers[key].HandleRowDeleting(itemToDelete);
					return true;
				}
			}

			catch (Exception ex) {
				MessageBox.Show($"Ошибка удаления ряда: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return false;
		}

		private void Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
			var tab = RawViewTabControl.SelectedTab;
			if (tab != null) {

				if (!DeleteRow(tab.Text, e.Row)) {
					e.Cancel = true;
					return;
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			var tab = RawViewTabControl.SelectedTab;
			if (tab != null) {
				var grid = tab.Controls.OfType<DataGridView>().First();
				if (grid != null)
					if (SaveChanges(tab.Text, grid))
						MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e) {
			var tab = RawViewTabControl.SelectedTab;
			if (tab != null) {
				var grid = tab.Controls.OfType<DataGridView>().FirstOrDefault();
				if (grid != null) {
					var tracker = _trackers[tab.Text];
					tracker.Initialize(tracker.Merge(LoadData(grid)), tracker.KeyOf);
					_trackers[tab.Text] = tracker;
					grid.DataSource = tracker.List;
				}
			}
		}

		private void btnDeleteGraduate_Click(object sender, EventArgs e) {
			var tab = RawViewTabControl.SelectedTab;
			if (tab != null) {
				var grid = tab.Controls.OfType<DataGridView>().FirstOrDefault();

				if (grid != null && grid.SelectedCells.Count > 0) {
					var row = grid.SelectedCells[0].OwningRow;
					if (row != null) {
						DeleteRow(tab.Text, row);
						grid.Rows.Remove(row);
					}
				}
				else
					MessageBox.Show("Выберите ряд для удаления", "Предупреждение",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			var tab = RawViewTabControl.SelectedTab;
			if (tab != null) {
				var tracker = _trackers[tab.Text];
				tracker.ClearChanges();
				var grid = tab.Controls.OfType<DataGridView>().First();
				if (grid != null) {
					tracker.Initialize(LoadData(grid), tracker.KeyOf);
					_trackers[tab.Text] = tracker;
				}
			}
		}
	}
}
