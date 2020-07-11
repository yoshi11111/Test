using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string con = WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        using (SqlConnection scon = new SqlConnection(con))
        {
            scon.Open();
            DataTable dt = new DataTable();
           
            List<string> inList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();
            for (int i = 0; i < 2100; i++)
            {
                string para = "@para" + i;
                inList.Add(para);
                paramList.Add(new SqlParameter(para, i));

            }

            string insql = string.Join(",", inList.ToArray());
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand("select * from **** where " +
                    string.Format("ガイダンスメンバマスタＩＤ IN ({0})", insql), scon);
                foreach(SqlParameter sp in paramList)
                {
                    cmd.Parameters.Add(sp);
                }
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            foreach(DataRow row in dt.Rows)
            {
                string a = row["*****ＩＤ"].ToString();
            }


            scon.Close();
        }
    }


   
   
}