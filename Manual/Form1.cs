using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manual.DataMng.Mdl;

namespace Manual
{
    public partial class Form1 : Form
    {
        public Title currentTitle = null;


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
            panel2.Controls.Clear();
            if (currentTitle == null)
            {
                return;
            }
            ItemUC uc;
            foreach (MajorItem major in currentTitle.items)
            {
                uc = new ItemUC(currentTitle, major);
                uc.Dock = DockStyle.Top;

                panel2.Controls.Add(uc);


                foreach (MiddleItem middle in major.items)
                {
                    uc = new ItemUC(major, middle);
                    uc.Dock = DockStyle.Top;

                    uc.Padding = new Padding(50, 0, 0, 0);
                    panel2.Controls.Add(uc);
                    foreach (SmallItem small in middle.items)
                    {
                        uc = new ItemUC(middle, small);
                        uc.Dock = DockStyle.Top;

                        uc.Padding = new Padding(100, 0, 0, 0);
                        uc.SetSmallItemProperty();
                        panel2.Controls.Add(uc);

                    }
                   

                }
                
            }
        }


        public void ShowTitles()
        {
            panel1.Controls.Clear();
            currentTitle = null;
            foreach (Title ttl in DataMng.TitleList)
            {
                TitleUC tb = new TitleUC(ttl);
                tb.richTextBox1.Click += TBClicked;
                tb.button1.Click += TBClicked;
                tb.Dock = DockStyle.Top;
                panel1.Controls.Add(tb);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataMng.SaveData();
        }
    }
}
