

using Manage_Test_Data.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manage_Test_Data.UC;

namespace Manage_Test_Data
{
    public static class SaveLoad
    {
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
        public static readonly string FileName = "Data.xml";
        public static readonly string BakFileName = DateTime.Today.ToString("yyyyMMdd") + "Data.xml";

        public class ForSaveLoad
        {
            public List<TableInfo> TblInfoList;
        }


        public static void SaveData(List<TableInfo> tblInfoList)
        {
            string[] fileNames = new string[]{
            FolderName + FileName,
            FolderName + BakFileName };



            ForSaveLoad f = new ForSaveLoad();
            f.TblInfoList = tblInfoList;

            try
            {
                foreach (string fileName in fileNames)
                {
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        fileName, false, new System.Text.UTF8Encoding(false));
                    serializer.Serialize(sw, f);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static List<TableInfo> LoadData()
        {
            string fileName = FolderName + FileName;
            List<TableInfo> ret = new List<TableInfo>();
            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                ForSaveLoad obj = (ForSaveLoad)serializer.Deserialize(sr);
                sr.Close();
                ret = obj.TblInfoList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return ret;
        }


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
        #endregion

    }
}






