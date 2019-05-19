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
        public SharedInfo shared = null;
        public UcType type;

        private const int LatingMin = 1;
        private const int LatingMax = 5;



        public UC(UcType tp, object data)
        {
            InitializeComponent();
            dai = data as DaiTask;
            syo = data as SyoTask;
            shared = data as SharedInfo;

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
                    checkBox1.Checked = dai.Complete;



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
                    checkBox1.Checked = syo.Complete;


                    break;
                case UcType.Share:
                    SetCombo();
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    comboBox1.SelectedText = ("" + shared.Priority);
                    tbTask.Text = shared.Task;
                    tbEstimate.Text = shared.Estimate + "";
                    checkBox1.Checked = shared.Complete;


                    break;
            }
            bool enable = !checkBox1.Checked;
            foreach (Control con in tableLayoutPanel1.Controls)
            {
                if (con is CheckBox)
                {
                    continue;
                }
                con.Enabled = enable;
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
                            syo.Priority = int.Parse(comboBox1.Items[comboBox1.SelectedIndex].ToString());
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
                case UcType.Share:
                    if (sender == comboBox1)
                    {
                        if (0 <= comboBox1.SelectedIndex)
                        {
                            shared.Priority = int.Parse(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                        }
                    }
                    if (sender == tbTask)
                    {
                        shared.Task = tbTask.Text;
                    }
                    if (sender == checkBox1)
                    {
                        shared.Complete = checkBox1.Checked;
                    }
                    if (sender == tbEstimate)
                    {
                        shared.Estimate = double.Parse(tbEstimate.Text);
                    }
                    if (sender == checkBox1)
                    {
                        shared.Complete = checkBox1.Checked;

                    }
                    break;
            }
            comboBox1.DropDownStyle = ComboBoxStyle.Simple;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
        }



        private void btnDoing_Click(object sender, EventArgs e)
        {
            Form1 form = this.ParentForm as Form1;
            if (form != null)
            {
                form.RefreshView();
            }


        }

        private void tbEstimate_TextChanged(object sender, EventArgs e)
        {
            SetVal(sender);
        }
    }
}





