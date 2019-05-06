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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
        }

        private void конструкторИздклияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redak re = new redak();
            re.Show();
            this.Hide();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spiizdel si = new spiizdel();
            si.Show();
            this.Hide();
        }

        private void user_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f1 = Application.OpenForms["Form1"];
            f1.Show();

        }
    }
}
