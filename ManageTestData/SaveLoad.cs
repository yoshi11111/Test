using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Manage_Test_Data.UC;

namespace Manage_Test_Data
{
    public static class SaveLoad
    {
        #region xml書込読込
        public static readonly string FolderName = Environment.CurrentDirectory + @"\";
        public static readonly string FileName =  "Data.xml";
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
                ret=obj.TblInfoList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return ret;
        }

        #endregion

    }
}
