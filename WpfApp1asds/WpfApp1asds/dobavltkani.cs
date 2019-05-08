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
    public partial class dobavltkani : Form
    {
        public dobavltkani()
        {
            InitializeComponent();
        }
        string file;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            
            openFileDialog1.Filter = "JPEG images|*.jpg";
            openFileDialog1.Title = "Выберете изображени";
            
            if (openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(file);
                pictureBox1.Width = Convert.ToInt32(textBox3.Text);
                pictureBox1.Height = Convert.ToInt32(textBox2.Text);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            }
            catch { MessageBox.Show("Вы не ввели размеры"); }
        }
        SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
        private void button2_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            String query;
            SqlCommand scmd;
            query = "select [id] from изделия";
            scmd = new SqlCommand(query, sqlcon);
            SqlDataReader dsad = scmd.ExecuteReader();

            string art = "";
            while (dsad.Read())
            {
                art = "user-" + (Convert.ToInt32(dsad[0]) + 1).ToString();
            }
            dsad.Close();
            query = "insert into [Ткани](Артикул,Название,Цвет,Изображение,Ширина,Длина,Цена) values('" + art + "','" + textBox1.Text.Trim() + "','" + textBox4.Text.Trim()+"','"+file+"',"+Convert.ToInt32(textBox2.Text.Trim())+","+Convert.ToInt32(textBox3.Text.Trim())+",100)" ;
            scmd = new SqlCommand(query, sqlcon);
            scmd.ExecuteScalar();
            MessageBox.Show("Ткань добавлена");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image.Dispose();
        }

        private void dobavltkani_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f1 = Application.OpenForms["redak"];
            f1.Enabled=true;
            
        }

        private void dobavltkani_Load(object sender, EventArgs e)
        {

        }
    }
}
