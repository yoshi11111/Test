using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSt
{
    public partial class Form1 : Form
    {
        bool closeOpe = false;

        public class DT
        {
            public string time = "";
            public string plan = "";
            public string perfor = "";
            public int HH = 0;
        }


        public List<DT> dataList = null;

        List<UserControl1> ucList = new List<UserControl1>();

        public Form1()
        {
            InitializeComponent();
            LoadData();
            if (dataList == null)
            {
                dataList = new List<DT>();
                for (int i = 9; i < 21; i++)
                {
                    DT dt = new DT();
                    dt.time = (i) + ":00" + " ～ " + (i + 1) + ":00";
                    dt.HH = i;
                    if (i == 12)
                    {
                        dt.plan = "昼休み";
                        dt.perfor = "―";

                    }
                    if (i == 16)
                    {
                      //  dt.plan = "夕会準備";

                    }


                    dataList.Add(dt);
                }
            }
            int idx = 0;
            foreach (DT dt in dataList)
            {
                UserControl1 uc = new UserControl1(dt);
                uc.予定.TextChanged += UcTextChanged;
                uc.予定.Tag = idx;
                flowLayoutPanel1.Controls.Add(uc);
                idx++;
                ucList.Add(uc);

            }
            ChangeBackColor();
            rtopChange();
        }

        private void UcTextChanged(Object sender, EventArgs e)
        {



            rtopChange((RichTextBox)sender);
        }


        private void rtopChange(RichTextBox rc = null)
        {
            int curHOur = DateTime.Now.Hour;
            if (rc != null)
            {
               
                if ((int)rc.Tag == (curHOur - 9))
                {
                    rtop.Text = rc.Text;
                }

            }
            else
            {
                foreach(UserControl1 uc in ucList)
                {
                    if (uc.HH== curHOur)
                    {
                        rtop.Text =uc.予定.Text;
                    }






                }






            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  this.ShowInTaskbar = true;
            this.setComponents();
            timer1.Enabled = true;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;
            Form1_SizeChanged(null, null);
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


        public void ChangeText(object sender, EventArgs e)
        {
            if (currentUc == null)
            {
                return;
            }

            string cul;
            if (sender == rtop)
            {
                currentUc.予定.Text = rtop.Text;
            }
            else
            {
                rtop.Text = currentUc.予定.Text;
            }

        }


        public UserControl1 currentUc = null;

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
//            string lbl = (dt.Hour + 1) + "時まで残り   " + (59 - dt.Minute) + ":" + (59 - dt.Second) + "";


            label1.Text = "残り"+ (59 - dt.Minute) + ":" + (59 - dt.Second) + "";

            label3.Text= "("+(dt.Hour + 1) +"時まで)";
            //            if (dt.Second == 0 && dt.Minute == 0)
            if (dt.Second == 0 && dt.Minute == 0)
            {
                try
                {

                    this.WindowState = FormWindowState.Minimized;
                    this.WindowState = FormWindowState.Normal;
                    this.Focus();
                    this.TopMost = true;
                }
                catch
                {

                }
                MessageBox.Show("実績と予定を入力");

                SaveData();
                rtopChange();
                //ShowInputPerfor();
                //Recode();
                //ShowInputPl();
            }
        }
        private void ChangeBackColor()
        {
            int currentIdx = DateTime.Now.Hour - 9;
            
            foreach(UserControl1 uc in ucList)
            {
            
                int ucIdx= (int)uc.予定.Tag;

                if (ucIdx + 9 == 12)
                {
                    uc.BackColor = Color.LightYellow;

                }
                else if (ucIdx + 9 > 17)
                {

                    uc.BackColor = Color.Blue;
                    uc.label1.ForeColor = Color.White;

                }
                else
                {
                    uc.BackColor = Color.White;

                }




                if (((int)uc.予定.Tag) < currentIdx)
                {
                    uc.BackColor = Color.LightGray;
                }


            }


        }





        #region xml書込読込

        public static readonly string FolderName = Environment.CurrentDirectory + @"\";
        public static readonly string FileN = DateTime.Today.ToString("yyyyMMdd") + "TimeData.xml";

        public class ForSaveLoad
        {
            public List<DT> dataList = new List<DT>();
            public string RichText = string.Empty;
        }

        public void SaveData()
        {
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                UserControl1 uc = flowLayoutPanel1.Controls[i] as UserControl1;
                if (uc == null)
                {
                    continue;
                }
                try
                {
                    if (!string.IsNullOrEmpty(uc.予定.Text))
                    {
                        dataList[i].plan = uc.予定.Text;
                    }

                }
                catch
                {
                    dataList[i].plan = "";

                }
                dataList[i].perfor = uc.実績.Text;

            }

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
            f.dataList = dataList;
            f.RichText = richTextBox1.Text;



            try
            {
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
                dataList = obj.dataList;
                richTextBox1.Text = obj.RichText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control con in flowLayoutPanel1.Controls)
            {

                con.Width = flowLayoutPanel1.Width - 25;

            }
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



