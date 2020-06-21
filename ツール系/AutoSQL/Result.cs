using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTOSQL
{
    public partial class ResultForm : Form
    {
        public ResultForm(bool isChecked, string[] list)
        {
            InitializeComponent();
            if (isChecked)
            {
                richTextBox1.Text = "StringBuilder with = new StringBuilder();" + Environment.NewLine;
                richTextBox1.Text += "with.AppendLine(\"WITH SUB1 AS (\" );" + Environment.NewLine;
            }
            else
            {
                richTextBox1.Text = "StringBuilder sql = new StringBuilder();" + Environment.NewLine;
            }

            foreach (string txt in list)
            {
                richTextBox1.Text += (txt + Environment.NewLine);
            }
        }
    }
}




