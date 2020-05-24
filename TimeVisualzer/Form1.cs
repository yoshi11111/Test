using System;
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


        // WindowsAPIのインポート
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern short GetKeyState(int nVirtKey);



        //============
        // タイマーで定期的に起動するイベントプロシージャ
        private void PressTimer_Tick(object sender, EventArgs e)
        {
            // 指定キー（Aキー）が押下されているのか確認
            bool Key_State1 = IsKeyLocked(System.Windows.Forms.Keys.Enter) ;
            bool Key_State2 = IsKeyLocked(System.Windows.Forms.Keys.Space);
            bool Key_State3 = IsKeyLocked(System.Windows.Forms.Keys.Back);

                     
            // Aキーが押下の場合
            if (Key_State1|| Key_State2|| Key_State3)
            {
                StringBuilder sb = new StringBuilder(65535);//65535に特に意味はない
                GetWindowText(GetForegroundWindow(), sb, 65535);
                KeyOnly = true;
                if (sb.ToString().Contains("ExcelTopMemoLink"))
                {

                    // Aキーが押下されていることをラベルに表示
                    VSPressed = true;
                }

            }
        }
        bool VSPressed = false;
        bool KeyOnly = false;
        
        //============
        // 指定キー押下状態調査メソッド
        // 指定のキーが押下状態か調査するメソッドです。
        // 第１引数: 調査対象のキーを示すKeys列挙体
        // 戻り値: 判定結果 true:押下 / false:非押下
        public bool IsKeyLocked(System.Windows.Forms.Keys Key_Value)
        {
            // WindowsAPIで押下判定
            bool Key_State = (GetKeyState((int)Key_Value) & 0x80) != 0;
            return Key_State;
        }


        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);




        public Form1()
        {
            InitializeComponent();
            LoadData();
            //   
            InitializeMemoPage();
            this.Opacity = 0.8;
            PressTimer.Interval = 200;
            PressTimer.Start();
            MinutesTimer.Interval = 5000; 
            MinutesTimer.Start();
            timer1.Interval = 1000;
            timer1.Start();

            RefreshTaskList();
        }

             

        DateTime now = DateTime.Now;
        private void RefreshTaskList()
        {
            flowLayoutPanel1.Controls.Clear();
            WholeTask whole = WholeTaskList.Where(m => m.yyyymmdd == now.ToString("yyyyMMdd")).FirstOrDefault();
            if (whole == null)
            {
                whole = new WholeTask();
                whole.dayTaskList = new List<DayTask>();
            
            }

            foreach (DayTask tsk in whole.dayTaskList)
            {
                TaskUC uc = new TaskUC(tsk);
                flowLayoutPanel1.Controls.Add(uc);
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
             //    RefreshTaskList();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now =DateTime.Now;
            if (now.Second == 0)
            {
             


            }
        }
        private void MinutesTimer_Tick(object sender, EventArgs e)
        {

            DayTask tsk = GetCurrentTask();
            if (VSPressed)
            {
                tsk.plan += "," + (int)TimeType.VSTypping;
            }
            else if (KeyOnly)
            {
                tsk.plan += "," + (int)TimeType.Typping;
            }
            else
            {
                tsk.plan += "," + (int)TimeType.None;
            }
            VSPressed = false;
            KeyOnly = false;
            RefreshTaskList();
        }

        private DayTask GetCurrentTask()
        {
            WholeTask tk = WholeTaskList.
                 Where(m => m.yyyymmdd == now.ToString("yyyyMMdd")).FirstOrDefault();
            if (tk == null)
            {
                tk = new WholeTask();
                tk.yyyymmdd = now.ToString("yyyyMMdd");
                tk.dayTaskList = new List<DayTask>();
                WholeTaskList.Add(tk);
            }

            DayTask s = tk.dayTaskList.Where(m => m.HH == now.Hour).FirstOrDefault();
            if (s == null)
            {
                s = new DayTask();
                s.HH = now.Hour;
                tk.dayTaskList.Add(s);
            }
            

                return s;
        }


        public enum TimeType
        {
            VSTypping=0,
            Typping=1,
            None=2
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



