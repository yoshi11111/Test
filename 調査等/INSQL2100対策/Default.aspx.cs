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
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string con = WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        List<int> tmpList = new List<int>();
        for (int i = 0; i < 9999; i++)
        {
            tmpList.Add(i);
        }
        using (SqlConnection scon = new SqlConnection(con))
        {
            scon.Open();
            SqlTransaction tran = scon.BeginTransaction();

            // ■解決策１ 呼ぶ側で対策・・・これでいい気もする
            List<List<int>> idListList = IdSplit(tmpList);
            List<DataRow> getRows = new List<DataRow>();
            foreach (List<int> idList in idListList)
            {
                DataTable dt = 呼ぶ側で対策(idList, scon, tran);
                foreach (DataRow row in dt.Rows)
                {
                    getRows.Add(row);
                }
            }

            // ■解決策２　呼ばれる側で対策 こっちのほうがいい気もする。
            DataTable ret2 = 呼ばれる側で対策(tmpList, scon, tran);
            getRows.Clear();
            foreach (DataRow row in ret2.Rows)
            {
                getRows.Add(row);
            }


            // ■解決策３　ネットで検索して他の対策方法


            tran.Commit();

            scon.Close();
        }

    }

    public static List<List<int>> IdSplit(List<int> idList)
    {
        List<List<int>> ret = new List<List<int>>();
        int startIndex = 0;
        int endIndex = 0;
        for (int i = 0; i < 100; i++)
        {
            startIndex = Math.Min(i * 2000, idList.Count());
            endIndex = Math.Min((i + 1) * 2000, idList.Count());
            if (startIndex == endIndex)
            {
                break;
            }
            List<int> addList = idList.Where((name, index) => startIndex <= index && index < endIndex).ToList();
            ret.Add(addList);
        }
        return ret;
    }

    public static DataTable 呼ぶ側で対策(List<int> idList, SqlConnection con, SqlTransaction tran)
    {
        DataTable ret = new DataTable();
        List<SqlParameter> paramList = new List<SqlParameter>();
        List<string> tmpList = new List<string>();
        for (int i = 0; i < idList.Count(); i++)
        {
            string para = "@para" + i;
            tmpList.Add(para);
            paramList.Add(new SqlParameter(para, idList[i]));
        }
        string insql = string.Join(",", tmpList.ToArray());
        using (SqlDataAdapter adapter = new SqlDataAdapter())
        {
            SqlCommand cmd = new SqlCommand("select * from ガイダンスメンバマスタ where " +
                string.Format("ガイダンスメンバマスタＩＤ IN ({0})", insql), con);
            foreach (SqlParameter sp in paramList)
            {
                cmd.Parameters.Add(sp);
            }

            adapter.SelectCommand = cmd;
            cmd.Transaction = tran;
            adapter.Fill(ret);
        }
        return ret;
    }





    public static DataTable 呼ばれる側で対策(List<int> wholeIdLIst, SqlConnection con, SqlTransaction tran)
    {
        DataTable ret = new DataTable();

        List<List<int>> idLIstLIst = IdSplit(wholeIdLIst);
        foreach (List<int> idList in idLIstLIst)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            List<string> tmpList = new List<string>();
            for (int i = 0; i < idList.Count(); i++)
            {
                string para = "@para" + i;
                tmpList.Add(para);
                paramList.Add(new SqlParameter(para, idList[i]));
            }
            string insql = string.Join(",", tmpList.ToArray());
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand("select * from ガイダンスメンバマスタ where " +
                    string.Format("ガイダンスメンバマスタＩＤ IN ({0})", insql), con);
                foreach (SqlParameter sp in paramList)
                {
                    cmd.Parameters.Add(sp);
                }

                adapter.SelectCommand = cmd;
                cmd.Transaction = tran;
                adapter.Fill(ret);
            }
        }
        return ret;
    }

















}