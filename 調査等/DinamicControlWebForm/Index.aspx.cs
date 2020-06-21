using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DinamicControlWebForm
{
    public partial class Index : System.Web.UI.Page
    {
        public const int メンバID = 1;
        public const int TYPE_INPUT = 1;
        public const int TYPE_CHECK = 2;



        public class 表示内容
        {
            public int? 項目要素ID;
            public bool is章;
            public int? 項目種別;
            public string タイトル;
            public string 文言;
            public string チェックボックス項目内容;
            public string ラジオボタン項目内容;



        }

        public List<表示内容> 表示内容リスト = new List<表示内容>();



        protected void Page_Load(object sender, EventArgs e)
        {

            this.PreInit += Page_PreInit;

            表示内容リスト = new List<表示内容>();

            //▽web.configから接続文字列を取得
            string cnnStr = @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=DinamicWebForm;Integrated Security=True;Pooling=False";
            SqlConnection conn = new SqlConnection(cnnStr);//DBコネクションを作成。
            conn.Open();//コネクションを開く。
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM 章マスタ WHERE メンバマスタID=" + メンバID, conn);//セレクトSQLを生成。
            DataTable 章dt = new DataTable();//データセットを生成
            sda.Fill(章dt);//SQL実行
            conn.Close();//DBコネクションを閉じる。

            List<int> 章IDリスト = new List<int>();
            foreach (DataRow dr in 章dt.Rows)
            {
                章IDリスト.Add(Convert.ToInt32(dr["章ID"]));
            }
            if (章IDリスト.Count == 0)
            {
                return;
            }

            conn.Open();//コネクションを開く。
            sda = new SqlDataAdapter("SELECT * FROM 項目マスタ WHERE 章ID in (" + string.Join(",", 章IDリスト) + ")", conn);//セレクトSQLを生成。
            DataTable 項目dt = new DataTable();//データセットを生成
            sda.Fill(項目dt);//SQL実行
            conn.Close();//DBコネクションを閉じる。
            List<int> 項目IDリスト = new List<int>();
            foreach (DataRow dr in 項目dt.Rows)
            {
                項目IDリスト.Add(Convert.ToInt32(dr["項目ID"]));
            }

            conn.Open();//コネクションを開く。
            sda = new SqlDataAdapter("SELECT * FROM 項目要素マスタ WHERE 項目ID in (" + string.Join(",", 項目IDリスト) + ")", conn);//セレクトSQLを生成。
            DataTable 項目要素dt = new DataTable();//データセットを生成
            sda.Fill(項目要素dt);//SQL実行
            conn.Close();//DBコネクションを閉じる。

            foreach (DataRow 章dr in 章dt.Select().OrderBy(n => n["表示順"]))
            {
                表示内容 h = new 表示内容();
                h.is章 = true;
                h.タイトル = 章dr["タイトル"] + "";
                h.項目種別 = null;
                h.項目要素ID = null;
                表示内容リスト.Add(h);

                foreach (DataRow 項目dr in 項目dt.Select("章ID="+章dr["章ID"]))
                {
                    foreach (DataRow 項目要素dr in 項目要素dt.Select("項目ID="+ 項目dr["項目ID"]))
                    {

                        表示内容 hy = new 表示内容();
                        hy.is章 = false;
                        hy.文言 = 項目要素dr["文言"] + "";
                        hy.チェックボックス項目内容 = 項目要素dr["チェックボックス項目内容"] + "";
                        hy.ラジオボタン項目内容 = 項目要素dr["ラジオボタン項目内容"] + "";

                        hy.項目種別 = Convert.ToInt32(項目dr["項目種別"]);
                        hy.項目要素ID = Convert.ToInt32(項目要素dr["項目要素ID"]);
                        表示内容リスト.Add(hy);

                    }

                }

            }
            foreach (表示内容 naiyo in 表示内容リスト)
            {
                if (naiyo.is章)
                {
                    Label l = new Label() { Text = naiyo.タイトル };
                    TableRow row1 = new TableRow();
                    TableCell tc1 = new TableCell();
                    tc1.Controls.Add(l);
                    row1.Controls.Add(tc1);
                    Table1.Rows.Add(row1);
                    continue;
                }
                switch (naiyo.項目種別)
                {
                    case TYPE_INPUT:
                        Label l1 = new Label() { Text = naiyo.文言 };
                        TextBox t = new TextBox();
                        TableRow row1 = new TableRow();
                        TableCell tc1 = new TableCell();
                        TableCell tc2 = new TableCell();

                        tc1.Controls.Add(l1);
                        tc2.Controls.Add(t);
                        row1.Controls.Add(tc1);
                        row1.Controls.Add(tc2);
                        Table1.Rows.Add(row1);

                        break;

                    case TYPE_CHECK:
                        Label l2 = new Label() { Text = naiyo.チェックボックス項目内容 };
                        CheckBox c = new CheckBox();
                        TableRow row2 = new TableRow();
                        TableCell tc3 = new TableCell();
                        TableCell tc4 = new TableCell();
                        tc3.Controls.Add(l2);
                        tc4.Controls.Add(c);
                        row2.Controls.Add(tc3);
                        row2.Controls.Add(tc4);
                        Table1.Rows.Add(row2);
                        break;

                    default:
                        break;

                }
            }
        }



        protected void Page_PreInit(object sender, EventArgs e)
        {
          
        }
    }
}