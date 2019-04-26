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
    public partial class Form3 : Form
    {
        Form fa = Application.OpenForms[0];
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(181, 213, 202);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.dbConnectionString);
            string msg = "";
            int er = 0;
            //проверка полей на соответсиве
            if (textBox1.Text == "")
            {
                msg += "Введите логин; \n";er++;
            }
            if (textBox2.Text == "")
            {
                msg += "Введите пароль; \n"; er++;
            }
            if (textBox3.Text != textBox2.Text)
            {
                msg += "Подтвердите пароль; \n"; er++;
            }
            if (textBox4.Text == "")
            {
                msg += "Введите имя; \n"; er++;
            }
            int forb = 0;
            int forn = 0;
            int forc = 0;
            foreach(char a in textBox2.Text)
            {
                if (Char.IsUpper(a))
                {
                    forb++;
                }
                if (char.IsNumber(a))
                {
                    forn++;
                }
                if ((a == '!') || (a == '@') || (a == '#') || (a == '$') || (a == '%') || (a == '^'))
                {
                    forc++;
                }

            }
            if ((textBox2.Text.Length < 6)&&(forb<1)&&(forn<1)&&(forc<1))
            {
                msg += "Пароль не соответссвует требованиям; \n"; er++;
            }
            if (er > 0)
            {
                MessageBox.Show(msg);
            }
            else
            {
                try
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("insert into users (login,pass,role,name) values(@login,@pass,@role,@name)", sqlcon);
                    command.Parameters.AddWithValue("@login", textBox1.Text);
                    command.Parameters.AddWithValue("@pass", textBox2.Text);
                    command.Parameters.AddWithValue("@role", "user");
                    command.Parameters.AddWithValue("@name", textBox4.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пользователь добавлен");
                    sqlcon.Close();

                    fa.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fa.Show();
            this.Close();
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            fa.Show();
            this.Close();
        }
    }
}
