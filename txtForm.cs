using CourseGrads.Data;
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
    public partial class TxtForm : Form {
		public event Action<string>? InputComplete;

		public TxtForm() {
            InitializeComponent();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) { 
				InputComplete?.Invoke(txtInput.Text);
				this.Close();
            }
        }
    }
}
