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
            GraduatesTable = new DataGridView();
            Groups = new DataGridView();
            SubjectsGraduatesTable = new DataGridView();
            Subjects = new DataGridView();
            btnSave = new Button();
            btnRefresh = new Button();
            btnDeleteGraduate = new Button();
            ((System.ComponentModel.ISupportInitialize)GraduatesTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Groups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubjectsGraduatesTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Subjects).BeginInit();
            SuspendLayout();
            // 
            // GraduatesTable
            // 
            GraduatesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GraduatesTable.Location = new Point(12, 12);
            GraduatesTable.Name = "GraduatesTable";
            GraduatesTable.ReadOnly = true;
            GraduatesTable.Size = new Size(955, 248);
            GraduatesTable.TabIndex = 1;
            GraduatesTable.CellClick += dataGrid_CellClick;
            // 
            // Groups
            // 
            Groups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Groups.Location = new Point(664, 308);
            Groups.Name = "Groups";
            Groups.ReadOnly = true;
            Groups.Size = new Size(303, 248);
            Groups.TabIndex = 4;
            Groups.CellClick += dataGrid_CellClick;
            // 
            // SubjectsGraduatesTable
            // 
            SubjectsGraduatesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SubjectsGraduatesTable.Location = new Point(984, 12);
            SubjectsGraduatesTable.Name = "SubjectsGraduatesTable";
            SubjectsGraduatesTable.ReadOnly = true;
            SubjectsGraduatesTable.Size = new Size(141, 325);
            SubjectsGraduatesTable.TabIndex = 5;
            SubjectsGraduatesTable.CellClick += dataGrid_CellClick;
            // 
            // Subjects
            // 
            Subjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Subjects.Location = new Point(12, 308);
            Subjects.Name = "Subjects";
            Subjects.ReadOnly = true;
            Subjects.Size = new Size(591, 248);
            Subjects.TabIndex = 6;
            Subjects.CellClick += dataGrid_CellClick;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1018, 501);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1018, 455);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDeleteGraduate
            // 
            btnDeleteGraduate.Location = new Point(1018, 533);
            btnDeleteGraduate.Name = "btnDeleteGraduate";
            btnDeleteGraduate.Size = new Size(75, 23);
            btnDeleteGraduate.TabIndex = 9;
            btnDeleteGraduate.Text = "Удалить";
            btnDeleteGraduate.UseVisualStyleBackColor = true;
            btnDeleteGraduate.Click += btnDeleteGraduate_Click;
            // 
            // RawViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 589);
            Controls.Add(btnDeleteGraduate);
            Controls.Add(btnRefresh);
            Controls.Add(btnSave);
            Controls.Add(Subjects);
            Controls.Add(SubjectsGraduatesTable);
            Controls.Add(Groups);
            Controls.Add(GraduatesTable);
            Name = "RawViewForm";
            Text = "RawViewForm";
            Load += RawViewForm_Load;
            ((System.ComponentModel.ISupportInitialize)GraduatesTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)Groups).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubjectsGraduatesTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)Subjects).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GraduatesTable;
        private DataGridView Groups;
        private DataGridView SubjectsGraduatesTable;
        private DataGridView Subjects;
        private Button btnSave;
        private Button btnRefresh;
        private Button btnDeleteGraduate;
    }
}