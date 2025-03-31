using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseGrads {
    public partial class txtForm : Form {
        public txtForm() {
            InitializeComponent();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) { 
                MainWindow.txtinput = txtInput.Text;
                this.Close();
            }
        }
    }
}
