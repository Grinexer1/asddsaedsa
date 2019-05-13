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
    public partial class Zak : Form
    {
        public Zak()
        {
            InitializeComponent();
        }

        private void Zak_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'svirinDataSet3.изделия' table. You can move, or remove it, as needed.
            this.изделияTableAdapter.Fill(this.svirinDataSet3.изделия);

        }
        private class listik
        {
            public string Название{get;set;}
            public int id {get; set;}
            public int kolv { get; set; }
            public double cen { get; set; }
            public listik (string n, int i,int kolv,double cen)
            {
                this.Название = n;
                this.id = i;
                this.kolv = kolv;
                this.cen = cen;
            }
        }
        SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
        List<listik> listoflistik = new List<listik>();
        SqlCommand scmd;
        SqlDataReader drider;
        private void button1_Click(object sender, EventArgs e)
        {
            double cena;
            //listBox1.Items.Add(comboBox1.SelectedText);
            sqlcon.Open();
            double cenafur = 1000;
            try
            {
                string query = "select [id фурнитуры], количество from [фурнитура изделия] where [фурнитура изделия].[id изделия] = " + Convert.ToInt32(comboBox1.SelectedValue);
                scmd = new SqlCommand(query, sqlcon);
                drider = scmd.ExecuteReader();
                int kolfur = Convert.ToInt32(drider[1]);
                int idfur = Convert.ToInt32(drider[0]);
                drider.Close();
                query = "select [id ткани]from [Ткани изделия] where [id изделия] =" + Convert.ToInt32(comboBox1.SelectedValue);
                scmd = new SqlCommand(query, sqlcon);
                drider = scmd.ExecuteReader();
                int idtkani = Convert.ToInt32(drider[0]);
                drider.Close();
                query = "select Цена from Фурнитура where [id]='" + idfur.ToString() + "'";
                scmd = new SqlCommand(query, sqlcon);
                cenafur = Convert.ToDouble(scmd.ExecuteScalar()) * kolfur;
                query = "select Цена from Ткани where [id]='" + idtkani + "'";
                scmd = new SqlCommand(query, sqlcon);
                cenafur = cenafur + Convert.ToDouble(scmd.ExecuteScalar());
            }
            catch { }
            listoflistik.Add(new listik(comboBox1.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(textBox1.Text),cenafur));
            int i = 0;
            double cenaend=0;
            listBox1.Items.Clear();
            while (i < listoflistik.Count)
            {
                listBox1.Items.Add(comboBox1.Text);
                cenaend += listoflistik[i].cen*listoflistik[i].kolv;
                i++;
            }
            label4.Text = cenaend.ToString();
            sqlcon.Close();
            textBox1.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            string query = "select [номер заказа] from заказ";
            scmd = new SqlCommand(query, sqlcon);
            drider = scmd.ExecuteReader();
            int lid = 0;
            try
            {
                while (drider.Read())
                {
                    lid = Convert.ToInt32(drider[0]);
                }
            }
            catch { }
            drider.Close();
            string date = DateTime.Now.ToString("mm-dd-yyyy");
            WpfApp1asds.asd.log = "user";
            query = "insert into заказ(дата,[этап выполнения],заказчик,менеджер,стоимость) values('" + date + "','заказан','" + WpfApp1asds.asd.log + "','" + WpfApp1asds.asd.log + "'," + Convert.ToDouble(label4.Text) + ")";
            scmd = new SqlCommand(query, sqlcon);
            scmd.ExecuteScalar();
            int ist=0;
            while (ist< listoflistik.Count)
            {
                query = "insert into [заказанные изделия]([номер заказа],[id изделия],количество) values(" + lid + "," +listoflistik[ist].id+","+listoflistik[ist].kolv+")";
                scmd = new SqlCommand(query, sqlcon);
                scmd.ExecuteScalar();
                ist++;
            }
            sqlcon.Close();
            MessageBox.Show("Заказ добавлен");
            listoflistik.Clear();
            listBox1.Items.Clear();
            label4.Text = "";
            comboBox1.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        private void Zak_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f1 = Application.OpenForms["user"];
            f1.Show();
        }
    }
}
