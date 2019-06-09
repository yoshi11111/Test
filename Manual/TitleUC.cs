using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manual.DataMng;

namespace Manual
{
    public partial class TitleUC : UserControl
    {
        public Title ttl;
        public TitleUC(Title ttl)
        {
            InitializeComponent();
            this.ttl = ttl;
            numericUpDown1.Value = ttl.sort;
            richTextBox1.Text = ttl.text;

        }


  
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
         

        }

        private void NumericUpDown1_Click(object sender, EventArgs e)
        {
            int sort = 1;
            if (int.TryParse(numericUpDown1.Value.ToString(), out sort))
            {
                this.ttl.sort = sort;
                Program.fm.ShowTitles();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ttl.text = richTextBox1.Text;
        }
    }
}
