using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manual.DataMng;

namespace Manual
{
    public partial class Form1 : Form
    {
        public static Title currentTitle;
        private Point pos;

        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        private static extern IntPtr SendMessage(System.IntPtr hWnd, Int32 Msg, Int32 wParam, ref Point lParam);

        private string[] del = { "\n" };


        public Form1()
        {
            InitializeComponent();
        }
        public delegate void Clickded();
        int textBoxCnt = 10;
        private void Form1_Load(object sender, EventArgs e)
        {
            DataMng.LoadData();
            if (DataMng.TitleList == null || DataMng.TitleList.Count == 0)
            {
                DataMng.TitleList = new List<Title>();
                for (int i = 0; i < textBoxCnt; i++)
                {
                    DataMng.TitleList.Add(new Title());
                }
            }

            ShowTitles();
            ShowItems();

        }
        
        private void TBClicked(object sender, EventArgs e)
        {

            TitleUC uc = ((Control)sender).Parent.Parent as TitleUC;
            currentTitle = uc.ttl;
            ShowItems();

        }
        public void ShowItems()
        {

            if (currentTitle == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(currentTitle.leftRtf) || string.IsNullOrEmpty(currentTitle.rightRtf))
            {
                richTextBox1.Text = string.Empty;
                richTextBox2.Text = string.Empty;

                for (int i = 0; i < 100; i++)
                {
                    richTextBox1.Text += "\n";
                    richTextBox2.Text += "\n";
                }               
            }
            else
            {
                richTextBox1.Rtf = currentTitle.leftRtf;
                richTextBox2.Rtf = currentTitle.rightRtf;
            }
            }


        public void ShowTitles()
        {
            DataMng.TitleList = (from itm in DataMng.TitleList
                                 orderby itm.sort 
                                 select itm).ToList();
            panel1.Controls.Clear();
            currentTitle = null;
            foreach (Title ttl in DataMng.TitleList)
            {
                TitleUC tb = new TitleUC(ttl);
                tb.richTextBox1.Click += TBClicked;
                tb.Dock = DockStyle.Top;
                panel1.Controls.Add(tb);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataMng.SaveData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ExcelUtil().Export();
        }


        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (currentTitle == null)
            {
                return;
            }
            currentTitle.leftRtf = richTextBox1.Rtf;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (currentTitle == null)
            {
                return;
            }
            currentTitle.rightRtf = richTextBox2.Rtf;
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            // スクロール位置を取得
            SendMessage(this.richTextBox1.Handle, 0x04DD, 0, ref pos);
            SendMessage(this.richTextBox2.Handle, 0x04DE, 0, ref pos);
        }

        private void richTextBox2_VScroll(object sender, EventArgs e)
        {
            // スクロール位置を取得
            SendMessage(this.richTextBox2.Handle, 0x04DD, 0, ref pos);
            SendMessage(this.richTextBox1.Handle, 0x04DE, 0, ref pos);
        }

        
        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewLIne();
            }
        }
        private void AddNewLIne()
        {
            //int count1 = richTextBox1.Text.Split(del, StringSplitOptions.None).Count();
            //int count2 = richTextBox2.Text.Split(del, StringSplitOptions.None).Count();
            //for (int i = 0; i < count2 - count1; i++)
            //{
            //    richTextBox1.Rtf += "\n";
            //}
            //for (int i = 0; i < count1 - count2; i++)
            //{
            //    richTextBox2.Rtf += "\n";
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TitleList.Add(new Title());
            ShowTitles();

        }
    }
}
