using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manual.DataMng.Mdl;

namespace Manual
{
    public static class DataMng
    {
        public static List<Title> TitleList = new List<Title>();
        [Serializable]
        public class Mdl
        {
            public class Title : BaseItem {
                public List<MajorItem> items = new List<MajorItem>();
                public override void RemoveItem(BaseItem item)
                {
                    items.Remove((MajorItem)  item);
                }
                public override void AddItem(BaseItem item)
                {
                    items.Add((MajorItem)item);
                }
            }
            public class MajorItem : BaseItem
            {
                public List<MiddleItem> items = new List<MiddleItem>();
                public override void RemoveItem(BaseItem item)
                {
                    items.Remove((MiddleItem)item);
                }
                public override void AddItem(BaseItem item)
                {
                    items.Add((MiddleItem)item);
                }
            }
            public class MiddleItem : BaseItem
            {
                public List<SmallItem> items = new List<SmallItem>();
                public override void RemoveItem(BaseItem item)
                {
                    items.Remove((SmallItem)item);
                }
                public override void AddItem(BaseItem item)
                {
                    items.Add((SmallItem)item);
                }
            }
            public class SmallItem : BaseItem
            {
                public override void RemoveItem(BaseItem item)
                {
                }
                public override void AddItem(BaseItem item)
                {
                }
            }

            public static void SortItems(List<BaseItem> list)
            {

            }

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
