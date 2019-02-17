using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskEst
{
    public partial class Form1 : Form
    {
        public UC SelectedUC = null;
        public SyoTask DoingSyoTask = null;

        public string BottomStr = string.Empty;
        public List<DaiTask> TaskList = new List<DaiTask>();
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
            public double Performance = 0;
            public bool Complete;
        }

        public enum UcType
        {
            Header,
            DaiTask,
            SyoTask
        }

        public class ForSaveLoad
        {
            public List<DaiTask> list;
            public string bot;
        }

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            //ヘッダー

            RefreshView();

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
            flowLayoutPanel1.Controls.Clear();

            foreach (DaiTask dai in TaskList)
            {
                flowLayoutPanel1.Controls.Add(CreateUC(UcType.DaiTask, dai));
                foreach (SyoTask syo in dai.syoList)
                {
                    flowLayoutPanel1.Controls.Add(CreateUC(UcType.SyoTask, syo));
                }
            }
            richTextBox1.Text = BottomStr;
            Form1_SizeChanged(this, null);
        }

        private UC CreateUC(UcType type, object data)
        {
            UC uc = new UC(type, data);
            return uc;
        }

        private void button1_Click(object sender, EventArgs e)
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





        private void timer1_Tick(object sender, EventArgs e)
        {
            SaveData();

            if (DoingSyoTask == null)
            {
                MessageBox.Show("実行中の小項目を選択してください。");
                return;
            }
            DoingSyoTask.Performance +=  ((1.0/60.0/60.0)*(timer1.Interval/1000));
            RefreshView();
        }







        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // 何もしない
            // base.OnPaintBackground(pevent);
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
            if (d == null)
            {
                foreach (DaiTask dai in TaskList)
                {
                    if (dai.syoList.Contains(s))
                    {
                        dai.syoList.Remove(s);
                    }
                }
            }
            else
            {
                TaskList.Remove(d);
            }

            RefreshView();

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int w = flowLayoutPanel1.Width - 5;
            foreach (Control con in flowLayoutPanel1.Controls)
            {
                con.Width = w;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            BottomStr = richTextBox1.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }
    }
}