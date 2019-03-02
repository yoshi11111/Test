using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateSQL
{
    public partial class ResultForm : Form
    {
        public ResultForm(string[] list)
        {
            InitializeComponent();
            richTextBox1.Text = "StringBuilder sql = new StringBuilder();"+Environment.NewLine;            
            foreach (string txt in list)
            {
                richTextBox1.Text += (txt + Environment.NewLine);
            }
        }
    }
}
