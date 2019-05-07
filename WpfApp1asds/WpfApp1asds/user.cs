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
            WpfApp1asds.asd.l = 12;
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

        private void спискиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void фурнитураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fur tk = new fur();
            tk.Show();
            tk.dataGridView1.ReadOnly = true;
            tk.button2.Visible = false;
            tk.button3.Visible = false;
            this.Hide();
        }

        private void тканиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tkani f = new tkani();
            f.Show();
            f.dataGridView1.ReadOnly = true;
            f.button2.Visible = false;
            f.button3.Visible = false;
            this.Hide();
        }
    }
}
