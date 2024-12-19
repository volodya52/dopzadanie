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
    
    public partial class Tablica : Form
    {
        List<string> list = new List<string>();
        Vhod v;
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        //StreamReader sr = File.OpenText("Ответы.txt");
        private void InitDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(GetDataGridViewColumn1());
            dataGridView1.Columns.Add(GetDataGridViewColumn2());
            dataGridView1.Columns.Add(GetDataGridViewColumn3());
            dataGridView1.AutoResizeColumns();


        }
        private DataGridViewColumn GetDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {


                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "ФИО";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn1;

        }

        private DataGridViewColumn GetDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {


                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Группа";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn2;
        }
        private DataGridViewColumn GetDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {


                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Кол-во верных ответов";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn3;
        }
        private void ShowListInGrid()
        {
            StreamReader sr = File.OpenText("Ответы.txt");

            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
           sr.Close();
            for (int i = 0; i < list.Count; i++)
            {
                string[] s = list[i].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                DataGridViewRow row=new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                cell1.ValueType=typeof(string);
                cell1.Value = s[0]+" "+s[1];
                cell2.ValueType=typeof(string);
                cell2.Value = s[2];
                cell3.ValueType=typeof(string);
                cell3.Value = s[3];                
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                dataGridView1.Rows.Add(row);
            }
            
            
        }
       
        
        public Tablica()
        {
            InitializeComponent();
            InitDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowListInGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            v=new Vhod();
            v.ShowDialog();
        }
    }
}
