using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manual.DataMng;

namespace Manual
{
    #region Form1

    public partial class Form1 : Form
    {
        public static Title currentTitle;


        private string[] del = { "\n" };


        public Form1()
        {
            InitializeComponent();
        }

        bool closeOpe = false;
        private void setComponents()
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Icon = Properties.Resources.app;

            icon.Visible = true;
            icon.Text = "常駐アプリテスト";
            icon.Click += new EventHandler(ShowForm);
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem menuItem2 = new ToolStripMenuItem();
            menuItem2.Text = "&exit";
            menuItem2.Click += new EventHandler(Close_Click);
            menu.Items.Add(menuItem2);
            icon.ContextMenuStrip = menu;
        }
        private void ShowForm(object sender, EventArgs e)
        {
            this.Visible = true;
            this.BringToFront();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            SaveData();
            closeOpe = true;
            Application.Exit();
        }

        public delegate void Clickded();
        int textBoxCnt = 10;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.setComponents();

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
            SearchWord(true);

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
            panel1.SuspendLayout();
            currentTitle = null;
            foreach (Title ttl in DataMng.TitleList)
            {
                TitleUC tb = new TitleUC(ttl);
                tb.textBox1.Click += TBClicked;
                tb.Dock = DockStyle.Top;
                panel1.Controls.Add(tb);
            }
            panel1.ResumeLayout();

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackColorClear();
            DataMng.SaveData();

            if (!closeOpe)
            {
                e.Cancel = true;

            }
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BackColorClear();
            new OutputUtil().WordExport();
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

        private void BackColorClear(bool onlyRichBox = false)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionBackColor = Color.White;
            if (onlyRichBox)
            {
                return;
            }
            foreach (TitleUC uc in panel1.Controls)
            {
                uc.textBox1.BackColor = Color.White;
            }
            


        }

        private void SearchWord(bool onlyRichBox = false)
        {
            BackColorClear(onlyRichBox);
            string word = TbSrc.Text;
            if (string.IsNullOrEmpty(word.Trim()))
            {
                return;
            }
            System.IO.StringReader rs = new System.IO.StringReader(richTextBox1.Text);
            //ストリームの末端まで繰り返す
            while (rs.Peek() > -1)
            {
                string line = rs.ReadLine();
                int wordIdx = line.IndexOf(word);
                if (wordIdx < 0)
                {
                    continue;
                }
                int lineIdx = richTextBox1.Text.IndexOf(line);
                richTextBox1.SelectionStart = lineIdx + wordIdx;
                richTextBox1.SelectionLength = word.Length;
                richTextBox1.SelectionBackColor = Color.Yellow;


            }
            if (onlyRichBox)
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
                    uc.textBox1.BackColor = Color.Yellow;
                }
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

        private void TbSrc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchWord();
        }
    }

    #endregion





































    #region DataMng

    public static class DataMng
    {
        public static List<Title> TitleList = new List<Title>();
        public class Title
        {
            public int Sort = 1;
            public string Text = string.Empty;
            public string Rtf = string.Empty;
        }
        public static readonly string FolderName = @"C:\Data\";
        public static readonly string FileName = "Data.xml";
        public static readonly string BakFileName = DateTime.Today.ToString("yyyyMMdd") + "Data.xml";

        public class ForSaveLoad
        {
            public List<Title> List;
        }


        public static void SaveData()
        {
            string[] fileNames = new string[]{
            FolderName + FileName,
            FolderName + BakFileName };



            ForSaveLoad f = new ForSaveLoad();
            f.List = TitleList;

            try
            {
                foreach (string fileName in fileNames)
                {
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        fileName, false, new System.Text.UTF8Encoding(false)))
                    {
                        serializer.Serialize(sw, f);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void LoadData()
        {
            string fileName = FolderName + FileName;
            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                using (System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false)))
                {
                    ForSaveLoad obj = (ForSaveLoad)serializer.Deserialize(sr);
                    sr.Close();
                    TitleList = obj.List;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

    }

    #endregion

}