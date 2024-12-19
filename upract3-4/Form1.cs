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
    
    public partial class Тест : Form
    {
        Vhod v;
        List<string[]> questions = new List<string[]>();
        int curr_numb = 0, answer = 0;
        string fio_group;
        string text = "";
        public Тест(string text)
        {
            
            InitializeComponent();
            this.fio_group = text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (radioButton1.Checked==true)
            {
                if (radioButton1.Text == questions[curr_numb][4])
                {
                    answer++;
                    text += $"{curr_numb,4}\n";
                }
            }
            if (radioButton2.Checked==true)
            {
                if (radioButton2.Text == questions[curr_numb][4])
                {
                    answer++;
                    text += $"{curr_numb,4}\n";
                }
            }
            if (radioButton3.Checked==true)
            {
                if (radioButton3.Text == questions[curr_numb][4])
                {
                    answer++;
                    text += $"{curr_numb,4}\n";
                }
            }
            if (curr_numb < questions.Count-1)
            {
                curr_numb++;
                label1.Text = questions[curr_numb][0];
                radioButton1.Text = questions[curr_numb][1];
                radioButton2.Text = questions[curr_numb][2];
                radioButton3.Text = questions[curr_numb][3];

            }
            else
            {
                button1.Enabled = false;
                if (curr_numb+1 == answer)
                {
                    MessageBox.Show("Правильно" + " " + answer + "  " + "вопросов из"+" "+curr_numb);
                    pictureBox1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    text = answer.ToString();
                    StreamWriter writer = File.AppendText("Ответы.txt");
                    writer.WriteLine(this.fio_group+" "+text);
                    writer.Close();
                }
                else
                {
                    MessageBox.Show("Правильно" + " " + answer + "  " + "вопросов из" + " " + curr_numb);
                    pictureBox1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                  
                    StreamWriter writer = File.AppendText("Ответы.txt");
                    text = answer.ToString();
                    writer.WriteLine(this.fio_group+" "+text);
                    writer.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible=false;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(@"C:\Users\pluhi\Desktop\upract3-4\bin\Debug\iv.jpg");   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            v = new Vhod();
            v.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Тест_Load(object sender, EventArgs e)
        {
         
            StreamReader st = File.OpenText("test.txt");
            int i = 0, j;
            while (!st.EndOfStream)
            {
                string[] list = new string[6];
                for (j = 0; j < 5; j++)
                {
                    list[j] = st.ReadLine();

                }
                questions.Add(list);
                i++;
            }
            st.Close();
            this.Text = "Вопрос" + (curr_numb + 1);
            label1.Text = questions[0][0];
            radioButton1.Text = questions[0][1];
            radioButton2.Text = questions[0][2];
            radioButton3.Text = questions[0][3];
            MessageBox.Show(fio_group);
            label2.Text = fio_group;
        }
    }
}
