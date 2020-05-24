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
    public partial class MemoTitleUC : UserControl
    {
        public Title ttl;
        public MemoTitleUC(Title ttl)
        {
            InitializeComponent();
            this.ttl = ttl;
            numericUpDown1.Value = ttl.Sort;
            textBox1.Text = ttl.Text;

        }

        public delegate void SortChanged();
        public SortChanged sortchangedDelegate;


        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
         

        }

        private void NumericUpDown1_Click(object sender, EventArgs e)
        {
            int sort = 1;
            if (int.TryParse(numericUpDown1.Value.ToString(), out sort))
            {
                this.ttl.Sort = sort;
                if (InvokeRequired)
                {
                    // 戻り値がvoidで、引数がstring1個の場合
                    Invoke(new Action(sortchangedDelegate));
                }
                else
                {
                    sortchangedDelegate();
                }


               
              //  Program.fm.ShowTitles();
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          //  this.ttl.Text = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ttl.Text = textBox1.Text;
        }
    }
}
