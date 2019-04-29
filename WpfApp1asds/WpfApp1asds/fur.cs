using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WpfApp1asds
{
    public partial class fur : Form
    {
        public fur()
        {
            InitializeComponent();
        }

        private void fur_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
            SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
            String query = "select* from Фурнитура";
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Фурнитура");
            dataGridView1.DataSource = ds.Tables["Фурнитура"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fur_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f1 = Application.OpenForms["skl"];
            f1.Show();
        }

        private void fur_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 40;
            dataGridView1.Height = this.Height - 101;
            button1.Location = new Point(this.Width - 103, this.Height - 74);
        }
    }
}
