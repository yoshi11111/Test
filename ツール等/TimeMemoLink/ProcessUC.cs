

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static TimeMemoLink.Form1;

namespace TimeMemoLink
{
    public partial class ProcessUC : UserControl
    {
        Process p;
        public ProcessData pd;
        public ProcessUC(ProcessData pda)
        {
            InitializeComponent();
            pd = pda;
            label1.Text = pd.fileName;
            comboBox1.Items.AddRange(new string[] { "1", "2", "3" });
            comboBox1.SelectedIndex = 0;
            if (comboBox1.Items.Contains("" + pda.Prio))
            {
                comboBox1.SelectedItem = "" + pda.Prio;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //p = Process.Start(pd.fullPath);
                //p.WaitForInputIdle();
                if (p == null || p.HasExited)
                {
                    // 共有ファイルなどを直接開くのは危険なため、新規で開くorフォルダを開く



                    p = Process.Start(System.IO.Path.GetDirectoryName(pd.fullPath));
                    p.WaitForInputIdle();
                }
                else
                {
                    SetForegroundWindow(p.MainWindowHandle);
                    const uint SW_RESTORE = 0x09;
                    ShowWindow(p.MainWindowHandle, SW_RESTORE);
                }

            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).RemovePUC(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1 form;
            if ((form = this.ParentForm as Form1) == null)
            {
                return;
            }


            int tmp;
            if (int.TryParse(comboBox1.SelectedItem == null ? "" : comboBox1.SelectedItem.ToString(), out tmp))
            {
                pd.Prio = tmp;
                form.PDataList[form.PDataList.IndexOf(pd)].Prio = tmp;


            }

            form.PDataList = (from a in form.PDataList
                              orderby a.Prio descending
                              select a).ToList();
            form.RefreshFolderLink();

        }
    }
}





