using System.Data;
using System;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CourseGrads.Data;
using CourseGrads.Models;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;


namespace CourseGrads {
	public partial class MainWindow : Form {

		private ChangeTracker<GraduateDTO> _tracker = new();
		const double RD_THRESHOLD = 4.7d;

		public MainWindow() {
			InitializeComponent();
		}
		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
			//SaveChanges();
		}
		private void MainWindow_Load(object sender, EventArgs e) {
			try {
				InitializeDatabase();
				LoadData();
			}
			catch (Exception ex) {
				MessageBox.Show("Не удалось подключиться к Базе Данных.\n"+ ex.ToString(), "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void InitializeDatabase() {
			using var context = new UniversityContext();
			
			if (context.Database.CanConnect())
				context.Database.Migrate();				
		}
		private void LoadData() {
			_tracker.Initialize(UniversityDBHelper.GetTable(new UniversityContext()), (entity) => { return new object[] { entity.DipNum };  });
			GradTable.DataSource = _tracker.List;
			FormatDataGridView();
		}
		private void FormatDataGridView() {
			GradTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			GradTable.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
			GradTable.RowHeadersVisible = false;
		}

		private void SaveChanges() {
			using var context = new UniversityContext();
			var transaction = context.Database.BeginTransaction();
			try {
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Graduates ON");
				UniversityDBHelper.AddEntry(_tracker.Added.Select(dto => UniversityDBHelper.MapDTOToGraduate(dto, context)).ToList(), context);
				UniversityDBHelper.UpdateTable(_tracker.Modified.Select(dto => UniversityDBHelper.MapDTOToGraduate(dto, context)).ToList(), context);
				UniversityDBHelper.DeleteEntry<Graduate>(_tracker.Deleted.Select(d => _tracker.KeyOf(d)).ToArray(), context);
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Graduates OFF");

				transaction.Commit();
				_tracker.ClearChanges();
				MessageBox.Show("Данные успешно сохранены", "Информация",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex) {
				transaction.Rollback();
				MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool DeleteRow(DataGridViewRow row) {
			var itemToDelete = (GraduateDTO)row.DataBoundItem;
			try {
				var result = MessageBox.Show(
				$"Удалить запись: {_tracker.KeyOf(itemToDelete)}?",
				"Подтверждение удаления",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

				if (result == DialogResult.Yes) {
					_tracker.HandleRowDeleting(itemToDelete);
					return true;
				}
			}
			catch (Exception ex) {
				MessageBox.Show($"Ошибка удаления выпускника: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return false;
		}
		private void GradTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
			if (!DeleteRow(e.Row)) {
				e.Cancel = true;
				return;
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e) {
			_tracker.Initialize(_tracker.Merge(UniversityDBHelper.GetTable(new UniversityContext())), _tracker.KeyOf);
			GradTable.DataSource =_tracker.List;
		}
		private void btnSave_Click(object sender, EventArgs e) {
			SaveChanges();
		}
		private void btnCancel_Click(object sender, EventArgs e) {
			_tracker.ClearChanges();
			LoadData();
		}

		private void Add_Click(object sender, EventArgs e) {
			using (var addWin = new AddWin()) {
				addWin.GraduateCreated += result => {
					_tracker.List.Add(result);
				};
				addWin.ShowDialog();
			}
		}

		private void btnDeleteGraduate_Click(object sender, EventArgs e) {
			if (GradTable.SelectedCells.Count > 0) {
				var row = GradTable.SelectedCells[0].OwningRow;
				if (row != null) {
					DeleteRow(row);
					GradTable.Rows.Remove(row);
				}
			}
			else
				MessageBox.Show("Выберите выпускника для удаления", "Предупреждение",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void btnRawView_Click(object sender, EventArgs e) {
			RawViewForm rawViewForm = new RawViewForm();
			rawViewForm.Show();
		}

		private void btnSearchGraduate_Click(object sender, EventArgs e) {
			try {
				string textinput = "";
				using (var txt = new TxtForm()) {
					txt.InputComplete += result => {
						textinput = result;
					};
					txt.ShowDialog();
				}

				if (int.TryParse(textinput, out int diplomaNumber)) {
					var results = _tracker.Merge(UniversityDBHelper.GetTable(new UniversityContext())).FirstOrDefault(g => g.DipNum == diplomaNumber);
					if (results != default)
						GradTable.DataSource = new List<GraduateDTO> { results };
					else
						MessageBox.Show("Выпускник с указанным номером диплома не найден", "Информация",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
					MessageBox.Show("Введите корректный номер диплома", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception ex) {
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSearchRedDiploma_Click(object sender, EventArgs e) {
			try {
				GradTable.DataSource = _tracker.Merge(UniversityDBHelper.GetTable(new UniversityContext())).Where(g => g.AvgGrade > RD_THRESHOLD).ToList();
			}
			catch (Exception ex) {
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSearchBySpeciality_Click(object sender, EventArgs e) {
			try {
				string textinput = "";
				using (var txt = new TxtForm()) {
					txt.InputComplete += result => {
						textinput = result;
					};
					txt.ShowDialog();
				}

				string speciality = textinput;

				if (!string.IsNullOrEmpty(speciality))
					GradTable.DataSource = _tracker.Merge(UniversityDBHelper.GetTable(new UniversityContext())).Where(g => g.SpecialityName == speciality).ToList();
				else
					MessageBox.Show("Введите название специальности", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}
			catch (Exception ex) {
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnGraduatesSpecCount_Click(object sender, EventArgs e) {
			try {
				GradTable.DataSource =
					_tracker.Merge(UniversityDBHelper.GetTable(new UniversityContext()))
					.GroupBy(g => g.SpecialityName)
					.Select(gr => new {
						Speciality = gr.Key,
						Count = gr.Count()
					}).ToList();
			}
			catch (Exception ex) {
				MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


	}
}
