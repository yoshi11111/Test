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
            SearchWord();

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
            BackColorClear();
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
            SearchWord();

        }
        private void BackColorClear()
        {
            foreach (TitleUC uc in panel1.Controls)
            {
                uc.richTextBox1.BackColor = Color.White;
            }
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionBackColor = Color.White;


        }

        private void SearchWord()
        {
            BackColorClear();
            string word = TbSrc.Text;
            if (string.IsNullOrEmpty(word.Trim()))
            {
                return;
            }
            foreach (TitleUC uc in panel1.Controls)
            {
                Title ttl = uc.ttl;
                if (ttl == null)
                {
                    continue;
                }
                RichForSearch.Rtf = ttl.Rtf;
                if (MatchWord(word, RichForSearch.Text))
                {
                    uc.richTextBox1.BackColor = Color.Yellow;
                }
            }

            System.IO.StringReader rs = new System.IO.StringReader(richTextBox1.Text);
            //ストリームの末端まで繰り返す
            while (rs.Peek() > -1)
            {
                string line = rs.ReadLine();
                int idx = line.IndexOf(word);
                if (idx < 0)
                {
                    continue;
                }
                idx = richTextBox1.Text.IndexOf(line);
                richTextBox1.SelectionStart = idx;
                richTextBox1.SelectionLength = word.Length;
                richTextBox1.SelectionBackColor = Color.Yellow;


            }

        }


        private bool MatchWord(string word, string tgt)
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
