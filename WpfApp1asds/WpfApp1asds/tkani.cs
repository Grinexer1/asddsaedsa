﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace WpfApp1asds
{

    public partial class tkani : Form
    {
        public tkani()
        {
            InitializeComponent();
        }
        DataSet ds;
        SqlDataAdapter sda;
        Form f1 = Application.OpenForms["skl"];
        private void tkani_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
            SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
            String query = "select  [id],[Артикул],[Название],[Цвет],[Рисунок],[Состав],[Ширина],[Длина],[Цена] from Ткани";
            sqlcon.Open();
            sda = new SqlDataAdapter(query, sqlcon);
            ds = new DataSet();
            ds.AcceptChanges();
            sda.Fill(ds, "Ткани");
            dataGridView1.DataSource = ds.Tables["Ткани"];
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Изображение";
            img.AutoSizeMode=new DataGridViewAutoSizeColumnMode();
            dataGridView1.Columns.Add(img);
            Image image;
            string filename;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    filename = dataGridView1.Rows[i].Cells[1].Value.ToString() + ".jpg";
                    if (File.Exists(@"C:\Users\User15\gitpr\pr\WpfApp1asds\WpfApp1asds\izobr\tkani\" + filename))
                    {

                        image = Image.FromFile(@"C:\Users\User15\gitpr\pr\WpfApp1asds\WpfApp1asds\izobr\tkani\" + filename);
                    }
                    else
                    {
                        image = Image.FromFile(@"C:\Users\User15\gitpr\pr\WpfApp1asds\WpfApp1asds\izobr\emt.jpg");
                    }
                }
                else
                {
                    image = Image.FromFile(@"C:\Users\User15\gitpr\pr\WpfApp1asds\WpfApp1asds\izobr\emt.jpg");
                }
                dataGridView1.Rows[i].Cells["img"].Value = image;
            
        }
            dataGridView1.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            sqlcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private void tkani_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WpfApp1asds.asd.role == "skl")
            {
                f1.Show();
            }
            if (WpfApp1asds.asd.role == "user")
            {
                Form f2 = Application.OpenForms["user"];
                dataGridView1.ReadOnly = false;
                button1.Visible = true;
                button2.Visible = true;
                f2.Show();
            }
            dataGridView1.Dispose();
            this.Dispose();
        }

        private void tkani_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 40;
            dataGridView1.Height = this.Height - 101;
            button1.Location = new Point(12,dataGridView1.Height+27);
            button2.Location = new Point(dataGridView1.Width - button2.Width, dataGridView1.Height + 27);
            button3.Location = new Point(dataGridView1.Width - button2.Width - 130, dataGridView1.Height + 27);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet changes = this.ds.GetChanges();
            if (changes != null)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                builder.GetInsertCommand();
                int updatesrows = sda.Update(changes, "Ткани");
                ds.AcceptChanges();
                WpfApp1asds.asd.x = this.Location.X;
                WpfApp1asds.asd.y = this.Location.Y;
                Form thi = new tkani();
                thi.Show();
                thi.Location = new Point(WpfApp1asds.asd.x, WpfApp1asds.asd.y);
                this.Close();
                f1.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
                button2_Click(sender, e);
            }
        }
    }
}
