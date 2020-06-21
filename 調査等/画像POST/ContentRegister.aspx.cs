using Newtonsoft.Json;
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
    public partial class ContentRegister : Page
    {
        protected const string POST_TYPE_REGISTER = "register";
        protected const string POST_TYPE_FILE_SELECT = "fileSelect";
        protected const string POST_TYPE_INIT = "init";



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
        public static string Test(string json, string name)
        {
            try
            {
                string facebooks = new JavaScriptSerializer().Deserialize<string>(json);
                //バイト型配列に戻す
                byte[] bs1 = System.Convert.FromBase64String(facebooks);

                //ファイルに保存する
                //保存するファイル名
                string outFileName = @"C:\temp\" + name;
                //ファイルに書き込む
                System.IO.FileStream outFile = new System.IO.FileStream(outFileName,
                    System.IO.FileMode.Create, System.IO.FileAccess.Write);
                outFile.Write(bs1, 0, bs1.Length);
                outFile.Close();
            }
            catch (Exception e)
            {
                string a = e.ToString();
            }
            return "{}";


        }
        [WebMethod()]
        public static string UploadFile(string json, string fileName)
        {
            string base64 = JsonConvert.DeserializeObject<string>(json);
            SaveFile(base64, fileName);

            return JsonConvert.SerializeObject("{}");
        }


        [WebMethod()]
        public static string DoPost(string json, string type)
        {
            Json j = JsonConvert.DeserializeObject<Json>(json);
            if (type == POST_TYPE_REGISTER)
            {
                SaveFile(j.imageBase64, j.imageFileName);
            }
            if (type == POST_TYPE_FILE_SELECT)
            {
                SaveFile(j.imageBase64, j.imageFileName);

            }
            if (type == POST_TYPE_INIT)
            {
                j.text += "INIT";
            }
            return JsonConvert.SerializeObject(j);
        }

        private static void SaveFile(string base64, string fileName)
        {
            try
            {
                // string facebooks = new JavaScriptSerializer().Deserialize<string>(base64);
                //バイト型配列に戻す
                byte[] bs1 = System.Convert.FromBase64String(base64);

                //ファイルに保存する
                //保存するファイル名
                string outFileName = @"C:\temp\" + fileName;
                //ファイルに書き込む
                System.IO.FileStream outFile = new System.IO.FileStream(outFileName,
                    System.IO.FileMode.Create, System.IO.FileAccess.Write);
                outFile.Write(bs1, 0, bs1.Length);
                outFile.Close();
            }
            catch (Exception e)
            {
                string a = e.ToString();
            }
        }



        private class Json
        {
            public string text { get; set; }
            public string imageBase64 { get; set; }

            public string imageFileName { get; set; }

        }


    }
}