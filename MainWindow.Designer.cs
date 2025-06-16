namespace CourseGrads
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			GradTable = new DataGridView();
			Add = new Button();
			btnRawView = new Button();
			btnDeleteGraduate = new Button();
			btnGraduatesCount = new Button();
			btnSearchGraduate = new Button();
			btnSearchBySpeciality = new Button();
			btnRefresh = new Button();
			btnSave = new Button();
			btnRedDiplomaSearch = new Button();
			btnCancel = new Button();
			((System.ComponentModel.ISupportInitialize)GradTable).BeginInit();
			SuspendLayout();
			// 
			// GradTable
			// 
			GradTable.AllowDrop = true;
			GradTable.AllowUserToAddRows = false;
			GradTable.AllowUserToOrderColumns = true;
			GradTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			GradTable.Location = new Point(12, 12);
			GradTable.Name = "GradTable";
			GradTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			GradTable.Size = new Size(941, 410);
			GradTable.TabIndex = 0;
			GradTable.UserDeletingRow += GradTable_UserDeletingRow;
			// 
			// Add
			// 
			Add.Location = new Point(12, 484);
			Add.Name = "Add";
			Add.Size = new Size(75, 23);
			Add.TabIndex = 1;
			Add.Text = "Добавить";
			Add.UseVisualStyleBackColor = true;
			Add.Click += Add_Click;
			// 
			// btnRawView
			// 
			btnRawView.Location = new Point(939, 546);
			btnRawView.Name = "btnRawView";
			btnRawView.Size = new Size(75, 23);
			btnRawView.TabIndex = 6;
			btnRawView.Text = "RawView";
			btnRawView.UseVisualStyleBackColor = true;
			btnRawView.Click += btnRawView_Click;
			// 
			// btnDeleteGraduate
			// 
			btnDeleteGraduate.Location = new Point(221, 523);
			btnDeleteGraduate.Name = "btnDeleteGraduate";
			btnDeleteGraduate.Size = new Size(75, 23);
			btnDeleteGraduate.TabIndex = 7;
			btnDeleteGraduate.Text = "Удалить";
			btnDeleteGraduate.UseVisualStyleBackColor = true;
			btnDeleteGraduate.Click += btnDeleteGraduate_Click;
			// 
			// btnGraduatesCount
			// 
			btnGraduatesCount.Location = new Point(445, 441);
			btnGraduatesCount.Name = "btnGraduatesCount";
			btnGraduatesCount.Size = new Size(75, 44);
			btnGraduatesCount.TabIndex = 9;
			btnGraduatesCount.Text = "Подсчет";
			btnGraduatesCount.UseVisualStyleBackColor = true;
			btnGraduatesCount.Click += btnGraduatesSpecCount_Click;
			// 
			// btnSearchGraduate
			// 
			btnSearchGraduate.Location = new Point(661, 441);
			btnSearchGraduate.Name = "btnSearchGraduate";
			btnSearchGraduate.Size = new Size(75, 44);
			btnSearchGraduate.TabIndex = 10;
			btnSearchGraduate.Text = "Поиск по диплому";
			btnSearchGraduate.UseVisualStyleBackColor = true;
			btnSearchGraduate.Click += btnSearchGraduate_Click;
			// 
			// btnSearchBySpeciality
			// 
			btnSearchBySpeciality.Location = new Point(553, 441);
			btnSearchBySpeciality.Name = "btnSearchBySpeciality";
			btnSearchBySpeciality.Size = new Size(102, 44);
			btnSearchBySpeciality.TabIndex = 11;
			btnSearchBySpeciality.Text = "Поиск по специальности";
			btnSearchBySpeciality.UseVisualStyleBackColor = true;
			btnSearchBySpeciality.Click += btnSearchBySpeciality_Click;
			// 
			// btnRefresh
			// 
			btnRefresh.Cursor = Cursors.Hand;
			btnRefresh.FlatStyle = FlatStyle.System;
			btnRefresh.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnRefresh.Location = new Point(974, 23);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(40, 40);
			btnRefresh.TabIndex = 8;
			btnRefresh.Text = "⟲";
			btnRefresh.TextAlign = ContentAlignment.BottomCenter;
			btnRefresh.UseVisualStyleBackColor = true;
			btnRefresh.Click += btnRefresh_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 523);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 5;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnRedDiplomaSearch
			// 
			btnRedDiplomaSearch.Location = new Point(753, 441);
			btnRedDiplomaSearch.Name = "btnRedDiplomaSearch";
			btnRedDiplomaSearch.Size = new Size(142, 44);
			btnRedDiplomaSearch.TabIndex = 12;
			btnRedDiplomaSearch.Text = "Поиск красно-дипломников";
			btnRedDiplomaSearch.UseVisualStyleBackColor = true;
			btnRedDiplomaSearch.Click += btnSearchRedDiploma_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(93, 523);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 13;
			btnCancel.Text = "Отменить";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1026, 581);
			Controls.Add(btnCancel);
			Controls.Add(btnRedDiplomaSearch);
			Controls.Add(btnSearchBySpeciality);
			Controls.Add(btnSearchGraduate);
			Controls.Add(btnGraduatesCount);
			Controls.Add(btnRefresh);
			Controls.Add(btnDeleteGraduate);
			Controls.Add(btnRawView);
			Controls.Add(btnSave);
			Controls.Add(Add);
			Controls.Add(GradTable);
			Name = "MainWindow";
			Text = "Window";
			FormClosing += MainWindow_FormClosing;
			Load += MainWindow_Load;
			((System.ComponentModel.ISupportInitialize)GradTable).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView GradTable;
        private Button Add;
        private Button btnRawView;
        private Button btnDeleteGraduate;
        private Button btnGraduatesCount;
        private Button btnSearchGraduate;
        private Button btnSearchBySpeciality;
        private Button btnRefresh;
        private Button btnSave;
        private Button btnRedDiplomaSearch;
		private Button btnCancel;
	}
}
