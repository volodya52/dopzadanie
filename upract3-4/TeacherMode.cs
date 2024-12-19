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
    public partial class TeacherMode : Form
    {
        Vhod v;
        //List<string>list=new List<string>();
        List<string[]> questions = new List<string[]>();
        int curr_numb = 0;
        public TeacherMode()
        {
            InitializeComponent();
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "test txt|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(ofd.FileName);
            }
           // StreamReader sr = File.OpenText("test.txt");
            //while (!sr.EndOfStream)
            //{ 
            //    listBox1.Text= sr.ReadToEnd();
            //    sr.Close();

            //}
           
        }

        private void TeacherMode_Load(object sender, EventArgs e)
        {
            string[] list = File.ReadAllLines("test.txt");

            foreach (var item in list)
            {
                listBox1.Items.Add(item);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            v = new Vhod();
            v.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int question_number = Convert.ToInt32(numericUpDown2.Value);
            string vopr = Convert.ToString(textBox4.Text);
            string otv1 = Convert.ToString(textBox1.Text);
            string otv2 = Convert.ToString(textBox2.Text);
            string otv3 = Convert.ToString(textBox3.Text);
            string righotv = Convert.ToString(textBox11.Text);
            StreamWriter sw = File.AppendText("test.txt");
            sw.Write($"\n{question_number}){vopr}\n{otv1}\n{otv2}\n{otv3}\n{righotv}");
            sw.Close();
            MessageBox.Show("Вопрос добавлен");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string vopr = Convert.ToString(textBox5.Text);
            //string otv1 = Convert.ToString(textBox6.Text);
            //string otv2 = Convert.ToString(textBox7.Text);
            //string otv3 = Convert.ToString(textBox8.Text);
            //string vernotv = Convert.ToString(textBox9.Text);
            //StreamWriter sw = File.AppendText("test.txt");
            //sw.Write($"\n{vopr}\n{otv1}\n{otv2}\n{otv3}\n{vernotv}");
            //sw.Close();
            //MessageBox.Show("Тест изменен");

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Images(*.BMP; *.JPG; *.GIF)|*.BMP;*.JPG;*.GIF| All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    string filename = Path.GetFileName(filePath);
                    File.Copy(filePath, filename, true);
                    pictureBox1.Image = Image.FromFile(filename);
                    //textBox9.Text = filename;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                textBox5.Text = listBox1.Items.ToString();
                textBox6.Text = listBox1.Items.ToString();
                textBox7.Text = listBox1.Items.ToString();
                textBox8.Text = listBox1.Items.ToString();
                textBox9.Text = listBox1.Items.ToString();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            string[] list = File.ReadAllLines("test.txt");
          
            foreach (var item in list)
            {
                listBox1.Items.Add(item);
                
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            //StreamWriter sw = File.AppendText("test.txt");
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //int count=Convert.ToInt32(numericUpDown1.Value);

        }
    }
}
