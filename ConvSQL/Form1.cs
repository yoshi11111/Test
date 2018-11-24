using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // テーブル定義の＊列を日本語名、＊列を物理名として取り込み
            InitRT();


        }

        public static Dictionary<string, string> JPAndValueDic = new Dictionary<string, string>()
        {
            {  "製品コード", "BHCD" },

            {  "製品テーブル", "SHN" },
            {  "値段", "PRC" },
            {  "在庫", "ZKS" },

        };



        private void btnCvt_Click(object sender, EventArgs e)
        {
            string sql = rtSQL.Text;
            string after = sql;
            foreach (KeyValuePair<string, string> kvp in JPAndValueDic)
            {
                if (checkBox1.Checked)
                {
                    after = after.Replace(kvp.Key, kvp.Value);
                }
                else
                {
                    after = after.Replace(kvp.Value, kvp.Key);

                }

            }

            rtSQL.Text = after;



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string jp = string.Empty;
            string ph = string.Empty;
            if (!IsValidTb(tbJP, ref jp))
            {
                return;
            }
            if (!IsValidTb(tbPh, ref ph))
            {
                return;
            }

            JPAndValueDic[jp] = ph;

        }

        private bool IsValidTb(TextBox tb, ref string value)
        {
            tb.BackColor = Color.White;
            value = tb.Text.Trim();
            if (string.IsNullOrEmpty(value)  || value.Contains("\"") || value.Contains("\'") || value.Contains(","))
            {
                tb.BackColor = Color.LightGray;
                return false;
            }

            return true;
        }

        



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rtSQL_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitRT();
        }

        private void InitRT()
        {
            string initSQL = "select * " + Environment.NewLine +
               "from " + Environment.NewLine +
               "where " + Environment.NewLine +
               "";
            rtSQL.Text = initSQL;


        }

        private void btnSv_Click(object sender, EventArgs e)
        {
            Util.Write();
        }

        private void btnRd_Click(object sender, EventArgs e)
        {
            Util.Read();
        }
    }
}
