using Chapter6複製.DataSets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Chapter6複製.DataSets.DataSet1;

namespace Chapter6複製
{
    public partial class DataSetTest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<string> GetList()
        {

            HttpSessionState session = HttpContext.Current.Session;
            if (session["login_name"] != null)
            {
                return (List<string>)session["login_name"];
            }


            List<string> ret = new List<string>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM GROUP_MASTER", conn);//セレクトSQLを生成。
                DataSet1.GROUP_MASTERDataTable dt = new DataSet1.GROUP_MASTERDataTable();//データセットを生成
                sda.Fill(dt);//SQL実行

                foreach (GROUP_MASTERRow dr in dt.Rows)
                {
                    //var a = dr.GROUP_ID;
                    //ret.Add(Convert.ToString(dr["TITLE"]));
                    //string value = dr.Field<string>("TITLE");
                    //value = (string)dr["TITLE"];
                    ret.Add(dr.TITLE+"");

                }

            }
            catch (Exception e)
            {
                ret.Add(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            session["login_name"] = ret;
            return new List<string>();
        }
    }
}