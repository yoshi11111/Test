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
    public partial class UC2 : UserControl
    {
        public TableInfo Info { get; set; }
        public class TableInfo
        {
            public string TblName { get; set; }
            public DataTable Tbl = new DataTable();
            public List<ColumnInfo> ColumnInfoList = new List<ColumnInfo>();
        }
        public class ColumnInfo
        {
            public string ColName { get; set; }
            public DataType dataType { get; set; }
            public Boolean isPkey { get; set; }
        }
        public enum DataType
        {
            None,
            DateTime,
            Number,
            Varchar,

        }
        public const string ROW_CHECK = "有効/無効";


        public UC2()
        {
            InitializeComponent();
        }


        private void UC_Load(object sender, EventArgs e)
        {
            Info = new TableInfo();
            if (!Info.Tbl.Columns.Contains(ROW_CHECK))
            {
                DataColumn col = new DataColumn(ROW_CHECK, new Boolean().GetType());
                Info.Tbl.Columns.Add(col);
            }
            // コンボボックス設定
            //            this.comboBox1.DataSource = this.AuthGroup;
            this.comboBox1.DisplayMember = "Value";
            this.comboBox1.ValueMember = "Key";

            KeyValuePair<DataType, string> kvp;
            kvp = new KeyValuePair<DataType, string>(DataType.None, "");
            comboBox1.Items.Add(kvp);
            kvp = new KeyValuePair<DataType, string>(DataType.DateTime, "Date");
            comboBox1.Items.Add(kvp);
            kvp = new KeyValuePair<DataType, string>(DataType.Number, "Number");
            comboBox1.Items.Add(kvp);
            kvp = new KeyValuePair<DataType, string>(DataType.Varchar, "char/Varchar");
            comboBox1.Items.Add(kvp);


            DataGridView1.DataSource = Info.Tbl;
            btnAddCol.PerformClick();
            btnAddRow.PerformClick();

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


        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataTable tbl = (DataTable)DataGridView1.DataSource;
            DataRow row = tbl.NewRow();
            tbl.Rows.Add(row);
            DataGridView1.DataSource = tbl;
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
            int val = comboBox1.SelectedIndex;
            if (val < 0)
            {
                return;
            }
            ColumnInfo colInfo = (from col in Info.ColumnInfoList
                                  where col.ColName == colName
                                  select col).FirstOrDefault();
            if (colInfo != null)
            {
                MessageBox.Show("そのカラム名は既に設定されています。");
            }


            ColumnInfo colInfo = new ColumnInfo();

            KeyValuePair<DataType, string> kvp = (KeyValuePair<DataType, string>)comboBox1.Items[val];
            colInfo.dataType = (DataType)kvp.Key;
            colInfo.ColName = tbColName.Text;
            colInfo.isPkey = chkP.Checked;

            DataColumn col = new DataColumn(colInfo.ColName);
            Info.Tbl.Columns.Add(col);
        }

        private void btnDelCol_Click(object sender, EventArgs e)
        {
            string colName;
            if (GetSelectedColumnName(out colName) || colName == ROW_CHECK)
            {
                return;
            }
            ColumnInfo colInfo = (from col in Info.ColumnInfoList
                                  where col.ColName == colName
                                  select col).FirstOrDefault();
            if (colInfo != null)
            {
                Info.ColumnInfoList.Remove(colInfo);
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
            if (DataGridView1.SelectedCells.Count != 1)
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

    }
}
