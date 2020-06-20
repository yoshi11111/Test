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
        public class JpAndPh
        {
            public string Jp { get; set; }
            public string Ph { get; set; }
        }
        public static List<JpAndPh> JpAndPhList = new List<JpAndPh>()
        {
            new JpAndPh(){Jp="項目ID", Ph="ITEM_ID" },
            new JpAndPh(){Jp="表示順", Ph="DISPLAY_ORDER" },
        };
        public Form1()
        {
            InitializeComponent();
            Read();
        }

        private void btnCvt_Click(object sender, EventArgs e)
        {
            string after = rtSQL.Text;
            // 長い和名から変換
            JpAndPhList = JpAndPhList.OrderBy(m => m.Jp.Length).ToList();
            foreach (JpAndPh j in JpAndPhList)
            {
                if (radioButton1.Checked)
                {
                    after = after.Replace(j.Jp, j.Ph);
                }
                else
                {
                    after = after.Replace(j.Ph, j.Jp);

                }

            }

            rtSQL.Text = after;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StringReader rs = new System.IO.StringReader(richTextBox1.Text))
            {
                while (rs.Peek() > -1)
                {
                    JpAndPh jp = new JpAndPh();
                    if (!IsValid(rs.ReadLine(), ref jp))
                    {
                        continue;
                    }
                    // 同じキーが存在する場合上書き
                    JpAndPh dup = JpAndPhList.Where(m => m.Jp == jp.Jp).FirstOrDefault();
                    if (dup != null)
                    {
                        JpAndPhList.Remove(dup);
                    }
                    JpAndPhList.Add(jp);
                }
            }
            Write();
        }
        private bool IsValid(string line, ref JpAndPh jp)
        {
            line = line.Replace(" ", "");
            line = line.Replace("　", "");
            string[] vals = line.Split(',');
            try
            {
                if (vals.Count() != 2)
                {
                    return false;
                }
                foreach (string val in vals)
                {
                    if (string.IsNullOrEmpty(val) || val.Contains("\"") || val.Contains("\'"))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            jp.Jp = vals[0];
            jp.Ph = vals[1];
            return true;
        }

        public static void Write()
        {
            try
            {
                //保存先のファイル名
                string fileName = @"data.xml";
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(List<JpAndPh>));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, Form1.JpAndPhList);
                //ファイルを閉じる
                sw.Close();

            }
            catch (Exception ex)
            {

            }
        }

        public static void Read()
        {
            try
            {
                //保存元のファイル名
                string fileName = @"data.xml";
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(List<JpAndPh>));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                Form1.JpAndPhList = (List<JpAndPh>)serializer.Deserialize(sr);
                //ファイルを閉じる
                sr.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
