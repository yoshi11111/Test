using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeAssist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ////列の追加
            listView1.Columns.Add(
                "", 100, HorizontalAlignment.Left);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.HeaderStyle = ColumnHeaderStyle.None;


        }

        // 変数名
        public static List<string> vList = new List<string>();

        // 関数名
        public static List<string> fList = new List<string>();


        // コメント
        public static List<string> cList = new List<string>();


        private void btnFech_Click(object sender, EventArgs e)
        {

            string code = rtbCode.Text;

            AddVariableList(code, ref vList);

            AddFNameList(code, ref fList);


        }

        private void AddVariableList(string code, ref List<string> vList)
        {

            // 前後が半角スペースで、かつ途中にドットもかっこもない
            System.Text.RegularExpressions.Regex r =
                new System.Text.RegularExpressions.Regex(
                     @" [\w-]+ ",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //TextBox1.Text内で正規表現と一致する対象を1つ検索
            System.Text.RegularExpressions.Match m = r.Match(code);

            while (m.Success)
            {
                string value = m.Value.Trim();

                if (!string.IsNullOrEmpty(value) && !vList.Contains(value))
                {
                    //一致した対象が見つかったときキャプチャした部分文字列を表示
                    vList.Add(value);
                }

                //次に一致する対象を検索
                m = m.NextMatch();

            }

        }


        private void AddFNameList(string code, ref List<string> fList)
        {

            // 前後が半角スペースで、かつ途中にドットもかっこもない
            System.Text.RegularExpressions.Regex r =
                new System.Text.RegularExpressions.Regex(
                     @" [\w-]+\(",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //TextBox1.Text内で正規表現と一致する対象を1つ検索
            System.Text.RegularExpressions.Match m = r.Match(code);

            while (m.Success)
            {
                string value = m.Value.Trim();

                if (!string.IsNullOrEmpty(value) && !fList.Contains(value))
                {
                    //一致した対象が見つかったときキャプチャした部分文字列を表示
                    fList.Add(value);

                }

                //次に一致する対象を検索
                m = m.NextMatch();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Util.Write();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Util.Read();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string word = tbSearch.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            List<string> tmpVList = (from v in vList
                                     where (v.StartsWith(word.ToUpper()) || v.StartsWith(word.ToLower()))
                                     select v).ToList();
            List<string> restVList = (from v in vList
                                      where !(v.StartsWith(word.ToUpper()) || v.StartsWith(word.ToLower()))
                                      select v).ToList();
            vList = tmpVList;
            vList.AddRange(restVList);


            List<string> tmpFList = (from v in fList
                                     where (v.StartsWith(word.ToUpper()) || v.StartsWith(word.ToLower()))
                                     select v).ToList();
            List<string> restFList = (from v in fList
                                      where !(v.StartsWith(word.ToUpper()) || v.StartsWith(word.ToLower()))
                                      select v).ToList();


            fList = tmpFList;
            fList.AddRange(restFList);

            ShowList();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ShowList();
        }


        public void ShowList()
        {
            List<string> tmplist;
            if (radioButton1.Checked)
            {
                tmplist = vList;
            }
            else
            {
                tmplist = fList;

            }
            listView1.Items.Clear();
            foreach (string value in tmplist)
            {
                ListViewItem item = new ListViewItem(value);
                listView1.Items.Add(item);

            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
