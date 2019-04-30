using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApp1asds
{
    public partial class skl : Form
    {
        public skl()
        {
            InitializeComponent();
        }

        private void skl_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
        }

        public void тканиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tk = new tkani();
            tk.Show();
            this.Hide();
        }

        private void skl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form fa = Application.OpenForms["Form1"];
            fa.Show();
        }

        private void фурнитураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new fur();
            ff.Show();
            this.Hide();
        }
    }
}
