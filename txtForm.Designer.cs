namespace CourseGrads {
    partial class TxtForm {
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
			txtInput = new TextBox();
			label1 = new Label();
			SuspendLayout();
			// 
			// txtInput
			// 
			txtInput.Location = new Point(12, 52);
			txtInput.Name = "txtInput";
			txtInput.Size = new Size(282, 23);
			txtInput.TabIndex = 0;
			txtInput.KeyDown += txtInput_KeyDown;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 21);
			label1.Name = "label1";
			label1.Size = new Size(53, 15);
			label1.TabIndex = 1;
			label1.Text = "Введите:";
			// 
			// TxtForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(313, 117);
			Controls.Add(label1);
			Controls.Add(txtInput);
			Name = "TxtForm";
			Text = "TxtForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtInput;
        private Label label1;
    }
}