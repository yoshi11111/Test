using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string con = WebConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        List<int> intIdList = new List<int>();
        List<string> strIdList = new List<string>();

        for (int i = 0; i < 9999; i++)
        {
            intIdList.Add(i);
            strIdList.Add(i.ToString());
        }
        using (SqlConnection scon = new SqlConnection(con))
        {
            scon.Open();
            SqlTransaction tran = scon.BeginTransaction();

            // ■解決策１ 呼ぶ側で対策・・・これでいい気もする
            List<List<int>> idListList = IdSplit(intIdList);
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
            DataTable ret2 = 呼ばれる側で対策(strIdList, scon, tran);
            getRows.Clear();
            foreach (DataRow row in ret2.Rows)
            {
                getRows.Add(row);
            }

            // ■解決策３　拡張メソッド→テーブル定義が必要
            //DataTable ret3 = Root(tmpList, scon, tran);
            //getRows.Clear();
            //foreach (DataRow row in ret2.Rows)
            //{
            //    getRows.Add(row);
            //}



            // ■他の解決策・・・他も検索したが、テーブル定義追加するとか、
            // Daoクラスないめそっどごとに修正が必要などあり、上記の対策が
            // 調べた限りではベスト

            // 上記以外の方法は見つかってない＋限られた時間で局所局所の対応
            // かつ、大幅な修正は不要、てなると上記しかない・・

            // 他の方法は、大々的にSQL修正をいろいろなメソッドで行う必要がある。
            // ■■現状のコードで、呼ばれる側で、最大限共通化して、やるのがベスト

            tran.Commit();

            scon.Close();
        }

    }

    public static DataTable 呼ぶ側で対策(List<int> idList, SqlConnection con, SqlTransaction tran)
    {
        DataTable ret = new DataTable();
        List<SqlParameter> paramList = new List<SqlParameter>();
        string inSql = string.Empty;
        GetInSqlAndParamList(idList, ref paramList, ref inSql);
        using (SqlDataAdapter adapter = new SqlDataAdapter())
        {
            SqlCommand cmd = new SqlCommand("select * from ガイダンスメンバマスタ where " +
                string.Format("ガイダンスメンバマスタＩＤ IN ({0})", inSql), con);
            cmd.Parameters.AddRange(paramList.ToArray());
            adapter.SelectCommand = cmd;
            cmd.Transaction = tran;
            adapter.Fill(ret);
        }
        return ret;
    }


    public static DataTable 呼ばれる側で対策(List<string> paraIdList, SqlConnection con, SqlTransaction tran)
    {
        DataTable ret = new DataTable();
        // SqlParamが2100を超える場合エラーが発生するため、分割して処理する
        List<List<string>> splittedLists = IdSplit(paraIdList);
        foreach (List<string> list in splittedLists)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            string inSql = string.Empty;
            GetInSqlAndParamList(list, ref paramList, ref inSql);
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand("select * from 項目マスタ where " +
                    string.Format("項目ID IN ({0})", inSql), con);
                cmd.Parameters.AddRange(paramList.ToArray());
                adapter.SelectCommand = cmd;
                cmd.Transaction = tran;
                adapter.Fill(ret);
            }
        }
        return ret;
    }

    public static List<List<T>> IdSplit<T>(List<T> idList)
    {
        List<List<T>> ret = new List<List<T>>();
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
            List<T> addList = idList.Where((name, index) => startIndex <= index && index < endIndex).ToList();
            ret.Add(addList);
        }
        return ret;
    }

    private static void GetInSqlAndParamList(List<object> idList, SqlDbType sqlType, ref List<SqlParameter> paramList, ref string inSql)
    {
        List<string> sqlList = new List<string>();
        for (int i = 0; i < idList.Count(); i++)
        {
            string para = "@para" + i;
            sqlList.Add(para);
            SqlParameter param = new SqlParameter(para, sqlType);
            param.Value = idList[i];
            paramList.Add(param);
        }
        inSql = string.Join(",", sqlList.ToArray());
    }
    public static void GetInSqlAndParamList(List<string> idList, ref List<SqlParameter> paramList, ref string inSql)
    {
        GetInSqlAndParamList(idList.Cast<object>().ToList(), SqlDbType.NVarChar, ref paramList, ref inSql);
    }
    public static void GetInSqlAndParamList(List<int> idList, ref List<SqlParameter> paramList, ref string inSql)
    {
        GetInSqlAndParamList(idList.Cast<object>().ToList(), SqlDbType.Int, ref paramList, ref inSql);
    }

    // 上記のようなオーバーロードメソッドに修正

    // 以下はCSRF対策
    // 以下はCSRF対策
    // 以下はCSRF対策
    [WebMethod()]
    public static string DoPost(string json)
    {
        // ■解決策3（全てのwebmethodに以下の処理）
        MasterPage.UtilityIsValidCsrfToken();

        // ■解決策１
        //HttpSessionState session = HttpContext.Current.Session;
        //string sessionToken = session["token"].ToString();
        //if (token != sessionToken)
        //{
        //    throw new Exception("CSRF異常");

        //}

        // ■解決策2
        // var context = HttpContext.Current;
        // HttpRequest request = context.Request;
        // // get session token
        //string sessionToken = context.Session["RequestVerificationToken"] as string;
        // // get header token
        //string token = request.Headers["X-CSRF-TOKEN"];
        // if (token != sessionToken)
        // {
        //     throw new Exception("CSRF異常");

        // }

        // ■解決策３　あとは・・・画面new時点でhiddenにtoken仕込む
        // →axios はデフォルトで設定するようにする？



        return string.Empty;
    }

   


}
