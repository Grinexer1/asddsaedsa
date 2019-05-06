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
    public partial class mened : Form
    {
        public mened()
        {
            InitializeComponent();
        }

        private void mened_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form si = new spiizdel();
            si.Show();
            this.Hide();
        }
    }
}
