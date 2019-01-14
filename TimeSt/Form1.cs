using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSt
{
    public partial class Form1 : Form
    {
        bool closeOpe = false;

        public Form1()
        {
            InitializeComponent();
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
        }


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
        }

        private void Close_Click(object sender, EventArgs e)
        {
            closeOpe = true;
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeOpe)
            {

            }
            else
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            this.TopMost = this.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string lbl = "残り: "+(60 - dt.Minute) + ":" + (60 - dt.Second);
            label1.Text = lbl;
            if (dt.Second == 0 && dt.Minute == 0)
            {
                //ShowInputPerfor();
                //Recode();
                ShowInputPl();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowInputPl();
        }
        private void ShowInputPl()
        {
            using (InputPl inp = new InputPl())
            {
                try
                {
                    inp.TopMost = true;
                    inp.ShowDialog();

                    richTextBox1.Text = inp.InpunStr;

                }
                catch { }
            }
        }
    }
}
