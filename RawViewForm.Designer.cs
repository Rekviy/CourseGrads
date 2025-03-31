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
            GradTable = new DataGridView();
            Groups = new DataGridView();
            SubjectsGraduates = new DataGridView();
            Subjects = new DataGridView();
            btnSave = new Button();
            btnRefresh = new Button();
            btnDeleteGraduate = new Button();
            ((System.ComponentModel.ISupportInitialize)GradTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Groups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubjectsGraduates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Subjects).BeginInit();
            SuspendLayout();
            // 
            // GradTable
            // 
            GradTable.AllowUserToOrderColumns = true;
            GradTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GradTable.Location = new Point(12, 12);
            GradTable.Name = "GradTable";
            GradTable.Size = new Size(955, 248);
            GradTable.TabIndex = 1;
            // 
            // Groups
            // 
            Groups.AllowUserToOrderColumns = true;
            Groups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Groups.Location = new Point(664, 308);
            Groups.Name = "Groups";
            Groups.Size = new Size(303, 248);
            Groups.TabIndex = 4;
            // 
            // SubjectsGraduates
            // 
            SubjectsGraduates.AllowUserToOrderColumns = true;
            SubjectsGraduates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SubjectsGraduates.Location = new Point(984, 12);
            SubjectsGraduates.Name = "SubjectsGraduates";
            SubjectsGraduates.Size = new Size(141, 325);
            SubjectsGraduates.TabIndex = 5;
            // 
            // Subjects
            // 
            Subjects.AllowUserToOrderColumns = true;
            Subjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Subjects.Location = new Point(12, 308);
            Subjects.Name = "Subjects";
            Subjects.Size = new Size(591, 248);
            Subjects.TabIndex = 6;
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
            Controls.Add(SubjectsGraduates);
            Controls.Add(Groups);
            Controls.Add(GradTable);
            Name = "RawViewForm";
            Text = "RawViewForm";
            Load += RawViewForm_Load;
            ((System.ComponentModel.ISupportInitialize)GradTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)Groups).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubjectsGraduates).EndInit();
            ((System.ComponentModel.ISupportInitialize)Subjects).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GradTable;
        private DataGridView Groups;
        private DataGridView SubjectsGraduates;
        private DataGridView Subjects;
        private Button btnSave;
        private Button btnRefresh;
        private Button btnDeleteGraduate;
    }
}