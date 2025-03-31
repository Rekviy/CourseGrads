namespace CourseGrads {
    partial class AddWin {
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
            btnAddGraduate = new Button();
            txtDiplomaNumber = new TextBox();
            txtFullName = new TextBox();
            cboSex = new ComboBox();
            txtAddress = new TextBox();
            cboGroup = new ComboBox();
            dtpEnrollmentYear = new DateTimePicker();
            dtpGraduationYear = new DateTimePicker();
            txtQualification = new TextBox();
            txtGraduationSubject = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            specTxt = new TextBox();
            label10 = new Label();
            txtGrades = new TextBox();
            txtProfessors = new TextBox();
            txtSubjects = new TextBox();
            label11 = new Label();
            label12 = new Label();
            labebl13 = new Label();
            SuspendLayout();
            // 
            // btnAddGraduate
            // 
            btnAddGraduate.Location = new Point(11, 397);
            btnAddGraduate.Name = "btnAddGraduate";
            btnAddGraduate.Size = new Size(75, 23);
            btnAddGraduate.TabIndex = 0;
            btnAddGraduate.Text = "Добавить";
            btnAddGraduate.UseVisualStyleBackColor = true;
            btnAddGraduate.Click += btnAddGraduate_Click;
            // 
            // txtDiplomaNumber
            // 
            txtDiplomaNumber.Location = new Point(12, 12);
            txtDiplomaNumber.Name = "txtDiplomaNumber";
            txtDiplomaNumber.Size = new Size(148, 23);
            txtDiplomaNumber.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(12, 41);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(230, 23);
            txtFullName.TabIndex = 2;
            // 
            // cboSex
            // 
            cboSex.FormattingEnabled = true;
            cboSex.Items.AddRange(new object[] { "М", "Ж", "Н" });
            cboSex.Location = new Point(12, 70);
            cboSex.Name = "cboSex";
            cboSex.Size = new Size(99, 23);
            cboSex.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(11, 99);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(261, 23);
            txtAddress.TabIndex = 4;
            // 
            // cboGroup
            // 
            cboGroup.FormattingEnabled = true;
            cboGroup.Location = new Point(12, 128);
            cboGroup.Name = "cboGroup";
            cboGroup.Size = new Size(177, 23);
            cboGroup.TabIndex = 5;
            cboGroup.SelectedIndexChanged += cboGroup_SelectedIndexChanged;
            // 
            // dtpEnrollmentYear
            // 
            dtpEnrollmentYear.Location = new Point(12, 186);
            dtpEnrollmentYear.Name = "dtpEnrollmentYear";
            dtpEnrollmentYear.Size = new Size(200, 23);
            dtpEnrollmentYear.TabIndex = 6;
            // 
            // dtpGraduationYear
            // 
            dtpGraduationYear.Location = new Point(12, 215);
            dtpGraduationYear.Name = "dtpGraduationYear";
            dtpGraduationYear.Size = new Size(200, 23);
            dtpGraduationYear.TabIndex = 7;
            // 
            // txtQualification
            // 
            txtQualification.Location = new Point(11, 244);
            txtQualification.Name = "txtQualification";
            txtQualification.Size = new Size(230, 23);
            txtQualification.TabIndex = 8;
            // 
            // txtGraduationSubject
            // 
            txtGraduationSubject.Location = new Point(11, 273);
            txtGraduationSubject.Name = "txtGraduationSubject";
            txtGraduationSubject.Size = new Size(231, 23);
            txtGraduationSubject.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 15);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 10;
            label1.Text = "Номер диплома";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 44);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 11;
            label2.Text = "ФИО";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(117, 73);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 12;
            label3.Text = "Пол";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(196, 131);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 13;
            label4.Text = "Группа";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(278, 102);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 14;
            label5.Text = "Адрес";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(218, 194);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 15;
            label6.Text = "Дата поступления";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(218, 221);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 16;
            label7.Text = "Дата выпуска";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(247, 247);
            label8.Name = "label8";
            label8.Size = new Size(157, 15);
            label8.TabIndex = 17;
            label8.Text = "Квалификация по диплому";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(248, 276);
            label9.Name = "label9";
            label9.Size = new Size(145, 15);
            label9.TabIndex = 18;
            label9.Text = "Тема дипломной работы";
            // 
            // specTxt
            // 
            specTxt.Location = new Point(11, 157);
            specTxt.Name = "specTxt";
            specTxt.Size = new Size(148, 23);
            specTxt.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(166, 160);
            label10.Name = "label10";
            label10.Size = new Size(92, 15);
            label10.TabIndex = 20;
            label10.Text = "Специальность";
            // 
            // txtGrades
            // 
            txtGrades.Location = new Point(10, 360);
            txtGrades.Name = "txtGrades";
            txtGrades.Size = new Size(231, 23);
            txtGrades.TabIndex = 21;
            // 
            // txtProfessors
            // 
            txtProfessors.Location = new Point(10, 331);
            txtProfessors.Name = "txtProfessors";
            txtProfessors.Size = new Size(231, 23);
            txtProfessors.TabIndex = 22;
            // 
            // txtSubjects
            // 
            txtSubjects.Location = new Point(11, 302);
            txtSubjects.Name = "txtSubjects";
            txtSubjects.Size = new Size(231, 23);
            txtSubjects.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(247, 363);
            label11.Name = "label11";
            label11.Size = new Size(91, 15);
            label11.TabIndex = 24;
            label11.Text = "Оценки(через;)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(247, 334);
            label12.Name = "label12";
            label12.Size = new Size(156, 15);
            label12.TabIndex = 25;
            label12.Text = "ФИО Профессоров(через;)";
            // 
            // labebl13
            // 
            labebl13.AutoSize = true;
            labebl13.Location = new Point(247, 305);
            labebl13.Name = "labebl13";
            labebl13.Size = new Size(106, 15);
            labebl13.TabIndex = 26;
            labebl13.Text = "Предметы(через;)";
            // 
            // AddWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labebl13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtSubjects);
            Controls.Add(txtProfessors);
            Controls.Add(txtGrades);
            Controls.Add(label10);
            Controls.Add(specTxt);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtGraduationSubject);
            Controls.Add(txtQualification);
            Controls.Add(dtpGraduationYear);
            Controls.Add(dtpEnrollmentYear);
            Controls.Add(cboGroup);
            Controls.Add(txtAddress);
            Controls.Add(cboSex);
            Controls.Add(txtFullName);
            Controls.Add(txtDiplomaNumber);
            Controls.Add(btnAddGraduate);
            Name = "AddWin";
            Text = "AddWin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddGraduate;
        private TextBox txtDiplomaNumber;
        private TextBox txtFullName;
        private ComboBox cboSex;
        private TextBox txtAddress;
        private ComboBox cboGroup;
        private DateTimePicker dtpEnrollmentYear;
        private DateTimePicker dtpGraduationYear;
        private TextBox txtQualification;
        private TextBox txtGraduationSubject;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox specTxt;
        private Label label10;
        private TextBox txtGrades;
        private TextBox txtProfessors;
        private TextBox txtSubjects;
        private Label label11;
        private Label label12;
        private Label labebl13;
    }
}