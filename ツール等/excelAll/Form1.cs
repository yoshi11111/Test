using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace エクセルテキスト全般検索
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            D d = SH;
            await Task.Run(() => { KK(d); });

        }

        public delegate void D();


        public void SH()
        {
            MessageBox.Show(textBox1.Text);
        }


        public void KK(D a)
        {
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                Task t = Task.Factory.StartNew(() => { asy(); });
                taskList.Add(t);
            }
            foreach (Task t in taskList)
            {
                t.Wait();

            }

            this.BeginInvoke(a, null);
        }

        public void asy()
        {
            Thread.Sleep(10000);

        }
    }
}
