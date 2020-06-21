


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_Test_Data
{
    public partial class UC : UserControl
    {
        public TableInfo TblInfo { get; set; }
        public class TableInfo
        {
            public string TblName { get; set; } = string.Empty;
            public DataTable Tbl { get; set; } = new DataTable();
            public List<ColumnInfo> ColumnInfoList { get; set; } = new List<ColumnInfo>();
        }
        public class ColumnInfo
        {
            public string ColName { get; set; } = string.Empty;
            public Boolean isPkey { get; set; } = false;

            public Boolean isNumber { get; set; } = false;
        }
        public enum DataType
        {
            DateTime,
            Number,
            Varchar,

        }
        public static readonly string ROW_CHECK = "有効/無効";

        public bool CheckFocused()
        {
            foreach (Control con in this.Controls)
            {
                if (con.Focused)
                {
                    return true;
                }
            }
            return false;
        }
        public UC(TableInfo info)
        {
            InitializeComponent();
            this.TblInfo = info;
            tbTableName.Text = this.TblInfo.TblName;
        }


        private void UC_Load(object sender, EventArgs e)
        {
            if (!this.TblInfo.Tbl.Columns.Contains(ROW_CHECK))
            {
                DataColumn col = new DataColumn(ROW_CHECK, new Boolean().GetType());

                TblInfo.Tbl.Columns.Add(col);
            }
            // コンボボックス設定
            //            this.comboBox1.DataSource = this.AuthGroup;
            //this.comboBox1.DisplayMember = "Value";
            //this.comboBox1.ValueMember = "Key";

            //KeyValuePair<DataType, string> kvp;

            //kvp = new KeyValuePair<DataType, string>(DataType.DateTime, "Date");
            //comboBox1.Items.Add(kvp);
            //kvp = new KeyValuePair<DataType, string>(DataType.Number, "Number");
            //comboBox1.Items.Add(kvp);
            //kvp = new KeyValuePair<DataType, string>(DataType.Varchar, "char/Varchar");
            //comboBox1.Items.Add(kvp);


            DataGridView1.DataSource = TblInfo.Tbl;
            for (int i = 0; i < TblInfo.ColumnInfoList.Count; i++)
            {
                if (TblInfo.ColumnInfoList[i].isPkey)
                {
                    DataGridView1.Columns[i].HeaderText += "(PK)";
                }
                if (TblInfo.ColumnInfoList[i].isNumber)
                {
                    DataGridView1.Columns[i].HeaderText += "(Num)";
                }
            }







            //btnAddCol.PerformClick();
            //btnAddRow.PerformClick();

            tbTableName_TextChanged(tbTableName, null);
            ShowLabel();
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(
        object sender, EventArgs e)
        {
            //  if (DataGridView1.SelectedRows.Count < 1)
            //  {
            //      return;
            //  }
            //  DataGridViewRow row = DataGridView1.SelectedRows[0];
            //Boolean? chk =  row.Cells["有効 / 無効"].Value as Boolean?;
            //  Color foreColor;
            //  if (chk == null ||　!(Boolean)chk)
            //  {
            //      foreColor = Color.Gray;
            //  }
            //  else
            //  {
            //      foreColor = Color.Black;
            //  }
            //  foreach(DataGridCell cel in row.Cells)
            //  {

            //      cel.Colo

            //  }

        }

        private void ShowLabel()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (DataGridViewColumn conl in DataGridView1.Columns)
            {
                Label l = new Label();

                KeyValuePair<string, string>[] kvp = (from k in SaveLoad.ItemJPAndValueDic
                                                      where k.Value == conl.Name
                                                      select k).ToArray();
                if (kvp.Length == 0)
                {
                    continue;
                }
                l.Text = kvp[0].Key;

                flowLayoutPanel1.Controls.Add(l);
            }
        }


        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataTable tbl = (DataTable)DataGridView1.DataSource;
            DataRow row = tbl.NewRow();
            tbl.Rows.Add(row);
            DataGridView1.DataSource = tbl;
            ShowLabel();
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedCells.Count != 1)
            {
                return;
            }
            DataTable tbl = (DataTable)DataGridView1.DataSource;
            DataGridViewRow row = DataGridView1.SelectedCells[0].OwningRow;
            tbl.Rows.RemoveAt(row.Index);

            DataGridView1.DataSource = tbl;
        }



        private void btnAddCol_Click(object sender, EventArgs e)
        {
            try
            {
                ColumnInfo addInfo = new ColumnInfo();
                addInfo.ColName = tbColName.Text;
                addInfo.isPkey = chkP.Checked;
                DataColumn dc = new DataColumn(addInfo.ColName);
                TblInfo.Tbl.Columns.Add(dc);

                TblInfo.ColumnInfoList.Add(addInfo);
                ShowLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelCol_Click(object sender, EventArgs e)
        {
            string colName;
            if (!GetSelectedColumnName(out colName) || colName == ROW_CHECK)
            {
                return;
            }
            ColumnInfo colInfo = (from col in TblInfo.ColumnInfoList
                                  where col.ColName == colName
                                  select col).FirstOrDefault();
            if (colInfo != null)
            {
                TblInfo.ColumnInfoList.Remove(colInfo);
            }
            DataTable tbl = (DataTable)DataGridView1.DataSource;
            tbl.Columns.Remove(colName);
            DataGridView1.DataSource = tbl;
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnChangeColName_Click(object sender, EventArgs e)
        //{
        //    string txt = tbChangName.Text;
        //    if (string.IsNullOrEmpty(txt.Trim()))
        //    {
        //        return;
        //    }
        //    string colName;
        //    if (!GetSelectedColumnName(out colName))
        //    {
        //        return;
        //    }
        //    DataTable tbl = (DataTable)DataGridView1.DataSource;

        //    foreach (DataColumn col in tbl.Columns)
        //    {
        //        if(colName== col.ColumnName)
        //        {
        //            col.ColumnName = txt;
        //        }

        //    }
        //    DataGridView1.DataSource = tbl;

        //}

        public bool GetSelectedColumnName(out string str)
        {
            str = string.Empty;
            if (DataGridView1.SelectedCells.Count != 1 || DataGridView1.Rows.Count == 0)
            {
                return false;
            }
            str = DataGridView1.SelectedCells[0].OwningColumn.Name;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            return true;
        }

        private void tbTableName_TextChanged(object sender, EventArgs e)
        {

            Form1 parent = this.ParentForm as Form1;
            if (parent == null)
            {
                return;
            }
            List<string> tblLIst = parent.GetTableNameList(this);
            string tblName = tbTableName.Text.Trim();
            if (tblLIst.Contains(tblName))
            {
                MessageBox.Show("このテーブルは定義済みです。");
                tbTableName.Text = "";
                return;
            }
            KeyValuePair<string, string>[] kvp = (from k in SaveLoad.TableJPAndValueDic
                                                  where k.Value == tblName
                                                  select k).ToArray();

            if (kvp.Length > 0)
            {
                label1.Text = kvp[0].Key;
            }

            this.TblInfo.TblName = tbTableName.Text.Trim();
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedCells.Count == 0)
            {
                return;
            }
            Form1 pa = this.ParentForm as Form1;
            if (pa == null)
            {
                return;
            }
            string colName = DataGridView1.SelectedCells[0].OwningColumn.Name;
            pa.ChangeColor(colName);


        }
        public void ChangeColor(string colName)
        {
            foreach (DataGridViewColumn col in DataGridView1.Columns)
            {
                using (col.HeaderCell.Style.Font)
                {
                    col.HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Regular);
                }

            }


            if (DataGridView1.Columns.Contains(colName))
            {
                using (DataGridView1.Columns[colName].HeaderCell.Style.Font)
                {
                    DataGridView1.Columns[colName].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.ParentForm as Form1;
            if (form1 == null)
            {
                return;
            }
            form1.RemoveThis(this);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedCells.Count != 1)
            {
                return;
            }
            DataTable tbl = (DataTable)DataGridView1.DataSource;
            DataGridViewRow row = DataGridView1.SelectedCells[0].OwningRow;
            DataRow newRow = tbl.NewRow();

            foreach (DataGridViewCell cel in row.Cells)
            {
                newRow[cel.ColumnIndex] = cel.Value;
            }
            tbl.Rows.Add(newRow);


            DataGridView1.DataSource = tbl;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string colName;
            if (!GetSelectedColumnName(out colName) || colName == ROW_CHECK)
            {
                return;
            }
            ColumnInfo colInfo = (from col in TblInfo.ColumnInfoList
                                  where col.ColName == colName
                                  select col).FirstOrDefault();
            if (colInfo != null)
            {
                colInfo.isNumber = !colInfo.isNumber;
            }
        }
    }
}
