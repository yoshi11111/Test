using DataGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Manage_Test_Data.UC;

namespace Manage_Test_Data
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            SaveLoad.ReadDef();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<TableInfo> tblInfoList = SaveLoad.LoadData();
            if (tblInfoList != null && tblInfoList.Count > 0)
            {
                foreach (TableInfo info in tblInfoList)
                {
                    UC uc = new UC(info);
                    flowLayoutPanel1.Controls.Add(uc);
                }
            }
            Form1_SizeChanged(this, null);

        }

        public List<string> GetTableNameList(UC uc)
        {
            List<string> tableNameList = new List<string>();
            foreach (UC u in flowLayoutPanel1.Controls)
            {
                if (u == uc)
                {
                    continue;
                }

                tableNameList.Add(u.TblInfo.TblName);
            }
            return tableNameList;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            UC uc = new UC(new TableInfo());
            //uc.Dock = DockStyle.Top;
            flowLayoutPanel1.Controls.Add(uc);
            Form1_SizeChanged(this, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder insSql = new StringBuilder();
                StringBuilder updDelSql = new StringBuilder();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("BEGIN DECLARE cnt NUMBER := 0; BEGIN");
                foreach (UC tbl in flowLayoutPanel1.Controls)
                {

                    StringBuilder updSet = new StringBuilder();
                    StringBuilder updWhere = new StringBuilder();

                    string tableName = tbl.TblInfo.TblName;
                    List<ColumnInfo> colInfoList = tbl.TblInfo.ColumnInfoList;
                    DataTable dt = tbl.TblInfo.Tbl;

                    bool validRow = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        updWhere = new StringBuilder();
                        updSet = new StringBuilder();
                        insSql = new StringBuilder();
                        updDelSql = new StringBuilder();

                        bool existsKey = false;
                        foreach (ColumnInfo ci in colInfoList)
                        {
                            if (ci.ColName == ROW_CHECK)
                            {
                                continue;
                            }
                            if (ci.isPkey)
                            {
                                if (existsKey)
                                {
                                    updWhere.Append(" AND ");
                                }
                                existsKey = true;
                                if (ci.isNumber)
                                {
                                    updWhere.Append(ci.ColName + "= " + row[ci.ColName]);
                                }
                                else
                                {
                                    updWhere.Append(ci.ColName + "= '" + row[ci.ColName] + "' ");
                                }
                            }
                        }
                        if (!existsKey)
                        {
                            MessageBox.Show(tableName + "テーブルのプライマーキーが指定されていません。");
                            return;
                        }


                        List<string> intoList = new List<string>();
                        List<string> valuesList = new List<string>();



                        bool existData = false;
                        for (int i = 0; i < row.ItemArray.Count(); i++)
                        {
                            ColumnInfo ci = GetColInfo(colInfoList, dt.Columns[i].ColumnName);
                            if (ci == null)
                            {
                                continue;
                            }
                            if (existData)
                            {
                                updSet.Append(",");

                            }
                            intoList.Add(ci.ColName);
                            valuesList.Add(row[i].ToString());

                            existData = true;
                            updSet.Append(ci.ColName + " = '" + row[i].ToString().Trim() + "' ");

                        }
                        if (!existData)
                        {
                            MessageBox.Show(tableName + "テーブルで値が設定されていない項目があります");
                            return;
                        }

                        if (row[ROW_CHECK].ToString().ToUpper() == "TRUE")
                        {
                            validRow = true;
                            updDelSql.Append("UPDATE " + tableName);
                            updDelSql.Append(" SET " + updSet);
                            updDelSql.Append(" WHERE " + updWhere + ";");
                        }
                        else
                        {
                            existData = false;
                            updDelSql.Append("DELETE " + tableName);
                            updDelSql.Append(" WHERE " + updWhere + ";");
                        }

                        if (validRow)
                        {
                            insSql.Append("IF cnt = 0 THEN INSERT INTO " + tableName + " (" +
                                string.Join(", ", intoList) +
                                ") VALUES( '" + string.Join("','", valuesList) + "' ); END IF;");
                        }
                        sql.AppendLine("SELECT COUNT(*) INTO cnt FROM " + tableName + " WHERE " + updWhere + ";");
                        sql.AppendLine(insSql.ToString());
                        sql.AppendLine("IF cnt = 1 THEN " + updDelSql.ToString() + " END IF;");

                    }
                }



                //                sql.AppendLine("IF cnt <> 0 AND cnt <> 1 THEN ROLLBACK;");
                sql.AppendLine("COMMIT; END; END;");
                ResultForm ret = new ResultForm(sql.ToString());
                ret.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ColumnInfo GetColInfo(List<ColumnInfo> colInfoList, string colName)
        {
            if (colName == ROW_CHECK)
            {
                return null;
            }

            foreach (ColumnInfo col in colInfoList)
            {
                if (col.ColName == colName)
                {
                    return col;
                }
            }
            return null;

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int w = flowLayoutPanel1.Width - 5;
            foreach (Control con in flowLayoutPanel1.Controls)
            {
                con.Width = w;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<TableInfo> tblInfoList = new List<TableInfo>();
            int i = 0;
            foreach (UC uc in flowLayoutPanel1.Controls)
            {
                TableInfo info = uc.TblInfo;
                info.Tbl.TableName = "" + i;
                tblInfoList.Add(uc.TblInfo);
            }
            SaveLoad.SaveData(tblInfoList);
        }

        public void ChangeColor(string colName)
        {
            foreach (UC uc in flowLayoutPanel1.Controls)
            {
                uc.ChangeColor(colName);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            UC remUc = null;
            foreach (UC uc in flowLayoutPanel1.Controls)
            {
                if (uc.CheckFocused())
                {
                    remUc = uc;
                }
            }
            if (remUc != null)
            {
                flowLayoutPanel1.Controls.Remove(remUc);

            }
        }

        public void RemoveThis(UC uc)
        {
            flowLayoutPanel1.Controls.Remove(uc);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("現在の状態を保存しますか？",
    "質問",
    MessageBoxButtons.YesNoCancel,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //自動保存
                List<TableInfo> tblInfoList = new List<TableInfo>();
                int i = 0;
                foreach (UC uc in flowLayoutPanel1.Controls)
                {
                    TableInfo info = uc.TblInfo;
                    info.Tbl.TableName = "" + i;
                    tblInfoList.Add(uc.TblInfo);
                }
                SaveLoad.SaveData(tblInfoList);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }



        }
    }
}
















