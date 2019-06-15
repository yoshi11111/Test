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

            if (string.IsNullOrEmpty(currentTitle.Rtf))
            {
                richTextBox1.Text = string.Empty;
            }
            else
            {
                richTextBox1.Rtf = currentTitle.Rtf;
            }
        }


        public void ShowTitles()
        {
            DataMng.TitleList = (from itm in DataMng.TitleList
                                 orderby itm.Sort
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


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (currentTitle == null)
            {
                return;
            }
            currentTitle.Rtf = richTextBox1.Rtf;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TitleList.Add(new Title());
            ShowTitles();

        }



        private void FontChange(object sender, EventArgs e)
        {

            if (sender == BtnBlack)
            {
                richTextBox1.SelectionColor = Color.Black;
            }
            if (sender == BtnBlue)
            {
                richTextBox1.SelectionColor = Color.Blue;
            }
            if (sender == BtnRed)
            {
                richTextBox1.SelectionColor = Color.Red;
            }
            Font fnt = null;
            if (sender == BtnBold)
            {
                fnt = new Font(richTextBox1.Font.FontFamily,
                      richTextBox1.Font.Size,
                      richTextBox1.Font.Style | FontStyle.Bold);
                richTextBox1.SelectionFont = fnt;
            }
            if (sender == BtnUnder)
            {
                fnt = new Font(richTextBox1.Font.FontFamily,
                    richTextBox1.Font.Size,
                    richTextBox1.Font.Style | FontStyle.Underline);
                richTextBox1.SelectionFont = fnt;

            }
            if (sender == BtnClear)
            {
                fnt = new Font(richTextBox1.Font.FontFamily,
                    richTextBox1.Font.Size,
                    richTextBox1.Font.Style);
                richTextBox1.SelectionFont = fnt;

            }
            if (fnt != null)
            {
                fnt.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string word = TbSrc.Text;
            foreach (Title ttl in TitleList)
            {
                if(MatchWord(word, ttl.Text))
                {

                }
            }



        }

        private bool MatchWord(string word , string tgt)
        {
            string prevWord = word;

            if (tgt.IndexOf(word) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
