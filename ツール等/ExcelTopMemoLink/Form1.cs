﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelTopMemoLink;

namespace ExcelTopMemoLink
{
    public partial class Form1 : Form
    {
        bool closeOpe = false;

        [DllImport("user32.dll")]
        // ウインドウ検索メソッド（第一引数：クラス名、第二引数：ウインドウタイトル）
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        // SetParent 関数
        [DllImport("USER32.DLL", CharSet = CharSet.Auto)]
        private static extern System.IntPtr SetParent(
            System.IntPtr hWndChild,
            System.IntPtr hWndNewParent
        );

        public Form1()
        {
            InitializeComponent();
            LoadData();
            //   RefreshTaskList();
            RefreshFolderLink();
            InitializeMemoPage();
            this.Opacity = 0.8;


        }
        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0X4;
        const int SWP_SHOWWINDOW = 0x0040;
        private void button3_Click(object sender, EventArgs e)
        {
            // Excel起動
            Process pr = Process.Start(textBox1.Text);
            pr.WaitForInputIdle();


            IntPtr handle = FindWindow("XLMAIN", "Microsoft Excel - タスク分割.xlsx");

            //画面座標(100, 200)を、フォーム上のクライアント座標に変換する
            Point cp = this.PointToClient(new Point(this.Left, this.Top));
            try
            {
                //フォーム上のクライアント座標(10, 20)を、画面座標に変換する
                Point sp = this.PointToScreen(new Point(this.Left, this.Top));

                foreach (Process p in Process.GetProcesses())
                {
                    if (p.MainWindowTitle == "Microsoft Excel - タスク分割.xlsx")
                    {
                        string str = p.ProcessName;

                    }
                }

                SetParent(handle, panelDock.Handle);


            }
            catch (Exception eee)
            {
                string a = eee.ToString();
            }

        }




        #region タスクページ
        public class DayTask
        {
            public string time = "";
            public string plan = "";
            public string perfor = "";
            public int HH = 0;

        }

        public class WholeTask
        {
            public string yyyymmdd;
            public List<DayTask> dayTaskList = new List<DayTask>();
        }



        public List<WholeTask> WholeTaskList = new List<WholeTask>();

        List<TaskUC> ucList = new List<TaskUC>();



        DateTime TaskViewDate = DateTime.Today;
        private void btnL_Click(object sender, EventArgs e)
        {
            SaveData();
            TaskViewDate = TaskViewDate.AddDays(-1);
            //     RefreshTaskList();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            SaveData();

            TaskViewDate = TaskViewDate.AddDays(1);

            //      RefreshTaskList();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //  this.ShowInTaskbar = true;
            this.setComponents();
            //    timer1.Enabled = true;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;
            //    Form1_SizeChanged(null, null);
            this.TopMost = true;

        }


        private void setComponents()
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Icon = Properties.Resources.app;

            icon.Visible = true;
            icon.Text = "常駐アプリ";
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
            // this.Visible = !this.Visible;
        }
        private void SaveClicked(object sender, EventArgs e)
        {
            this.Opacity -= 0.15;
            if (this.Opacity < 0.16)
            {
                this.Opacity = 1;
            }

        }


        private void Close_Click(object sender, EventArgs e)
        {
            SaveData();
            closeOpe = true;
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
            if (!closeOpe)
            {
                e.Cancel = true;

            }
        }

        public TaskUC currentUc = null;

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {

        }


        #endregion

