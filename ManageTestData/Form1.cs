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

                StringBuilder updateSql = new StringBuilder();

                // insert文は現行使う

                foreach (UC tbl in flowLayoutPanel1.Controls)
                {
                    StringBuilder @set = new StringBuilder();
                    StringBuilder @where = new StringBuilder();

                    string tableName = tbl.TblInfo.TblName;
                    List<ColumnInfo> colInfoList = tbl.TblInfo.ColumnInfoList;
                    DataTable dt = tbl.TblInfo.Tbl;

                    updateSql.Append("UPDATE " + tableName);

                    //                    UPDATE USER_MASTER
                    //SET
                    //    USER_NAME = USER_NAME || ' さん',
                    //    MODIFIED_ON = SYSDATE
                    //WHERE
                    //    DEPT_NO = '1001'

                    foreach (DataRow row in dt.Rows)
                    {
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
                                    @where.Append(" , ");
                                }
                                existsKey = true;
                                @where.Append(ci.ColName + "= '" + row[ci.ColName] + "' ");
                            }
                        }
                        if (!existsKey)
                        {
                            MessageBox.Show(tableName + "テーブルのプライマーキーが指定されていません。");
                            return;
                        }


                        bool existData = false;
                        for (int i = 0; i < row.ItemArray.Count(); i++)
                        {
                            ColumnInfo ci = colInfoList[i];
                            if (ci.ColName == ROW_CHECK)
                            {
                                continue;
                            }
                            if (existData)
                            {
                                @set.Append(",");

                            }
                            existData = true;
                            if (ci.dataType == DataType.DateTime)
                            {
                                @set.Append(ci.ColName + " = TO_DATE('" + row[i] + "', 'yyyy/MM/dd') ");
                            }
                            else if (ci.dataType == DataType.Number)
                            {
                                @set.Append(ci.ColName + " = " + row[i] + " ");
                            }
                            else
                            {
                                @set.Append(ci.ColName + " = '" + row[i] + "' ");
                            }
                        }
                        if (!existData)
                        {
                            MessageBox.Show(tableName + "テーブルで値が設定されていない項目があります");
                            return;
                        }
                        updateSql.Append(" SET " + @set);
                        updateSql.Append(" WHERE " + @where);
                    }
                }
                ResultForm ret = new ResultForm(updateSql.ToString());
                ret.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

    }
}
