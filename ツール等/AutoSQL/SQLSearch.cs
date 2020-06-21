

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTOSQL
{
    public partial class SQLSearch : Form
    {
        public SQLSearch()
        {
            InitializeComponent();
            // テーブル定義の＊列を日本語名、＊列を物理名として取り込み 
            InitRT();
            //タブコントロールの描画モードをオーナードローに変更
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            ////列の追加 
            listView1.Columns.Add(
                "", 100, HorizontalAlignment.Left);
            listView1.Columns.Add(
        "", 100, HorizontalAlignment.Left);
            //         listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.HeaderStyle = ColumnHeaderStyle.None;

            Util.Read();
            autoSQL1.checkBox3.Checked = false;
            autoSQL1.checkBox3.Checked = true;

        }


        public static Dictionary<string, string> ItemJPAndValueDic = new Dictionary<string, string>();
        public static Dictionary<string, string> TableJPAndValueDic = new Dictionary<string, string>();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }


        private void rtSQL_TextChanged(object sender, EventArgs e)
        {


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

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = rtSQL.Text;
            string after = sql;
            Dictionary<string, string> dic;
            if (ckTable.Checked)
            {
                dic = TableJPAndValueDic;
            }
            else
            {
                dic = ItemJPAndValueDic;

            }
            var dicret = new List<KeyValuePair<string, string>>();
            if (checkBox1.Checked)
            {
                dicret = (from d in dic
                          orderby d.Key.Length descending
                          select d).ToList();
            }
            else
            {
                dicret = (from d in dic
                          orderby d.Value.Length descending
                          select d).ToList();
            }

            foreach (KeyValuePair<string, string> kvp in dicret)
            {

                if (checkBox1.Checked)
                {
                    after = after.Replace(kvp.Key.ToUpper(), kvp.Value.ToUpper());
                    after = after.Replace(kvp.Key.ToLower(), kvp.Value.ToLower());

                }
                else
                {
                    after = after.Replace(kvp.Value.ToUpper(), kvp.Key.ToUpper());
                    after = after.Replace(kvp.Value.ToLower(), kvp.Key.ToLower());
                }


            }


            rtSQL.Text = after;

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Util.Read();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            string word = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                if (checkBox2.Checked)
                {
                    ShowList(TableJPAndValueDic, null);
                }
                else
                {
                    ShowList(ItemJPAndValueDic, null);

                }


            }
            Dictionary<string, string> target;
            if (checkBox2.Checked)
            {
                target = TableJPAndValueDic;
            }
            else
            {
                target = ItemJPAndValueDic;

            }

            List<KeyValuePair<string, string>> tmpV = (from v in target
                                                       where (v.Key.Contains(word))
                                                       select v).ToList();

            List<KeyValuePair<string, string>> tmpY = (from v in target
                                                       where (!v.Key.Contains(word))
                                                       select v).ToList();

            tmpV.AddRange(tmpY);


            ShowList(null, tmpV);


        }


        public void ShowList(Dictionary<string, string> dic, List<KeyValuePair<string, string>> kvpList)
        {
            listView1.Items.Clear();


            if (dic != null)
            {
                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    ListViewItem item = new ListViewItem(new string[] { kvp.Key, kvp.Value });
                    listView1.Items.Add(item);
                }
            }
            if (kvpList != null)
            {
                foreach (KeyValuePair<string, string> kvp in kvpList)
                {
                    ListViewItem item = new ListViewItem(new string[] { kvp.Key, kvp.Value });
                    listView1.Items.Add(item);
                }
            }



        }


        private void button1_Click(object sender, EventArgs e)
        {


            string val = Clipboard.GetText();
            if (string.IsNullOrEmpty(val))
            {
                return;
            }
            string[] del = { "\r\n" };
            string[] list = val.Split(del, StringSplitOptions.None);
            foreach (string va in list)
            {
                if (va.StartsWith("切断グループ"))
                {
                    Console.WriteLine(va);
                }


                if (va.Contains("\t"))
                {
                    string[] tmp = va.Split('\t');
                    if (string.IsNullOrEmpty(tmp[0]) || string.IsNullOrEmpty(tmp[1]))
                    {
                        continue;
                    }

                    //if (JPAndValueDic.ContainsKey(tmp[0]))
                    //{
                    //    continue;
                    //}
                    if (checkBox2.Checked)
                    {
                        TableJPAndValueDic[tmp[0]] = tmp[1];

                    }
                    else
                    {

                        ItemJPAndValueDic[tmp[0]] = tmp[1];
                    }
                }

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                Clipboard.SetText(item.SubItems[0].Text.ToString() + " " + item.SubItems[1].Text.ToString());
            }
            catch { }
        }

        public static string ConvertSql(string sql)
        {
            string after = sql.Replace("NO", "ＮＯ").Replace("CD", "ＣＤ");
            Dictionary<string, string> dic;

            dic = TableJPAndValueDic;
            foreach (KeyValuePair<string, string> item in ItemJPAndValueDic)
            {
                dic[item.Key] = item.Value;
            }





            var dicret = new List<KeyValuePair<string, string>>();
            dicret = (from d in dic
                      orderby d.Key.Length descending
                      select d).ToList();

            foreach (KeyValuePair<string, string> kvp in dicret)
            {

                after = after.Replace(kvp.Key.ToUpper(), kvp.Value.ToUpper());
                after = after.Replace(kvp.Key.ToLower(), kvp.Value.ToLower());

            }

            return after;


        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //変数定義
            SolidBrush backBrush;
            SolidBrush foreBrush;

            //選択中のタブを判定
            if (tabControl1.SelectedIndex == e.Index)
            {
                backBrush = new SolidBrush(Color.Navy);
                foreBrush = new SolidBrush(Color.White);
            }
            else
            {
                backBrush = new SolidBrush(SystemColors.Control);
                foreBrush = new SolidBrush(Color.Black);
            }

            //背景色塗潰し
            e.Graphics.FillRectangle(backBrush, e.Bounds);

            //表示文字列描画
            StringFormat format = new StringFormat();
            RectangleF rect = new RectangleF(e.Bounds.X, e.Bounds.Y + 6, e.Bounds.Width, e.Bounds.Height);
            format.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, tabControl1.Font, foreBrush, rect, format);

        }

    }
}






