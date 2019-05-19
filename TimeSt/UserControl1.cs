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

        public string[] Combo = new string[] {

            "実装 110_内設 機能説明３分の1量",
"実装 120_内設 機能説明３分の1量",
"実装 130_内設 機能説明２分の1量",
"実装 140_内設 完了",
"実装 141_内設 完了",
"実装 142_内設 完了",
"実装 完了工程情報反映展開 機能説明１４分の1量",
"テスト 110_内設 機能説明２分の1量",
"テスト 120_内設 機能説明２分の1量",
"テスト 130_内設 完了",
"テスト 140_内設 完了",
"テスト 141_内設 完了",
"テスト 142_内設 完了",
"テスト 完了工程情報反映展開 機能説明７分の１量"



        };


        public UserControl1(DT dt)
        {

            InitializeComponent();



            this.HH = dt.HH;
            label1.Text = dt.time;

            予定.Text = dt.plan;
            実績.Text = dt.perfor;
            if (HH > 17)
            {
                this.BackColor = Color.DarkBlue;
                this.label1.ForeColor = Color.White;


            }
            if (HH == 12)
            {
                this.BackColor = Color.Yellow;


            }
            if (HH == 11)
            {
                予定.Text += "昼会資料";

            }
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



