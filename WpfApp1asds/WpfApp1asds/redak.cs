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
        private class tkani
        {
            public int id { get; set; }
            public string Название { get; set; }
            public double Ширина { get; set; }
            public double Длина { get; set; }
            public double Цена { get; set; }
            public tkani(int i, string n, double c,double l, double p)
            {
                this.id = i;
                this.Название = n;
                this.Ширина = c;
                this.Длина = l;
                this.Цена = p;
            }
        }
        SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
        private void redak_Load(object sender, EventArgs e)
        {
            if (WpfApp1asds.asd.l != 12) { this.Close(); }
            // TODO: This line of code loads data into the 'svirinDataSet1.Фурнитура' table. You can move, or remove it, as needed.
            this.фурнитураTableAdapter1.Fill(this.svirinDataSet1.Фурнитура);
            // TODO: This line of code loads data into the 'svirinDataSet.Фурнитура' table. You can move, or remove it, as needed.
            this.фурнитураTableAdapter.Fill(this.svirinDataSet.Фурнитура);
            String query = "select [id],[Название],[Ширина],[Длина],[Цена] from Ткани";
            sqlcon.Open();
            SqlCommand scmd = new SqlCommand(query, sqlcon);
            SqlDataReader drider = scmd.ExecuteReader();
            List<tkani> tkanis = new List<tkani>();
            while (drider.Read())
            {
                tkanis.Add(new tkani(Convert.ToInt32(drider[0]), drider[1].ToString(), Convert.ToDouble(drider[2]), Convert.ToDouble(drider[3]), Convert.ToDouble(drider[4])));
            }
            
            comboBox1.DataSource = tkanis;
            comboBox1.DisplayMember = "Название";
            comboBox1.ValueMember = "id";
            drider.Close();
            query = "select [id],[Наименование],[Ширина],[Длина],[Цена] from Фурнитура";
            scmd = new SqlCommand(query, sqlcon);
            drider = scmd.ExecuteReader();
            /*while (drider.Read())
            {
                furns.Add(new furn(Convert.ToInt32(drider[0]), drider[1].ToString(), Convert.ToDouble(drider[2]), Convert.ToDouble(drider[3]), Convert.ToDouble(drider[4])));
                if (drider[1]==null)
                {
                    furns.Add(new furn(Convert.ToInt32(drider[0]), "none", Convert.ToDouble(drider[2]), Convert.ToDouble(drider[3]), Convert.ToDouble(drider[4])));
                }
                else {
                    if (drider[2] == null)
                    {
                        furns.Add(new furn(Convert.ToInt32(drider[0]), drider[1].ToString(), 0, Convert.ToDouble(drider[3]), Convert.ToDouble(drider[4])));
                    }
                    else
                    {
                        if (drider[3] == null)
                        {
                            furns.Add(new furn(Convert.ToInt32(drider[0]), drider[1].ToString(), 0, Convert.ToDouble(drider[3]), Convert.ToDouble(drider[4])));
                        }
                        else
                        {
                            if (drider[4] == null)
                            {
                                furns.Add(new furn(Convert.ToInt32(drider[0]), drider[1].ToString(), Convert.ToDouble(drider[2]), Convert.ToDouble(drider[3]), 0));
                            }
                            else
                            {
                                furns.Add(new furn(Convert.ToInt32(drider[0]), drider[1].ToString(), Convert.ToDouble(drider[2]), Convert.ToDouble(drider[3]), Convert.ToDouble(drider[4])));
                            }
                        }
                    }
            }

        }*/
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
                art = "sjdfghgsdfmkks" + (Convert.ToInt32(dsad[0]) + 1).ToString();
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
            Form f1 = Application.OpenForms["user"];
            f1.Show();
            this.Dispose();
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
                if ((na == 0) && (nb == 00))
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
    }
}
