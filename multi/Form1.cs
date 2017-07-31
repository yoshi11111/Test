using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace multiWindow
{
    public partial class Form1 : Form
    {

        //SetParent関数の宣言
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetParent(IntPtr hWndChild, IntPtr hWndParent);

        //GetParent関数の宣言
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr hWndChild);


        //MoveWindow関数の宣言
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, bool bRepaint);



        // ファイルパスリスト
        static readonly string[] filePathList = new string[]{
            @"C:\4.exe",
            @"C:\4.exe",
            @"C:\4.exe",
            @"C:\4.exe",
            @"C:\4.exe"
            };

        Process p1;
        Process p2;
        Process p3;
        Process p4;
        Process p5;




        public Form1()
        {
            InitializeComponent();

            ExecProcess();

        }

        

        private void ExecProcess()
        {
            if (p1 == null || p1.HasExited)
            {
                p1 = Exec(filePathList[0]);
            }
            if (p2 == null || p2.HasExited)
            {
                p2 = Exec(filePathList[1]);
            }
            if (p3 == null || p3.HasExited)
            {
                p3 = Exec(filePathList[2]);
            }
            if (p4 == null || p4.HasExited)
            {
                p4 = Exec(filePathList[3]);
            }
            if (p5 == null || p5.HasExited)
            {
                p5 = Exec(filePathList[4]);
            }





        }





        private System.Diagnostics.Process Exec(string item)
        {
            //メモ帳を起動
            System.Diagnostics.Process p =
                System.Diagnostics.Process.Start(item);
            //アイドル状態になるまで待機
            p.WaitForInputIdle();

            return p;


        }



        //private void tabPage1_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.All;
        //}

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            SetLocationAndSize();

        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            SetLocationAndSize();
        }

        public void SetLocationAndSize()
        {
            tableLayoutPanel1.Width = this.Width;
            tableLayoutPanel1.Height = this.Height;

            if (p1 != null && !(p1.HasExited))
            {
                MoveWindow(p1.MainWindowHandle, 0, 0, tabPage1.Width, tabPage1.Height, true);
            }
            if (p2 != null && !(p2.HasExited))
            {
                MoveWindow(p2.MainWindowHandle, 0, 0, tabPage2.Width, tabPage2.Height, true);
            }
            if (p3 != null && !(p3.HasExited))
            {
                MoveWindow(p3.MainWindowHandle, 0, 0, tabPage3.Width, tabPage3.Height, true);
            }
            if (p4 != null && !(p4.HasExited))
            {
                MoveWindow(p4.MainWindowHandle, 0, 0, tabPage4.Width, tabPage4.Height, true);
            }
            if (p5 != null && !(p5.HasExited))
            {
                MoveWindow(p5.MainWindowHandle, 0, 0, tabPage5.Width, tabPage5.Height, true);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p1 != null && !(p1.HasExited) && !(GetParent(p1.MainWindowHandle).Equals(tabPage1.Handle)))
            {
                SetParent(p1.MainWindowHandle, tabPage1.Handle);
            }
            if (p2 != null && !(p2.HasExited) && !(GetParent(p2.MainWindowHandle).Equals(tabPage2.Handle)))
            {
                SetParent(p2.MainWindowHandle, tabPage2.Handle);
            }
            if (p3 != null && !(p3.HasExited) && !(GetParent(p3.MainWindowHandle).Equals(tabPage3.Handle)))
            {
                SetParent(p3.MainWindowHandle, tabPage3.Handle);
            }
            if (p4 != null && !(p4.HasExited) && !(GetParent(p4.MainWindowHandle).Equals(tabPage4.Handle)))
            {
                SetParent(p4.MainWindowHandle, tabPage4.Handle);
            }
            if (p5 != null && !(p5.HasExited) && !(GetParent(p5.MainWindowHandle).Equals(tabPage5.Handle)))
            {
                SetParent(p5.MainWindowHandle, tabPage5.Handle);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            ExecProcess();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentTab = tabControl1.SelectedIndex;
            if (currentTab < tabControl1.TabCount-1)
            {
                currentTab++;
            }
            else
            {
                currentTab = 0;
            }
            tabControl1.SelectedIndex = currentTab;
        }
    }
}
