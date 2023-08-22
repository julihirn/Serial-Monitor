using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.WindowForms {
    public partial class TextComparator : Form {
        public TextComparator() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            textCompare1.CompareFrom = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            textCompare1.CompareTo = textBox2.Text;
        }

        private void TextComparator_Load(object sender, EventArgs e) {

        }
    }
}
