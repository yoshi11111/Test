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
           
        }

        //■成功例保存
        [WebMethod()]
        public static string Test(string json,string name)
        {
            try
            {
                string facebooks = new JavaScriptSerializer().Deserialize<string>(json);
                //バイト型配列に戻す
                byte[] bs1 = System.Convert.FromBase64String(facebooks);

                //ファイルに保存する
                //保存するファイル名
                string outFileName = @"C:\temp\"+ name;
                //ファイルに書き込む
                System.IO.FileStream outFile = new System.IO.FileStream(outFileName,
                    System.IO.FileMode.Create, System.IO.FileAccess.Write);
                outFile.Write(bs1, 0, bs1.Length);
                outFile.Close();
            }catch(Exception e)
            {
                string a = e.ToString();
            }
            return "{}";

            
        }
      
    }
}