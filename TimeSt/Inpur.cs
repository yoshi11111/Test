using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSt
{
    public partial class InputPl : Form
    {
        public string InpunStr { get; set; }
        public InputPl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmp = textBox1.Text;
            if (string.IsNullOrEmpty(tmp) || tmp.Trim().Length < 10)
            {
                MessageBox.Show("10文字以上入力してください");
                return;
            }

            InpunStr = tmp;
            this.Close();

        }
    }
}
