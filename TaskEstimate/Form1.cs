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

namespace TaskEst
{
    public partial class Form1 : Form
    {


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
        public List<DaiTask> TaskList = new List<DaiTask>();
        public List<SharedInfo> SharedInfoList = new List<SharedInfo>();


        public string BottomStr = string.Empty;

        public UC SelectedUC = null;
        public class DaiTask
        {
            public int ID = 1;
            public int Priority { get; set; } = 5;
            public string Task { get; set; } = string.Empty;
            public List<SyoTask> syoList = new List<SyoTask>();
            public bool Complete = false;
        }
        public class SyoTask
        {
            public int ID = 1;
            public int Priority { get; set; } = 5;
            public string Task { get; set; } = string.Empty;
            public double Estimate = 0;
            public bool Complete;
        }
        public class SharedInfo
        {
            public int ID = 1;
            public int Priority { get; set; } = 5;
            public string Task { get; set; } = string.Empty;
            public double Estimate = 0;
            public bool Complete;
        }
        public enum UcType
        {
            Header,
            DaiTask,
            SyoTask,
            Share
        }

        public class ForSaveLoad
        {
            public List<DaiTask> list;
            public string bot;
            public List<ProcessData> pdataList;
            public List<SharedInfo> sharedInfoList;
        }

        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            //ヘッダー

            RefreshView();
            ReViewGrid();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        public void RefreshView()
        {
            //ソート
            foreach (DaiTask d in TaskList)
            {
                d.syoList = (from ss in d.syoList
                             orderby ss.Complete, ss.Priority descending, ss.ID descending
                             select ss).ToList();
            }
            TaskList = (from tt in TaskList
                        orderby tt.Complete, tt.Priority descending, tt.ID descending
                        select tt).ToList();
            // 描画
            FLP1.Controls.Clear();

            foreach (DaiTask dai in TaskList)
            {
                FLP1.Controls.Add(CreateUC(UcType.DaiTask, dai));
                foreach (SyoTask syo in dai.syoList)
                {
                    FLP1.Controls.Add(CreateUC(UcType.SyoTask, syo));
                }
            }
            richTextBox1.Text = BottomStr;
            FLP1_Resize(null, null);

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


        private UC CreateUC(UcType type, object data)
        {
            UC uc = new UC(type, data);
            //     uc.Anchor = AnchorStyles.Right | AnchorStyles.Left| AnchorStyles.Top;
            //                        uc.Anchor = AnchorStyles.Top;
            //uc.Dock = DockStyle.Top;
            return uc;
        }

        private void btnDai_Click(object sender, EventArgs e)
        {
            DaiTask dai = new DaiTask();
            if (0 < TaskList.Count)
            {
                dai.ID = (from d in TaskList
                          select d.ID).Max() + 1;
            }
            TaskList.Add(dai);
            RefreshView();



        }
        private void btnSyo_Click(object sender, EventArgs e)
        {
            UC uc = SelectedUC;
            if (uc == null)
            {
                return;
            }
            int idx = TaskList.IndexOf(uc.dai);
            if (idx < 0)
            {
                return;
            }
            SyoTask syo = new SyoTask();
            if (0 < uc.dai.syoList.Count)
            {
                syo.ID = (from s in uc.dai.syoList
                          select s.ID).Max() + 1;
            }
            TaskList[idx].syoList.Add(syo);
            RefreshView();
        }









        #region xml書込読込
        private static readonly string FolderName = Environment.CurrentDirectory + @"\";
        private static readonly string FileName = "TaskData.xml";
        private static readonly string BakFileName = DateTime.Today.ToString("yyyyMMdd") + "Data.xml";


        public void SaveData()
        {
            string[] fileNames = new string[]{
            FolderName + FileName,
            FolderName + BakFileName };


            ForSaveLoad f = new ForSaveLoad();
            f.list = TaskList;
            f.bot = BottomStr;
            f.pdataList = PDataList;
            f.sharedInfoList = SharedInfoList; 
            try
            {
                foreach (string fileName in fileNames)
                {
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        fileName, false, new System.Text.UTF8Encoding(false));
                    serializer.Serialize(sw, f);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void LoadData()
        {
            string fileName = FolderName + FileName;

            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                ForSaveLoad obj = (ForSaveLoad)serializer.Deserialize(sr);
                sr.Close();
                this.TaskList = obj.list;
                this.BottomStr = obj.bot;
                this.PDataList = obj.pdataList;
                this.SharedInfoList = obj.sharedInfoList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        public void DeleteThis(UC uc)
        {
            DaiTask d = uc.dai;
            SyoTask s = uc.syo;
            SharedInfo si = uc.shared;
            if (d != null)
            {
                TaskList.Remove(d);
                RefreshView();

                return;
            }
            if (s != null)
            {
                foreach (DaiTask dai in TaskList)
                {
                    if (dai.syoList.Contains(s))
                    {
                        dai.syoList.Remove(s);
                    }
                }
                RefreshView();

                return;
            }
            if (si != null)
            {
                SharedInfoList.Remove(si);
                ReViewGrid();
                return;

            }


        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveData();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            BottomStr = richTextBox1.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
            e.Cancel = true;
        }

        private void flowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
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

        private void flowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            SharedInfoList.Add(new SharedInfo());
            ReViewGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReViewGrid();
        }
        private void ReViewGrid()
        {
            //ソート
            
            SharedInfoList = (from tt in SharedInfoList
                             orderby tt.Complete, tt.Priority descending, tt.ID descending
                        select tt).ToList();
            // 描画
            FLP2.Controls.Clear();

            foreach (SharedInfo syo in SharedInfoList)
            {
                FLP2.Controls.Add(CreateUC(UcType.Share, syo));
            }
            FLP2_Resize(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void FLP1_Resize(object sender, EventArgs e)
        {
            int w = FLP1.Width - 8;
            foreach (Control con in FLP1.Controls)
            {
                con.Width = w;
            }
        }

        private void FLP2_Resize(object sender, EventArgs e)
        {
            int w = FLP2.Width - 8;
            foreach (Control con in FLP2.Controls)
            {
                con.Width = w;
            }
        }

       
    }
}