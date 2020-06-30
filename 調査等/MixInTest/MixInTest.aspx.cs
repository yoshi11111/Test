using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    public partial class MixInTest : Page
    {
        protected const string POST_TYPE_REGISTER = "register";
        protected const string POST_TYPE_FILE_SELECT = "fileSelect";
        protected const string POST_TYPE_INIT = "init";


      

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        [WebMethod()]
        public static string DoPost(string json, string type)
        {
            Json j = JsonConvert.DeserializeObject<Json>(json);
            if (type == POST_TYPE_REGISTER)
            {
                j.text += type;
            }
            if (type == POST_TYPE_FILE_SELECT)
            {
                j.text = j.text.Trim() ;

            }
            if (type == POST_TYPE_INIT)
            {
                j.text = j.text.Replace(" ",",,,");
            }
            return JsonConvert.SerializeObject(j);
        }

        private class Json
        {
            public string text { get; set; }
            public string imageBase64 { get; set; }

            public string imageFileName { get; set; }

        }


    }
}