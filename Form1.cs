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
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //MoveWindow関数の宣言
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, int bRepaint);



        // 1画面分のデータモデル
        public class PanelData
        {
            public PanelData(Process pr, TabPage tp)
            {
                this.process = pr;
                this.ParentPage = tp;

            }


            public Process process { get; set; }
            public TabPage ParentPage { get; set; }
        }
        
        // タブ数分のデータを格納
        PanelData[] panelDataList = new PanelData[TabCount];

        // タブ数
        const int TabCount= 2;

        public Form1()
        {
            InitializeComponent();

        }


        public void ExecApp(string fileName, TabPage tabPage, int index)
        {
            // 起動
            Process p = Process.Start(fileName);

            // コンストラクタ
            PanelData pData = new PanelData(p, tabPage);

            // 親要素をセット
            //   SetParent(pData.process.Handle, pData.ParentPage.Handle);
            SetParent(p.Handle, tabPage1.Handle);

            // アイドル状態になるまで待機
            pData.process.WaitForInputIdle();

            // リストに追加
            panelDataList[index] = pData;

            // ウィンドウの位置を(0, 10)に、サイズを300x200に変更する
            SetTabContentsLocationAndSize();

        }

        // 全パネルコンテンツの位置とサイズ調整
        private void SetTabContentsLocationAndSize()
        {
            foreach (PanelData pData in panelDataList)
            {


               //  MoveWindow(pData.process.MainWindowHandle, , 0, pData.ParentPage.Width, pData.ParentPage.Height, 1);
                //pData.process.Width = pData.ParentPage.Width;


            }

        }


        private void tabPage1_DragDrop(object sender, DragEventArgs e)
        {
           

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string fileName
                            in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    ExecApp(fileName, tabPage1, 0);
                    break;
                }
            }

        }

        private void tabPage1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            SetTabContentsLocationAndSize();

        }
        
    }
}
