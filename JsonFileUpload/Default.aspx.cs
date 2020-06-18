using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _35Test
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var form = Request.Form;
            //HttpPostedFile posted = Request.Files["userfile"];
            //if (posted != null)
            //{
            //    posted.SaveAs(@"C:\temp\" + posted.FileName);
            //}
            //return;
        }


        //[WebMethod()]
        //public static string Test(string json)
        //{



        //    return "{}";
        //}



        //■成功例保存
        [WebMethod()]
        public static string Test(string json)
        {
            string facebooks = new JavaScriptSerializer().Deserialize<string>(json);
            //バイト型配列に戻す
            byte[] bs1 = System.Convert.FromBase64String(facebooks);

            //ファイルに保存する
            //保存するファイル名
            string outFileName = @"C:\temp\test.zip";
            //ファイルに書き込む
            System.IO.FileStream outFile = new System.IO.FileStream(outFileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write);
            outFile.Write(bs1, 0, bs1.Length);
            outFile.Close();
            return "{}";



            //// 文字コードはUTF8とする
            //  UTF8Encoding utf8 = new UTF8Encoding();

            ////// Base64文字列を作成
            ////var base64str = Base64Encode(json, utf8);

            //// Base64文字列をデコードし、元の文字列を復元
            //  var decodestr = Base64Decode(json, utf8);

            //SaveWithDecode(json, @"C:\temp\text2.txt");




            //byte[] bs = System.Convert.FromBase64String(json);

            ////ファイルに保存する
            ////保存するファイル名
            //string outFileName = @"C:\temp\text.txt";
            ////ファイルに書き込む
            //System.IO.FileStream outFile = new System.IO.FileStream(outFileName,
            //    System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //outFile.Write(bs, 0, bs.Length);
            //outFile.Close();


            // Base64ToImage(json);

            //Base64で文字列に変換するファイル
            //string inFileName = @"C:\Users\userpc\Desktop\test.zip";
            //System.IO.FileStream inFile;
            //byte[] bs;

            ////ファイルをbyte型配列としてすべて読み込む
            //inFile = new System.IO.FileStream(inFileName,
            //    System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //bs = new byte[inFile.Length];
            //int readBytes = inFile.Read(bs, 0, (int)inFile.Length);
            //inFile.Close();

            ////Base64で文字列に変換
            //string base64String;
            //base64String = System.Convert.ToBase64String(bs);

            ////結果を表示
            //Console.WriteLine(base64String);


        }
        //// Base64エンコード
        //public static string Base64Encode(string str, Encoding enc)
        //{
        //    byte[] data = enc.GetBytes(str);
        //    return Convert.ToBase64String(data);
        //}

        //// Base64デコード
        //public static string Base64Decode(string str, Encoding enc)
        //{
        //    byte[] data = Convert.FromBase64String(str);
        //    return enc.GetString(data);
        //}
        ///// <summary>
        ///// Base64文字列から画像に変換
        ///// </summary>
        ///// <param name=”sender”></param>
        ///// <param name=”e”></param>
        //private static void Base64ToImage(string base64)
        //{
        //    byte[] bytes = Convert.FromBase64String(base64);
        //    MemoryStream memStream = new MemoryStream(bytes);
        //    BinaryFormatter binFormatter = new BinaryFormatter();

        //    // "BinaryFile2.bin"を開く
        //    using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("C:\temp\text.txt")))
        //    {
        //        byte[] buf = new byte[] { 0x01, 0x02, 0x03, 0x04 };

        //        // 書き込み
        //        writer.Write(bytes);
        //    }



        //}


    }
}