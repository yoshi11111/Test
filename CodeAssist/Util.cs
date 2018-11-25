using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeAssist
{
    public static class Util
    {
        public class ListCol
        {
            public List<string> vList { get; set; }
            public List<string> fList { get; set; }
            public List<string> cList { get; set; }


        }
        //保存先のファイル名
        private static  string fileName = @"data.xml";

        public static void Write()
        {
            
            // バックアップ作成

            for (int i = 5; 0 < i; i--)
            {
                try
                {
                    string file = fileName + i;
                    string dist = fileName + (i + 1);
                    if (File.Exists(dist))
                    {
                        File.Delete(dist);
                    }
                    if (!(1 == i))
                    {
                        File.Move(file, dist);
                    }
                    else
                    {
                        file = fileName;
                        File.Copy(file, dist);

                    }
                }
                catch (Exception ex)
                {

                }

            }
            try
            {


                //保存するクラス(SampleClass)のインスタンスを作成
                ListCol obj = new ListCol();
                obj.vList = Form1.vList;
                obj.fList = Form1.fList;
                obj.cList = Form1.cList;

                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(ListCol));
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
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(ListCol));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                ListCol obj = (ListCol)serializer.Deserialize(sr);
                Form1.vList = obj.vList;
                Form1.fList = obj.fList;
                Form1.cList = obj.cList;

                //ファイルを閉じる
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }

    }
}
