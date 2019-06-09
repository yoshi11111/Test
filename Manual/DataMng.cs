using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Manual
{
    public static class DataMng
    {
        public static List<Title> TitleList = new List<Title>();
        public class Title
        {
            public int sort=1;
            public string text = string.Empty;
            public string leftRtf = string.Empty;
            public string rightRtf = string.Empty;
        }
        public static readonly string FolderName = Environment.CurrentDirectory + @"\";
        public static readonly string FileName = "Data.xml";
        public static readonly string BakFileName = DateTime.Today.ToString("yyyyMMdd") + "Data.xml";

        public class ForSaveLoad
        {
            public List<Title> List;
        }


        public static void SaveData()
        {
            string[] fileNames = new string[]{
            FolderName + FileName,
            FolderName + BakFileName };



            ForSaveLoad f = new ForSaveLoad();
            f.List = TitleList;

            try
            {
                foreach (string fileName in fileNames)
                {
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        fileName, false, new System.Text.UTF8Encoding(false)))
                    {
                        serializer.Serialize(sw, f);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void LoadData()
        {
            string fileName = FolderName + FileName;
            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                using (System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false)))
                {
                    ForSaveLoad obj = (ForSaveLoad)serializer.Deserialize(sr);
                    sr.Close();
                    TitleList = obj.List;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

    }
}
