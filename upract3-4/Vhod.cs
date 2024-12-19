using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace upract3_4
{
    public partial class Vhod : Form
    {
        Тест f;
        Tablica t;
        TeacherMode m;
        public Vhod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                f = new Тест($"{textBox1.Text + " " + textBox2.Text}");
                //f.Text = ""; 
              
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не ввели данные");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button3.Visible = true;
            label1.Visible = true;
            button5.Visible = true;
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string surname = Convert.ToString(textBox3.Text);
            string password=Convert.ToString(textBox4.Text);
            if (surname ==""||password =="")
            {
                MessageBox.Show("Вы не заполнили окно");
            }
            else if (password != "177013")
            {
                MessageBox.Show("Вы ввели неверный пароль");
            }
            else
            {
                MessageBox.Show($"Вход в аккаунт учителя {surname}");
                m = new TeacherMode();
                m.ShowDialog();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            t = new Tablica();
            t.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            
        }
    }
}
