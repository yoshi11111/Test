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

namespace GenerateSQL
{
    public partial class AutoSQL : Form
    {
        public AutoSQL()
        {
            InitializeComponent();
            tbselect.Text = SelectKey;
            tbjoin.Text = JoinKey;
            tbwhere.Text = WhereKey;
            tbgroup.Text = GroupKey;
            tborder.Text = OrderKey;
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
                // txt = Regex.Replace(txt, @"\s+", " ");
                txt.TrimStart();
                //Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                string[] lines = txt.Split(NewLineSeparator, StringSplitOptions.None);
                Dictionary<string, List<string>> KeyAndBlock = new Dictionary<string, List<string>>();
                KeyAndBlock[SelectKey] = GetkeyBlock(SelectKey, lines);
                KeyAndBlock[JoinKey] = GetkeyBlock(JoinKey, lines);
                KeyAndBlock[WhereKey] = GetkeyBlock(WhereKey, lines);
                KeyAndBlock[OrderKey] = GetkeyBlock(OrderKey, lines);
                KeyAndBlock[GroupKey] = GetkeyBlock(GroupKey, lines);

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
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    break;
                }
                ret.Add(lines[i]);
            }
            return ret;

        }

        string SelectKey = "取得項目";
        string JoinKey = "結合条件";
        string WhereKey = "検索条件";
        string OrderKey = "ソート条件";
        string GroupKey = "集約条件";

        private void GenarateSQL(Dictionary<string, List<string>> KeyAndBlock)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(GetSQL("SELECT", KeyAndBlock[SelectKey], 2, 3));
            sql.AppendLine(GetFromJoinSQL("FROM", KeyAndBlock[JoinKey], 1, 3, 2, 4));
            sql.AppendLine(GetWhereSQL(KeyAndBlock[WhereKey]));
            sql.AppendLine(GetSQL("ORDER BY", KeyAndBlock[OrderKey], 1, 2));
            sql.AppendLine(GetSQL("GROUP BY", KeyAndBlock[GroupKey], 1, 2));
            richRightUP.Text = sql.ToString();
        }
        private string GetSQL(string head, List<string> list, int tblIdx, int colIdx)
        {
            List<string> retList = new List<string>();
            for (int i = 1; i < list.Count; i++)
            {
                //list[i] = Regex.Replace(list[i], @"\s+", " ");
                string[] items = list[i].Split(new string[] { " " }, StringSplitOptions.None);
                if (items.Count() - 1 < Math.Max(tblIdx, colIdx))
                {
                    break;
                }
                retList.Add(items[tblIdx] + items[colIdx]);
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
                sql += items[tblIdx1] + "." + items[colIdx1] + "=" + items[tblIdx2] + "." + items[colIdx2];
                retList.Add(sql);

                if (list[i].Contains(AND))
                {

                    continue;
                }

            }
            if (0 < retList.Count)
            {
                return head + " " + fromTbl + Environment.NewLine + string.Join("," + Environment.NewLine, retList);
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
                list[i] = ("sql.AppendLine(" + list[i] + ");");
            }

            ResultForm f = new ResultForm(list);

            f.Show();
        }

        public static Dictionary<string, string> ItemJPAndValueDic = new Dictionary<string, string>();
        public static Dictionary<string, string> TableJPAndValueDic = new Dictionary<string, string>();

        public class Data2
        {
            public List<JPAndPh> itemlist { get; set; }
            public List<JPAndPh> tablelist { get; set; }
        }


        public class JPAndPh
        {
            public JPAndPh(string jp, string ph)
            {
                Jp = jp;
                Ph = ph;
            }


            public JPAndPh() { }
            public string Jp
            {
                get; set;
            }
            public string Ph
            {
                get; set;
            }
        }


        #region xml書込読込
        public static readonly string FolderName = Environment.CurrentDirectory + @"\";
        public static readonly string BakFileName = DateTime.Today.ToString("yyyyMMdd") + "Data.xml";

        public static void ReadDef()
        {
            try
            {


                //保存元のファイル名 
                string fileName = FolderName + @"definition.xml";

                //XmlSerializerオブジェクトを作成 
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Data2));
                ////読み込むファイルを開く 
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する 
                Data2 d = (Data2)serializer.Deserialize(sr);
                List<JPAndPh> obj = d.itemlist;
                ItemJPAndValueDic = List2Dic(obj);
                List<JPAndPh> obj2 = d.tablelist;
                TableJPAndValueDic = List2Dic(obj2);
                //ファイルを閉じる 
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());




            }

        }
        public static Dictionary<string, string> List2Dic(List<JPAndPh> itemList)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            foreach (JPAndPh item in itemList)
            {
                ret[item.Jp] = item.Ph;
            }
            return ret;
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            string txt = richRightUP.Text;
            // TODO テーブル名変換のあとカラム名変換＋CALDAYとか削除
            richRightDown.Text = txt;



        }
    }

}

