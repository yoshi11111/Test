using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ExcelTopMemoLink.Form1;

namespace ExcelTopMemoLink
{
    public partial class TaskUC : UserControl
    {
        public int HH = 0;
        DayTask task;



        public TaskUC(DayTask dt)
        {
                        

            InitializeComponent();
            task = dt;
            this.HH = dt.HH;
            label1.Text = string.Format("{0}時\n～", HH);
            richTextBox1.Text = task.perfor;

            List<string> typeList = dt.plan.Split(',').ToList();
            typeList.RemoveAt(0);
            //挿入位置
            int insertRow = 0;
            int insertColumn = 0;
            for (int i = 0; i < typeList.Count(); i++)
            {
              
                if (typeList[i] == "" + (int)TimeType.VSTypping)
                {
                    Label lbl = new Label();
                    lbl.BackColor = Color.Blue;
                    lbl.Dock = DockStyle.Fill;
                    lbl.Padding = new Padding(0, 0, 0, 0);
                    lbl.Margin = new Padding(0, 0, 0, 0);
                    tableLayoutPanel1.Controls.Add(lbl, insertColumn, insertRow);
                }
                else if (typeList[i] == "" + (int)TimeType.Typping)
                {
                    Label lbl = new Label();
                    lbl.BackColor = Color.Green;
                    lbl.Dock = DockStyle.Fill;
                    lbl.Padding = new Padding(0, 0, 0, 0);
                    lbl.Margin = new Padding(0, 0, 0, 0);

                    tableLayoutPanel1.Controls.Add(lbl, insertColumn, insertRow);
                }
                else
                {
                    Label lbl = new Label();
                    lbl.BackColor = Color.Gray;
                    lbl.Dock = DockStyle.Fill;
                    lbl.Padding = new Padding(0, 0, 0, 0);
                    lbl.Margin = new Padding(0, 0, 0, 0);

                    tableLayoutPanel1.Controls.Add(lbl, insertColumn, insertRow);
                }
                //挿入位置
                insertColumn++;
                if (i == 29) {
                    insertRow = 1;
                }
            }



        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            task.perfor = richTextBox1.Text;
            
        }

        //public bool Check()
        //{
        //    //bool ret = true;
        //    //foreach (TextBox tb in new TextBox[] { textBox2, textBox3 })
        //    //{
        //    //    if (string.IsNullOrEmpty(tb.Text.Trim()))
        //    //    {
        //    //        tb.BackColor = Color.Yellow;
        //    //        ret = false;
        //    //        tb.Focus(); 


        //    //    }

        //    //}
        //    //return ret;

        //}
        public void BackColorClear()
        {


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

     
    }
}



