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
    public partial class tkani : Form
    {
        public tkani()
        {
            InitializeComponent();
        }

        private void tkani_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
            SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
            String query = "select* from Ткани";
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query,sqlcon);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Ткани");
            dataGridView1.DataSource = ds.Tables["Ткани"];
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Изображение";
            dataGridView1.Columns.Add(img);
            Image image;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                try
                {
                    string filename = dataGridView1.Rows[i].Cells[1].Value.ToString() + ".jpg";
                    if (i == 1)
                    { 
                        MessageBox.Show(filename);
                    }
                    image = Image.FromFile(@"C:\Users\User15\gitpr\pr\WpfApp1asds\WpfApp1asds\izobr\tkani\" + filename);
                }
               catch
                {
                    image = Image.FromFile(@"C:\Users\User15\gitpr\pr\WpfApp1asds\WpfApp1asds\izobr\emt.jpg");
                }
                dataGridView1.Rows[i].Cells["img"].Value = image;
            }
            
            sqlcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private void tkani_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f1 = Application.OpenForms["skl"];
            f1.Show();
        }

        private void tkani_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 40;
            dataGridView1.Height = this.Height - 101;
            button1.Location = new Point(this.Width - 103,this.Height-74);

        }
    }
}
