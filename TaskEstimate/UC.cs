using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TaskEst.Form1;

namespace TaskEst
{
    public partial class UC : UserControl
    {
        public DaiTask dai = null;
        public SyoTask syo = null;
        public UcType type;

        private const int LatingMin = 1;
        private const int LatingMax = 5;



        public UC(UcType tp, object data)
        {
            InitializeComponent();
            dai = data as DaiTask;
            syo = data as SyoTask;
            type = tp;
        }


        private void UC_Load(object sender, EventArgs e)
        {
            RefreshView();
        }
        public void RefreshView()
        {
            switch (type)
            {
                case UcType.DaiTask:
                    SetCombo();
                    comboBox1.SelectedText = ("" + dai.Priority);
                    tbTask.Text = dai.Task;
                    tbEstimate.Text = (from s in dai.syoList
                                       select s.Estimate).Sum() + "";
                    tbPerformance.Text = (from s in dai.syoList
                                          select s.Performance).Sum() + "";
                    checkBox1.Checked = dai.Complete;

                    if (checkBox1.Checked)
                    {
                        this.BackColor = Color.Gray;
                    }
                    btnDoing.Enabled = false;

                    break;
                case UcType.SyoTask:
                    SetCombo();
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    comboBox1.SelectedText = ("" + syo.Priority);
                    tbTask.Text = syo.Task;
                    tbEstimate.Text = syo.Estimate + "";
                    tbPerformance.Text = syo.Performance + "";
                    checkBox1.Checked = syo.Complete;
                    Form1 form = this.ParentForm as Form1;
                    if (form.DoingSyoTask == syo)
                    {
                        btnDoing.BackColor = Color.Red;
                    }
                    if (checkBox1.Checked)
                    {
                        this.BackColor = Color.Gray;
                    }

                    break;
            }
        }

        private void SetCombo()
        {
            for (int i = LatingMin; i <= LatingMax; i++)
            {
                comboBox1.Items.Add("" + i);
            }
        }

        private Label CreateLabel(string txt)
        {
            Label lb = new Label();
            using (lb.Font)
            {
                lb.Font = new Font("メイリオ", 10, FontStyle.Bold);
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = txt;

            }
            return lb;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("タスクを削除しますか？",
    "",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }

            Form1 form = this.ParentForm as Form1;
            form.DeleteThis(this);


        }

        private void UC_Enter(object sender, EventArgs e)
        {
            Form1 form = this.ParentForm as Form1;
            if (form != null)
            {
                form.SelectedUC = this;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVal(sender);

        }
        private void tbTask_TextChanged(object sender, EventArgs e)
        {
            SetVal(sender);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetVal(sender);
        }
        private void tbEstimate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
         
        }
        private void SetVal(object sender)
        {
            switch (type)
            {
                case UcType.DaiTask:
                    if (sender == comboBox1)
                    {
                        if (0 <= comboBox1.SelectedIndex)
                        {
                            dai.Priority = int.Parse(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                        }
                    }
                    if (sender == tbTask)
                    {
                        dai.Task = tbTask.Text;
                    }
                    if (sender == checkBox1)
                    {
                        dai.Complete = checkBox1.Checked;
                        if (dai.Complete)
                        {
                            foreach (SyoTask ss in dai.syoList)
                            {
                                ss.Complete = checkBox1.Checked;
                            }
                        }

                    }
                    break;
                case UcType.SyoTask:
                    if (sender == comboBox1)
                    {
                        if (0 <= comboBox1.SelectedIndex)
                        {
                            dai.Priority = int.Parse(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                        }
                    }
                    if (sender == tbTask)
                    {
                        syo.Task = tbTask.Text;
                    }
                    if (sender == checkBox1)
                    {
                        syo.Complete = checkBox1.Checked;
                    }
                    if (sender == tbEstimate)
                    {
                        syo.Estimate = double.Parse(tbEstimate.Text);
                    }
                    if (sender == checkBox1)
                    {
                        syo.Complete = checkBox1.Checked;

                    }
                    break;

            }

        }



        private void btnDoing_Click(object sender, EventArgs e)
        {
            Form1 form = this.ParentForm as Form1;
            if (form != null)
            {
                form.DoingSyoTask = syo;
                form.RefreshView();
            }


        }

        private void tbEstimate_TextChanged(object sender, EventArgs e)
        {
            SetVal(sender);
        }
    }
}
