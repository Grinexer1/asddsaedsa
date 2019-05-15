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
            public int schet { get; set; }
            public listik (string n, int i,int kolv,double cen,int sch)
            {
                this.Название = n;
                this.id = i;
                this.kolv = kolv;
                this.cen = cen;
                this.schet = sch;
            }
        }
        SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
        List<listik> listoflistik = new List<listik>();
        SqlCommand scmd;
        SqlDataReader drider;
        int sch = 0;
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
                drider.Read();
                int kolfur = Convert.ToInt32(drider[1]);
                int idfur = Convert.ToInt32(drider[0]);
                drider.Close();
                query = "select [id ткани]from [Ткани изделия] where [id изделия] =" + Convert.ToInt32(comboBox1.SelectedValue);
                scmd = new SqlCommand(query, sqlcon);
                drider = scmd.ExecuteReader();
                drider.Read();
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
            listoflistik.Add(new listik(comboBox1.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(textBox1.Text),cenafur,sch));
            int i = 0;
            double cenaend=0;
            listBox1.Items.Clear();
            while (i < listoflistik.Count)
            {
                cenaend += listoflistik[i].cen*listoflistik[i].kolv;
                listBox1.Items.Add(listoflistik[i].Название + " :" + listoflistik[i].kolv + " :" + (listoflistik[i].kolv*listoflistik[i].cen) + " руб.");
                i++;
            }
            label4.Text = cenaend.ToString();
            sqlcon.Close();
            textBox1.Text = "1";
            sch++;
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
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            WpfApp1asds.asd.log = "user";
            query = "insert into заказ(дата,[этап выполнения],заказчик,менеджер,стоимость) values('" +Convert.ToDateTime(date) + "','заказан','" + WpfApp1asds.asd.log + "','" + WpfApp1asds.asd.log + "'," + Convert.ToDouble(label4.Text) + ")";
            scmd = new SqlCommand(query, sqlcon);
            scmd.ExecuteScalar();
            int ist=0;
            try
            {
                while (ist< listoflistik.Count)
                {

                    query = "insert into [заказанные изделия]([номер заказа],[id изделия],количество) values(" + (lid+1) + "," + listoflistik[ist].id + "," + listoflistik[ist].kolv + ")";
                    scmd = new SqlCommand(query, sqlcon);
                    scmd.ExecuteScalar();
                    ist++;
               
                }
                MessageBox.Show("Заказ добавлен");
                listoflistik.Clear();
                listBox1.Items.Clear();
                label4.Text = "";
            }
            catch
            {
                /*int itj = 0;
                foreach (int idj in listBox1.ValueMember)
                {
                    while (itj<=listoflistik.Count)
                    {
                        if (idj == listoflistik[itj].id)
                        {

                        }
                    }
                }*/
                listoflistik.RemoveAt(ist);
                listBox1.Items.RemoveAt(ist);
                MessageBox.Show("Вы выбрали одинаковые товары несколько раз");
            }
            sqlcon.Close();
        }
        private void Zak_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f1 = Application.OpenForms["user"];
            f1.Show();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar))&&(e.KeyChar!=8))
            {
                e.Handled = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox1.Text) <= 0)
                {
                    textBox1.Text = "1";
                }
                if (Convert.ToInt32(textBox1.Text) > 100)
                {
                    textBox1.Text = "99";
                }
            }
            catch { }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                listoflistik.RemoveAt(Convert.ToInt32(listBox1.SelectedIndex));
                listBox1.Items.RemoveAt(Convert.ToInt32(listBox1.SelectedIndex));
                int i = 0;
                double cenaend = 0;
                listBox1.Items.Clear();
                while (i < listoflistik.Count)
                {
                    listBox1.Items.Add(listoflistik[i].Название + " :" + listoflistik[i].kolv + " :" + (listoflistik[i].kolv * listoflistik[i].cen) + " руб.");
                    cenaend += listoflistik[i].cen * listoflistik[i].kolv;
                    i++;
                }
                label4.Text = cenaend.ToString();
            }
        }
    }
}