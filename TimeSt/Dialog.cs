using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSt
{
    public partial class Dialog : Form
    {
        public string Zisseki;
        public string Yotei;

        public Dialog(UserControl1 uc)
        {
            InitializeComponent();
            this.TopMost = true;
            if (uc != null)
            {
                richTextBox1.Text = uc.予定.Text;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zi = zisse.Text;
            string yo = yote.Text;

            if (string.IsNullOrEmpty(zi) || string.IsNullOrEmpty(yo)
                || (zi.Length < 11) || yo.Length < 11)
            {
                MessageBox.Show("10文字以上入力して下さい。");
                return;
            }

            Zisseki = zi;
            Yotei = yo;
            this.Close();


        }
    }
}

