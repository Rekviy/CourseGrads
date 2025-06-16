namespace CourseGrads {
    partial class RawViewForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			GraduatesGrid = new DataGridView();
			GroupsGrid = new DataGridView();
			SubjectsGraduatesGrid = new DataGridView();
			SubjectsGrid = new DataGridView();
			btnSave = new Button();
			btnRefresh = new Button();
			btnDelete = new Button();
			RawViewTabControl = new TabControl();
			GradTab = new TabPage();
			GroupsTab = new TabPage();
			SpecialitiesTab = new TabPage();
			SpecialitiesGrid = new DataGridView();
			ThesesTab = new TabPage();
			ThesesGrid = new DataGridView();
			ProfessorsTab = new TabPage();
			ProfessorsGrid = new DataGridView();
			SubjectsTab = new TabPage();
			SubjectsGraduatesTab = new TabPage();
			btnCancel = new Button();
			((System.ComponentModel.ISupportInitialize)GraduatesGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize)GroupsGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize)SubjectsGraduatesGrid).BeginInit();
			((System.ComponentModel.ISupportInitialize)SubjectsGrid).BeginInit();
			RawViewTabControl.SuspendLayout();
			GradTab.SuspendLayout();
			GroupsTab.SuspendLayout();
			SpecialitiesTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)SpecialitiesGrid).BeginInit();
			ThesesTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ThesesGrid).BeginInit();
			ProfessorsTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ProfessorsGrid).BeginInit();
			SubjectsTab.SuspendLayout();
			SubjectsGraduatesTab.SuspendLayout();
			SuspendLayout();
			// 
			// GraduatesGrid
			// 
			GraduatesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			GraduatesGrid.Location = new Point(6, 6);
			GraduatesGrid.Name = "GraduatesGrid";
			GraduatesGrid.Size = new Size(1030, 537);
			GraduatesGrid.TabIndex = 1;
			GraduatesGrid.Tag = "";
			// 
			// GroupsGrid
			// 
			GroupsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			GroupsGrid.Location = new Point(6, 6);
			GroupsGrid.Name = "GroupsGrid";
			GroupsGrid.Size = new Size(1030, 537);
			GroupsGrid.TabIndex = 4;
			GroupsGrid.Tag = "";
			// 
			// SubjectsGraduatesGrid
			// 
			SubjectsGraduatesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			SubjectsGraduatesGrid.Location = new Point(6, 6);
			SubjectsGraduatesGrid.Name = "SubjectsGraduatesGrid";
			SubjectsGraduatesGrid.Size = new Size(1030, 537);
			SubjectsGraduatesGrid.TabIndex = 5;
			SubjectsGraduatesGrid.Tag = "";
			// 
			// SubjectsGrid
			// 
			SubjectsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			SubjectsGrid.Location = new Point(6, 6);
			SubjectsGrid.Name = "SubjectsGrid";
			SubjectsGrid.Size = new Size(1030, 537);
			SubjectsGrid.TabIndex = 6;
			SubjectsGrid.Tag = "";
			// 
			// btnSave
			// 
			btnSave.Location = new Point(1056, 79);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 7;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnRefresh
			// 
			btnRefresh.Cursor = Cursors.Hand;
			btnRefresh.FlatStyle = FlatStyle.System;
			btnRefresh.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnRefresh.Location = new Point(1056, 23);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(42, 44);
			btnRefresh.TabIndex = 8;
			btnRefresh.Text = "⟲";
			btnRefresh.TextAlign = ContentAlignment.BottomCenter;
			btnRefresh.UseVisualStyleBackColor = true;
			btnRefresh.Click += btnRefresh_Click;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(1056, 123);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(75, 23);
			btnDelete.TabIndex = 9;
			btnDelete.Text = "Удалить";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDeleteGraduate_Click;
			// 
			// RawViewTabControl
			// 
			RawViewTabControl.Controls.Add(GradTab);
			RawViewTabControl.Controls.Add(GroupsTab);
			RawViewTabControl.Controls.Add(SpecialitiesTab);
			RawViewTabControl.Controls.Add(ThesesTab);
			RawViewTabControl.Controls.Add(ProfessorsTab);
			RawViewTabControl.Controls.Add(SubjectsTab);
			RawViewTabControl.Controls.Add(SubjectsGraduatesTab);
			RawViewTabControl.Location = new Point(0, -1);
			RawViewTabControl.Name = "RawViewTabControl";
			RawViewTabControl.SelectedIndex = 0;
			RawViewTabControl.Size = new Size(1050, 577);
			RawViewTabControl.TabIndex = 10;
			RawViewTabControl.Tag = "";
			// 
			// GradTab
			// 
			GradTab.Controls.Add(GraduatesGrid);
			GradTab.Location = new Point(4, 24);
			GradTab.Name = "GradTab";
			GradTab.Padding = new Padding(3);
			GradTab.Size = new Size(1042, 549);
			GradTab.TabIndex = 0;
			GradTab.Text = "Graduates";
			GradTab.UseVisualStyleBackColor = true;
			// 
			// GroupsTab
			// 
			GroupsTab.Controls.Add(GroupsGrid);
			GroupsTab.Location = new Point(4, 24);
			GroupsTab.Name = "GroupsTab";
			GroupsTab.Padding = new Padding(3);
			GroupsTab.Size = new Size(1042, 549);
			GroupsTab.TabIndex = 1;
			GroupsTab.Text = "Groups";
			GroupsTab.UseVisualStyleBackColor = true;
			// 
			// SpecialitiesTab
			// 
			SpecialitiesTab.Controls.Add(SpecialitiesGrid);
			SpecialitiesTab.Location = new Point(4, 24);
			SpecialitiesTab.Name = "SpecialitiesTab";
			SpecialitiesTab.Padding = new Padding(3);
			SpecialitiesTab.Size = new Size(1042, 549);
			SpecialitiesTab.TabIndex = 2;
			SpecialitiesTab.Text = "Specialities";
			SpecialitiesTab.UseVisualStyleBackColor = true;
			// 
			// SpecialitiesGrid
			// 
			SpecialitiesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			SpecialitiesGrid.Location = new Point(6, 6);
			SpecialitiesGrid.Name = "SpecialitiesGrid";
			SpecialitiesGrid.Size = new Size(1030, 537);
			SpecialitiesGrid.TabIndex = 0;
			SpecialitiesGrid.Tag = "";
			// 
			// ThesesTab
			// 
			ThesesTab.Controls.Add(ThesesGrid);
			ThesesTab.Location = new Point(4, 24);
			ThesesTab.Name = "ThesesTab";
			ThesesTab.Padding = new Padding(3);
			ThesesTab.Size = new Size(1042, 549);
			ThesesTab.TabIndex = 3;
			ThesesTab.Text = "Theses";
			ThesesTab.UseVisualStyleBackColor = true;
			// 
			// ThesesGrid
			// 
			ThesesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			ThesesGrid.Location = new Point(6, 6);
			ThesesGrid.Name = "ThesesGrid";
			ThesesGrid.Size = new Size(1030, 537);
			ThesesGrid.TabIndex = 0;
			ThesesGrid.Tag = "";
			// 
			// ProfessorsTab
			// 
			ProfessorsTab.Controls.Add(ProfessorsGrid);
			ProfessorsTab.Location = new Point(4, 24);
			ProfessorsTab.Name = "ProfessorsTab";
			ProfessorsTab.Padding = new Padding(3);
			ProfessorsTab.Size = new Size(1042, 549);
			ProfessorsTab.TabIndex = 4;
			ProfessorsTab.Text = "Professors";
			ProfessorsTab.UseVisualStyleBackColor = true;
			// 
			// ProfessorsGrid
			// 
			ProfessorsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			ProfessorsGrid.Location = new Point(6, 6);
			ProfessorsGrid.Name = "ProfessorsGrid";
			ProfessorsGrid.Size = new Size(1030, 537);
			ProfessorsGrid.TabIndex = 0;
			ProfessorsGrid.Tag = "";
			// 
			// SubjectsTab
			// 
			SubjectsTab.Controls.Add(SubjectsGrid);
			SubjectsTab.Location = new Point(4, 24);
			SubjectsTab.Name = "SubjectsTab";
			SubjectsTab.Padding = new Padding(3);
			SubjectsTab.Size = new Size(1042, 549);
			SubjectsTab.TabIndex = 5;
			SubjectsTab.Text = "Subjects";
			SubjectsTab.UseVisualStyleBackColor = true;
			// 
			// SubjectsGraduatesTab
			// 
			SubjectsGraduatesTab.Controls.Add(SubjectsGraduatesGrid);
			SubjectsGraduatesTab.Location = new Point(4, 24);
			SubjectsGraduatesTab.Name = "SubjectsGraduatesTab";
			SubjectsGraduatesTab.Padding = new Padding(3);
			SubjectsGraduatesTab.Size = new Size(1042, 549);
			SubjectsGraduatesTab.TabIndex = 6;
			SubjectsGraduatesTab.Text = "SubjectsGraduates";
			SubjectsGraduatesTab.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(1056, 166);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 14;
			btnCancel.Text = "Отменить";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// RawViewForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1143, 589);
			Controls.Add(btnCancel);
			Controls.Add(RawViewTabControl);
			Controls.Add(btnDelete);
			Controls.Add(btnRefresh);
			Controls.Add(btnSave);
			Name = "RawViewForm";
			Text = "RawViewForm";
			FormClosing += RawViewForm_FormClosing;
			Load += RawViewForm_Load;
			((System.ComponentModel.ISupportInitialize)GraduatesGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)GroupsGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)SubjectsGraduatesGrid).EndInit();
			((System.ComponentModel.ISupportInitialize)SubjectsGrid).EndInit();
			RawViewTabControl.ResumeLayout(false);
			GradTab.ResumeLayout(false);
			GroupsTab.ResumeLayout(false);
			SpecialitiesTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)SpecialitiesGrid).EndInit();
			ThesesTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ThesesGrid).EndInit();
			ProfessorsTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ProfessorsGrid).EndInit();
			SubjectsTab.ResumeLayout(false);
			SubjectsGraduatesTab.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private DataGridView GraduatesGrid;
        private DataGridView GroupsGrid;
        private DataGridView SubjectsGraduatesGrid;
        private DataGridView SubjectsGrid;
		private DataGridView SpecialitiesGrid;
		private DataGridView ThesesGrid;
		private DataGridView ProfessorsGrid;
		private Button btnSave;
        private Button btnRefresh;
        private Button btnDelete;
		private TabControl RawViewTabControl;
		private TabPage GradTab;
		private TabPage GroupsTab;
		private TabPage SpecialitiesTab;
		private TabPage ThesesTab;
		private TabPage ProfessorsTab;
		private TabPage SubjectsTab;
		private TabPage SubjectsGraduatesTab;
		private Button btnCancel;
	}
}