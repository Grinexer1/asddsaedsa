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
    public partial class redak : Form
    {
        public redak()
        {
            InitializeComponent();
        }
        public void dr(int x, int y)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            Pen p = new Pen(Color.Black, 1);
            g.DrawRectangle(p, 10, 10, x, y);
            DataRowView item = (DataRowView)comboBox1.SelectedItem;
            String color = item.Row.ItemArray[3].ToString();
            Brush bru;
            if (item.Row.ItemArray[5].ToString().Contains("jpg"))
            {
                Bitmap bmp = new Bitmap(Image.FromFile(item.Row.ItemArray[5].ToString()));
                TextureBrush tbu = new TextureBrush(bmp);
                g.FillRectangle(tbu, 11, 11, x - 1, y - 1);
            }
            else
            {
                switch (color)
                {
                    case "красный":
                        bru = new SolidBrush(Color.Red);
                        g.FillRectangle(bru, 11, 11, x - 1, y - 1);
                        break;
                    case "зелёный":
                        bru = new SolidBrush(Color.Green);
                        g.FillRectangle(bru, 11, 11, x - 1, y - 1);
                        break;
                    default:
                        bru = new SolidBrush(Color.White);
                        g.FillRectangle(bru, 11, 11, x - 1, y - 1);
                        break;
                }
            }
        }
        private void redak_Paint(object sender, PaintEventArgs e)
        {
            /*SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
            String query = "select [id],[Название][Ширина],[Длина],[Цена] from Ткани";
            String query2 = "select [id],[Наименование],[Ширина],[Длина],[Цена] from Фурнитура";
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            SqlDataAdapter sda2 = new SqlDataAdapter(query2, sqlcon);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Image.FromFile(@"C:\Users\User15\gitpr\pr\WpfApp1asds\WpfApp1asds\izobr\furn\GB1220.jpg");
            */
            

        }

        SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
        private void redak_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'svirinDataSet2.Ткани' table. You can move, or remove it, as needed.
            this.тканиTableAdapter.Fill(this.svirinDataSet2.Ткани);

            // TODO: This line of code loads data into the 'svirinDataSet1.Фурнитура' table. You can move, or remove it, as needed.
            this.фурнитураTableAdapter1.Fill(this.svirinDataSet1.Фурнитура);
            // TODO: This line of code loads data into the 'svirinDataSet.Фурнитура' table. You can move, or remove it, as needed.
            this.фурнитураTableAdapter.Fill(this.svirinDataSet.Фурнитура);
            String query = "select [id],[Название],[Ширина],[Длина],[Цена] from Ткани";
            sqlcon.Open();
            SqlCommand scmd = new SqlCommand(query, sqlcon);
            SqlDataReader drider = scmd.ExecuteReader();
            drider.Close();
            sqlcon.Close();
        }

        private void comboBox2_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            String query;
            query = "select ширина from Фурнитура where id=" + comboBox2.SelectedValue;
            SqlCommand scmd=new SqlCommand(query,sqlcon);
            double shir = Convert.ToDouble(scmd.ExecuteScalar());
            query= "select длина from Фурнитура where id=" + comboBox2.SelectedValue;
            scmd = new SqlCommand(query, sqlcon);
            double dlin = Convert.ToDouble(scmd.ExecuteScalar());
            query = "select [id] from изделия";
            scmd = new SqlCommand(query, sqlcon);
            SqlDataReader dsad = scmd.ExecuteReader();

            string art = "";
            int id = 0;
            while (dsad.Read())
            {
                art = "user-" + (Convert.ToInt32(dsad[0]) + 1).ToString();
                id = (Convert.ToInt32(dsad[0]) + 1);
            }
             
            string squ = " insert into изделия([Артикул],[Наименование],[Ширина],[Длина]) values ('" + art + "','" + textBox1.Text + "'," + Convert.ToDouble(textBox2.Text) + "," + Convert.ToDouble(textBox2.Text) + ")";
            scmd = new SqlCommand(squ, sqlcon);
            dsad.Close();
            scmd.ExecuteNonQuery();
            squ = "insert into [фурнитура изделия]([id фурнитуры],[id изделия],размещение,ширина,длинна,количество) values(" + Convert.ToInt32(comboBox2.SelectedValue) + "," + id.ToString() + ",'asd',"+shir+","+dlin+",1)";
            scmd = new SqlCommand(squ, sqlcon);
            scmd.ExecuteNonQuery();
            squ = "insert into [Ткани изделия]([id ткани],[id изделия]) values(" + Convert.ToInt32(comboBox1.SelectedValue) + "," + id.ToString() + ")";
            scmd = new SqlCommand(squ, sqlcon);
            scmd.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("Изделие добавлено");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text=comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
        }

        private void redak_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text.Trim().Length!=0)&&(textBox2.Text.Trim().Length != 0))
            {
                int na = 0;
                int nb = 0;
                foreach(char a in textBox2.Text)
                {
                    if (char.IsNumber(a))
                    {

                    }
                    else { na++; }
                }
                foreach(char b in textBox3.Text)
                {
                    if (char.IsNumber(b))
                    {

                    }
                    else { nb++; }
                }
                if ((na == 0) && (nb == 00)&&(Convert.ToInt32(textBox2.Text.Trim())>0)&&(Convert.ToInt32(textBox3.Text.Trim())>0))
                {
                    dr(Convert.ToInt32(textBox2.Text.Trim()),Convert.ToInt32(textBox3.Text.Trim()));
                }
                else
                {
                    if (na != 0)
                    {
                        MessageBox.Show("Длина не является числом");
                    }
                    else
                    {
                        MessageBox.Show("Ширина не является числом");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Введите длину и ширину");
            }
        }

        private void redak_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Form f1 = Application.OpenForms["user"];
            f1.Show();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f2 = new dobavltkani();
            f2.Show();
            this.Enabled=false;
        }
    }
}
