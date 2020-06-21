using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TimeSt.Form1;

namespace TimeSt
{
    public partial class UserControl1 : UserControl
    {
        public int HH = 0;

        


        public UserControl1(DT dt)
        {

            InitializeComponent();



            label1.Text = dt.time;
            this.HH = dt.HH;
            予定.Text = dt.plan;
            実績.Text = dt.perfor;
    
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



