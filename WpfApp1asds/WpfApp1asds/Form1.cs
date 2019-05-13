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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WpfApp1asds.asd.l = 0;
            adm adm = new adm();
            mened men = new mened();
            skl sk = new skl();
            user use = new user();
            SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
            sqlcon.Open();
            int er = 0;
            string asd="";
            if (textBox1.Text == "")
            {
                er++;
                asd += "Введите логин \n";

            }
            if (textBox2.Text == "")
            {
                er++;
                asd += "Введите пароль \n";
            }
            if (er < 1)
            {
                try
                {
                    
                    SqlCommand command = new SqlCommand("select role from users where login='" + textBox1.Text + "' and pass='" + textBox2.Text + "'", sqlcon);
                    WpfApp1asds.asd.role = command.ExecuteScalar().ToString();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    if (WpfApp1asds.asd.role == "admin")
                    {
                        WpfApp1asds.asd.log = textBox1.Text;
                        adm.Show();
                        this.Hide();
                    }
                    else
                    {

                        if (WpfApp1asds.asd.role == "manager")
                        {
                            WpfApp1asds.asd.log = textBox1.Text;
                            men.Show();
                            this.Hide();
                        }
                        else
                        {
                            if (WpfApp1asds.asd.role == "skl")
                            {
                                WpfApp1asds.asd.log = textBox1.Text;
                                sk.Show();
                                this.Hide();
                            }
                            else
                            {
                                if (WpfApp1asds.asd.role == "user")
                                {
                                    WpfApp1asds.asd.log = textBox1.Text;
                                    use.Show();
                                    this.Hide();
                                }
                                else { MessageBox.Show("Роль пользователя не указана в системе"); }
                            }
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Не верный логин/пароль");
                    
                }
            }
            else
            {
                MessageBox.Show(asd);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(1, e);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(1, e);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(1, e);
            }
        }
    }
}
