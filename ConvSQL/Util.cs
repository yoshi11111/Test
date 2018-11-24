using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlConverter
{
    public static class Util
    {
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

        public static void Write()
        {
            try
            {
                //保存先のファイル名
                string fileName = @"data.xml";

                //保存するクラス(SampleClass)のインスタンスを作成
                List<JPAndPh> obj = Dic2List(Form1.JPAndValueDic);

                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(List<JPAndPh>));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, obj);
                //ファイルを閉じる
                sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    new System.Xml.Serialization.XmlSerializer(typeof(List<JPAndPh>));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                List<JPAndPh> obj = (List<JPAndPh>)serializer.Deserialize(sr);
                Form1.JPAndValueDic = List2Dic(obj);

                //ファイルを閉じる
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }

        public static List<JPAndPh> Dic2List(Dictionary<string, string> dic)
        {
            List<JPAndPh> ret = new List<JPAndPh>();
            foreach (KeyValuePair<string, string> kvp in dic)
            {
                JPAndPh item = new JPAndPh(kvp.Key, kvp.Value);
                ret.Add(item);

            }
            return ret;
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
    }
}
