
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AUTOSQL
{
    public static class Util
    {
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

        public static void Write()
        {
            try
            {
                Assembly assem = Assembly.GetExecutingAssembly();
                String path = Path.GetDirectoryName(assem.Location);

                //保存先のファイル名 
                string fileName = path + @"\definition.xml";

                Data2 d = new Data2();
                //保存するクラス(SampleClass)のインスタンスを作成 
                List<JPAndPh> obj = Dic2List(SQLSearch.ItemJPAndValueDic);
                d.itemlist = obj;
                List<JPAndPh> obj2 = Dic2List(SQLSearch.TableJPAndValueDic);

                d.tablelist = obj2;

                //XmlSerializerオブジェクトを作成 
                //オブジェクトの型を指定する 
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Data2));
                //書き込むファイルを開く（UTF-8 BOM無し） 
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する 
                serializer.Serialize(sw, d);
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
                Assembly assem = Assembly.GetExecutingAssembly();
                String path = Path.GetDirectoryName(assem.Location);

                //保存先のファイル名 
                string fileName = path + @"\definition.xml";

                //XmlSerializerオブジェクトを作成 
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Data2));
                //読み込むファイルを開く 
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する 
                Data2 d = (Data2)serializer.Deserialize(sr);
                List<JPAndPh> obj = d.itemlist;
                SQLSearch.ItemJPAndValueDic = List2Dic(obj);

                List<JPAndPh> obj2 = d.tablelist;
                SQLSearch.TableJPAndValueDic = List2Dic(obj2);

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