        #region ファイルリンクページ

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hWnd, uint Msg);


        public class ProcessData
        {
            public string fullPath;
            public string fileName;
            public int Prio = 1;
        }
        public List<ProcessData> PDataList = new List<ProcessData>();




        public void RefreshFolderLink()
        {

            // 描画
            FLP3.Controls.Clear();
            // flow2の描画
            foreach (ProcessData pd in PDataList)
            {
                AddPUC(pd);

            }


        }
        private void AddPUC(ProcessData pd)
        {
            ProcessUC puc = new ProcessUC(pd);

            //  puc.Dock = DockStyle.Top;
            FLP3.Controls.Add(puc);
            FLP3_Resize(null, null);
        }


        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FLP3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FLP3_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < files.Length; i++)
            {
                string fPath = files[i];
                int cnt = (from dt in PDataList
                           where dt.fullPath == fPath
                           select dt).ToList().Count();
                if (0 < cnt)
                {
                    continue;
                }

                ProcessData pd = new ProcessData();
                pd.fullPath = files[i];
                pd.fileName = pd.fullPath.Substring(pd.fullPath.LastIndexOf(@"\") + 1);
                AddPUC(pd);
                PDataList.Add(pd);
            }
        }
        private void FLP3_Resize(object sender, EventArgs e)
        {
            int w = FLP3.Width - 10;
            foreach (Control con in FLP3.Controls)
            {
                con.Width = w;
            }
        }
        public void RemovePUC(ProcessUC uc)
        {
            try
            {
                PDataList.Remove(uc.pd);
                FLP3.Controls.Remove(uc);



            }
            catch { }


        }


        #endregion

        #region メモページ

        public static Title currentTitle;


        public class Title
        {
            public int Sort = 1;
            public string Text = string.Empty;
            public string Rtf = string.Empty;
        }

        public static List<Title> TitleList = new List<Title>();



        private string[] del = { "\n" };


        public delegate void Clickded();
        int textBoxCnt = 10;


        private void TBClicked(object sender, EventArgs e)
        {

            MemoTitleUC uc = ((Control)sender).Parent.Parent as MemoTitleUC;
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
            TitleList = (from itm in TitleList
                         orderby itm.Sort
                         select itm).ToList();
            PnlMemoPage.Controls.Clear();
            PnlMemoPage.SuspendLayout();
            currentTitle = null;
            foreach (Title ttl in TitleList)
            {
                MemoTitleUC tb = new MemoTitleUC(ttl);
                tb.textBox1.Click += TBClicked;
                tb.Dock = DockStyle.Left;
                tb.sortchangedDelegate = ShowTitles;
                PnlMemoPage.Controls.Add(tb);
            }
            PnlMemoPage.ResumeLayout();

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
            foreach (MemoTitleUC uc in PnlMemoPage.Controls)
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

            foreach (MemoTitleUC uc in PnlMemoPage.Controls)
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
        private void InitializeMemoPage()
        {
            if (TitleList == null || TitleList.Count == 0)
            {
                TitleList = new List<Title>();
                for (int i = 0; i < textBoxCnt; i++)
                {
                    TitleList.Add(new Title());
                }
            }

            ShowTitles();
            ShowItems();
        }


        #endregion

        #region xml書込読込

        public static readonly string FolderName = Environment.CurrentDirectory + @"\";
        public static readonly string FileN = "TaskMemoFolderData.xml";

        public class ForSaveLoad
        {
            public List<WholeTask> wholeTaskList = new List<WholeTask>();
            public List<Title> tileList = new List<Title>();

            public List<ProcessData> pdataList;

        }

        public void SaveData()
        {

            try
            {
                WholeTask wt = (from w in WholeTaskList
                                where w.yyyymmdd == TaskViewDate.ToString("yyyyMMdd")
                                select w).First();
                int idx = WholeTaskList.IndexOf(wt);

                string fileName = FolderName + FileN;

                // バックアップ作成
                for (int i = 5; 0 < i; i--)
                {
                    try
                    {
                        string file = fileName + i;
                        string dist = fileName + (i + 1);
                        if (File.Exists(dist))
                        {
                            File.Delete(dist);
                        }
                        if (!(1 == i))
                        {
                            File.Move(file, dist);
                        }
                        else
                        {
                            file = fileName;
                            File.Copy(file, dist);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }

                ForSaveLoad f = new ForSaveLoad();
                f.wholeTaskList = WholeTaskList;
                f.pdataList = PDataList;
                f.tileList = TitleList;


                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                serializer.Serialize(sw, f);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void LoadData()
        {
            string fileName = FolderName + FileN;

            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                ForSaveLoad obj = (ForSaveLoad)serializer.Deserialize(sr);
                sr.Close();
                WholeTaskList = obj.wholeTaskList;
                this.PDataList = obj.pdataList;
                TitleList = obj.tileList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        #endregion


        private void tabControl1_Resize(object sender, EventArgs e)
        {

        }


    }
}



