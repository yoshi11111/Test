using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTOSQL
{
    public partial class AutoSQL : UserControl
    {

        public AutoSQL()
        {
            InitializeComponent();
            tbselect.Text = Sel;
            tbjoin.Text = Joi;
            tbwhere.Text = Whe;
            tbgroup.Text = Gro;
            tborder.Text = Ord;
            keyList = new List<string>() { Sel, Joi, Whe, Ord, Gro };
        }

        private string[] NewLineSeparator = new string[] { "\n", "\\n", "\r\n", "\\r\\n", Environment.NewLine };

        private void button1_Click(object sender, EventArgs e)

        {
            try
            {
                string txt = richLeft.Text;
                if (string.IsNullOrWhiteSpace(txt))
                {
                    return;
                }



                txt = txt.Replace("\t", " ");
                txt = Regex.Replace(txt, @" +", " ");
                txt.TrimStart();
                //Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                string[] lines = txt.Split(NewLineSeparator, StringSplitOptions.None);
                Dictionary<string, List<string>> KeyAndBlock = new Dictionary<string, List<string>>();
                KeyAndBlock[Sel] = GetkeyBlock(Sel, lines);
                KeyAndBlock[Joi] = GetkeyBlock(Joi, lines);
                KeyAndBlock[Whe] = GetkeyBlock(Whe, lines);
                KeyAndBlock[Gro] = GetkeyBlock(Gro, lines);
                KeyAndBlock[Ord] = GetkeyBlock(Ord, lines);


                //string ret = null;
                //foreach(KeyValuePair<string, List<string>> kvp in KeyAndBlock)
                //{
                //    ret += (kvp.Key + string.Join(",",kvp.Value))+Environment.NewLine;
                //}
                //MessageBox.Show(ret);
                GenarateSQL(KeyAndBlock);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<string> GetkeyBlock(string key, string[] lines)
        {
            bool exist = false;
            List<string> ret = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].Contains(key) && !exist)
                {
                    continue;
                }
                if (lines[i].Contains(key))
                {
                    exist = true;
                    continue;

                }
                if (lines[i].Contains(Sel) || lines[i].Contains(Joi) || lines[i].Contains(Whe) || lines[i].Contains(Ord) || lines[i].Contains(Gro))
                {
                    break;
                }
                ret.Add(lines[i]);
            }
            return ret;

        }

        string Sel = "取得項目";
        string Joi = "結合条件";
        string Whe = "検索条件";
        string Ord = "ソート条件";
        string Gro = "集約条件";

        List<string> keyList;

        private void GenarateSQL(Dictionary<string, List<string>> KeyAndBlock)
        {
            StringBuilder sql = new StringBuilder();
            string from = string.Empty;
            sql.AppendLine(GetSQL("SELECT", KeyAndBlock[Sel], 2, 3, ref from));
            string tmp = GetFromJoinSQL("FROM", KeyAndBlock[Joi], 1, 3, 2, 4);
            if (string.IsNullOrWhiteSpace(tmp))
            {
                tmp = from;
            }
            sql.AppendLine(tmp);
            string whereRet = GetWhereSQL(KeyAndBlock[Whe]).ToUpper().Replace("WHEREWHERE", "WHERE");
            sql.AppendLine(whereRet);
            sql.AppendLine(GetSQL("GROUP BY", KeyAndBlock[Gro], 1, 2, ref from));
            sql.AppendLine(GetSQL("ORDER BY", KeyAndBlock[Ord], 1, 2, ref from));


            sql = sql.Replace("\"", "'");
            string ret = string.Empty;
            if (checkBox1.Checked)
            {
                ret = (" WITH SUB AS( " + sql.ToString() + " ) ");
            }
            else
            {
                ret = sql.ToString();
            }
            richRightUP.Text = sql.ToString();
        }
        private string GetSQL(string head, List<string> list, int tblIdx, int colIdx, ref string from)
        {
            List<string> retList = new List<string>();
            bool done = false;
            for (int i = 1; i < list.Count; i++)
            {
                //list[i] = Regex.Replace(list[i], @"\s+", " ");
                string[] items = list[i].Split(new string[] { " " }, StringSplitOptions.None);
                if (items.Count() - 1 < Math.Max(tblIdx, colIdx))
                {
                    retList.Add("要設計書確認");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(items[tblIdx].Trim()) || string.IsNullOrEmpty(items[colIdx].Trim()))
                {
                    continue;
                }
                if (!done)
                {
                    done = true;
                    from += " FROM " + items[tblIdx];
                }
                retList.Add(items[tblIdx] + "." + items[colIdx].Replace("(降順)", "").Replace("(昇順)", " DESC"));
            }
            if (0 < retList.Count)
            {
                return head + Environment.NewLine + string.Join("," + Environment.NewLine, retList);
            }
            else
            {
                return string.Empty;
            }

        }
        private string GetWhereSQL(List<string> list)
        {
            int tblIdx = 1;
            int colIdx = 2;
            List<string> retList = new List<string>();
            for (int i = 1; i < list.Count; i++)
            {
                string ret = string.Empty;
                string[] items = list[i].Split(new string[] { " " }, StringSplitOptions.None);
                string rest = string.Empty;
                if (items.Count() - 1 < Math.Max(tblIdx, colIdx))
                {
                    break;
                }
                for (int j = 3; j < items.Count(); j++)
                {
                    if (items[j] == "定数" || items[j] == "引数")
                    {
                        continue;
                    }
                    rest += (" " + items[j] + " ");

                }

                ret += (items[0] + " " + items[tblIdx] + "." + items[colIdx] + rest + "\r\n");
                retList.Add(ret);
            }
            if (0 < retList.Count)
            {
                return string.Join(Environment.NewLine, retList);
            }
            else
            {
                return string.Empty;
            }

        }
        private string GetFromJoinSQL(string head, List<string> list, int tblIdx1, int tblIdx2, int colIdx1, int colIdx2)
        {
            string ret = string.Empty;
            string INNER = "INNER";
            string LEFT = "LEFT";
            string AND = "AND";
            string OR = "OR";

            string fromTbl = string.Empty;
            List<string> retList = new List<string>();
            string leftTbl = string.Empty;
            string rightTbl = string.Empty;
            string joinTbl = string.Empty;
            for (int i = 1; i < list.Count; i++)
            {
                string[] items = list[i].Split(new string[] { " " }, StringSplitOptions.None);
                if (items.Count() - 1 < Math.Max(Math.Max(tblIdx1, tblIdx1), Math.Max(colIdx1, colIdx2)))
                {
                    break;
                }

                if (string.IsNullOrEmpty(fromTbl))
                {
                    fromTbl = items[tblIdx1];
                }
                leftTbl = items[tblIdx1];
                rightTbl = items[tblIdx2];
                joinTbl = rightTbl;
                if (joinTbl == fromTbl)
                {
                    joinTbl = leftTbl;
                }
                string sql = string.Empty;
                if (list[i].Contains(INNER))
                {
                    sql = " INNER JOIN " + joinTbl + Environment.NewLine + " ON ";
                }
                if (list[i].Contains(LEFT))
                {
                    sql = " LEFT OUTER JOIN " + joinTbl + Environment.NewLine + " ON ";
                }
                if (list[i].Contains(AND))
                {
                    sql = " AND ";
                }
                if (list[i].Contains(OR))
                {
                    sql = " OR ";
                }
                sql += items[tblIdx1] + "." + items[colIdx1] + "=" + items[tblIdx2] + "." + items[colIdx2].Replace("INNER", "").Replace("LEFT", "").Replace("AND", "").Replace("OR", "");
                retList.Add(sql);



            }
            if (0 < retList.Count)
            {
                return head + " " + fromTbl + Environment.NewLine + string.Join(" " + Environment.NewLine, retList);
            }
            else
            {
                return string.Empty;
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string[] list = richRightDown.Text.Split(NewLineSeparator, StringSplitOptions.None);
            for (int i = 0; i < list.Count(); i++)
            {
                if (string.IsNullOrWhiteSpace(list[i]))
                {
                    continue;
                }
                if (checkBox1.Checked)
                {
                    list[i] = ("with.AppendLine(\" " + list[i] + " \");");
                }
                else
                {
                    list[i] = ("sql.AppendLine(\" " + list[i] + " \");");

                }
            }


            ResultForm f = new ResultForm(checkBox1.Checked, list);

            f.Show();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            string txt = richRightUP.Text;
            string ret = SQLSearch.ConvertSql(txt);
            richRightDown.Text = ret;
        }

        private void AutoSQL_Load(object sender, EventArgs e)
        {
            // searchUC = tabControl1.TabPages[1].Controls[0] as SQLSearch;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Form f = this.ParentForm as Form;
            f.TopMost = checkBox3.Checked;
        }
    }

}












