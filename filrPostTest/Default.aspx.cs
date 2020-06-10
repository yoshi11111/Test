using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var form = Request.Form;
            HttpPostedFile posted = Request.Files["userfile"];
            if (posted != null)
            {
                posted.SaveAs(@"C:\temp\" + posted.FileName);
            }
            return;
        }

        [WebMethod()]
        public static string DoPost(string json)
        {



            return "{}";
        }

        [WebMethod]
        public string Test(HttpPostedFile x)
        {
            string str_response = string.Empty;
            //if (x.job_file.ContentLength > 0)
            //{
            //}
            //else
            //{

            //};
            return str_response;
        }
        public class FileUploadRequest
        {
            public string job_id { get; set; }
            public string job_name { get; set; }
            public HttpPostedFile job_file { get; set; }
        }

    }
}