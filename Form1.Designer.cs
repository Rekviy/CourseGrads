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
            button1 = new Button();
            button5 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)GradTable).BeginInit();
            SuspendLayout();
            // 
            // GradTable
            // 
            GradTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GradTable.Location = new Point(12, 12);
            GradTable.Name = "GradTable";
            GradTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GradTable.Size = new Size(941, 330);
            GradTable.TabIndex = 0;
            // 
            // Add
            // 
            Add.Location = new Point(12, 441);
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
            btnDeleteGraduate.Location = new Point(12, 481);
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
            btnGraduatesCount.Click += btnGraduatesCount_Click;
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
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(974, 23);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 8;
            button1.Text = "⟲";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnRefresh_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 503);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 5;
            button5.Text = "Сохранить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(753, 441);
            button2.Name = "button2";
            button2.Size = new Size(142, 44);
            button2.TabIndex = 12;
            button2.Text = "Поиск красно-дипломников";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSearchRedDiploma_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 581);
            Controls.Add(button2);
            Controls.Add(btnSearchBySpeciality);
            Controls.Add(btnSearchGraduate);
            Controls.Add(btnGraduatesCount);
            Controls.Add(button1);
            Controls.Add(btnDeleteGraduate);
            Controls.Add(btnRawView);
            Controls.Add(button5);
            Controls.Add(Add);
            Controls.Add(GradTable);
            Name = "MainWindow";
            Text = "Window";
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
        private Button button1;
        private Button button5;
        private Button button2;
    }
}
