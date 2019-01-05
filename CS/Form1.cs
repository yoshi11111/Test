using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmallUltraGrid.ExcelSheetReader;
using static SmallUltraGrid.ImportForm;
using static System.Windows.Forms.ListView;

namespace SmallUltraGrid
{
    public partial class Form1 : Form
    {
        public static List<OneSheet> sheetList = new List<OneSheet>();

        public int gridStartRow = 0;

        public class ItemInfo
        {
            public string FileName;
            public string FilePath;
            public string SheetName;
            public string ListStr;
            public List<List<string>> GridStrs;
            public int Col;
            public int Row;
            public string Range;
        }



        public Form1()
        {
            InitializeComponent();

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            gridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //セルの内容に合わせて、行の高さが自動的に調節されるようにする
            gridResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridResult.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            ImportForm f = new ImportForm();
            try
            {
                f.ShowDialog();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (f != null && !f.IsDisposed)
                {
                    f.Dispose();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImportForm.LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string word = tbSearch.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                return;
            }
            bool prfctMtch = chkMch.Checked;
            List<ItemInfo> retList = new List<ItemInfo>();
            foreach (OneSheet os in sheetList)
            {
                string fileName = os.fileName;
                string filePath = os.fullPath;
                string sheetName = os.sheetName;
                for (int i = 0; i < os.cellValues.Count; i++)
                {
                    for (int j = 0; j < os.cellValues[i].Count; j++)
                    {
                        if (IsMatch(prfctMtch, word, os.cellValues[i][j]))
                        {
                            ItemInfo tmp = new ItemInfo();
                            tmp.FileName = fileName;
                            tmp.FilePath = filePath;
                            tmp.SheetName = sheetName;
                            tmp.ListStr = os.cellValues[i][j];
                            tmp.GridStrs = GetGridStr(os.cellValues, i, j);
                            tmp.Col = i + 1;
                            tmp.Row = j + 1;
                            tmp.Range = ImportForm.ToAlph(tmp.Col) + tmp.Row;
                            retList.Add(tmp);
                        }
                    }
                }
            }
            listResult.Items.Clear();

            foreach (ItemInfo ii in retList)
            {
                ListViewItem lvi = new ListViewItem(new string[] { ii.ListStr, ii.FileName, ii.SheetName });
                lvi.Tag = ii;
                listResult.Items.Add(lvi);
            }
            RSzLVClmn();
        }

        private void RSzLVClmn()
        {
            int listColNum = listResult.Columns.Count;
            int gridRowNum = gridResult.Rows.Count;
            if (listColNum < 1 || gridRowNum < 1)
            {
                return;
            }


            int listW = listResult.Width / listColNum;
            foreach (ColumnHeader ch in listResult.Columns)
            {
                ch.Width = listW;
            }

            int gridH = (panel1.Height - 20) / gridRowNum;
            foreach (DataGridViewRow row in gridResult.Rows)
            {
                row.Height = gridH;
            }


        }

        public List<List<string>> GetGridStr(List<List<string>> arr, int i, int j)
        {
            List<List<string>> ret = new List<List<string>>();
            for (int i1 = -2; i1 < 3; i1++)
            {
                List<string> tmp = new List<string>();
                for (int j1 = -2; j1 < 3; j1++)
                {
                    try
                    {
                        tmp.Add(arr[i - i1][j - j1]);
                    }
                    catch
                    {
                        tmp.Add(string.Empty);
                    }
                }
                ret.Add(tmp);
            }


            return ret;
        }


        private bool IsMatch(bool prfctMtch, string word, string cellVal)
        {

            if (cellVal.Contains(word))
            {
                return true;
            }
            if (prfctMtch)
            {
                int length = word.Length;
                if (length > 1)
                {
                    string wd1 = word.Substring(0, length - 1);
                    string wd2 = word.Substring(1, length - 1);
                    if (cellVal.Contains(wd1) ||
                        cellVal.Contains(wd2))
                    {
                        return true;
                    }

                    if (length > 3)
                    {
                        string wd31 = word.Substring(0, 2);
                        string wd32 = word.Substring(length - 2, 2);

                        if (cellVal.Contains(wd31) &&
                          cellVal.Contains(wd32))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }




        private void gridList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedListViewItemCollection items = listResult.SelectedItems;
            if (items == null || items.Count < 1)
            {
                return;
            }
            ListViewItem item = items[0];
            ItemInfo ii = item.Tag as ItemInfo;
            if (ii == null)
            {
                return;
            }

            gridResult.DataSource = null;
            List<string> columnList = new List<string>();
            for (int i = -2; i < 3; i++)
            {
                columnList.Add(ImportForm.ToAlph(ii.Col + i));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add(columnList[0]);
            dt.Columns.Add(columnList[1]);
            dt.Columns.Add(columnList[2]);
            dt.Columns.Add(columnList[3]);
            dt.Columns.Add(columnList[4]);


            List<List<string>> gridStrs = ii.GridStrs;

            foreach (List<string> list in gridStrs)
            {
                DataRow dr = dt.NewRow();
                try
                {
                    dr[0] = list[0];
                    dr[1] = list[1];
                    dr[2] = list[2];
                    dr[3] = list[3];
                    dr[4] = list[4];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                dt.Rows.Add(dr);
            }
            gridResult.DataSource = dt;

            foreach (string col in columnList)
            {
                gridResult.Columns[col].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            try
            {
                foreach (DataGridViewRow row in gridResult.Rows)
                {
                    row.Selected = false;
                }
                gridResult.Rows[2].Cells[2].Selected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            gridStartRow = ii.Row - 2;
            RSzLVClmn();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImportForm f = new ImportForm();
            f.Visible = false;
            f.button1_Click(null, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RSzLVClmn();
        }

        private void gridResult_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {



            DataGridView dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                int idx = e.RowIndex + gridStartRow;
                if (idx < 1)
                {
                    return;
                }

                //行番号を描画する範囲を決定する
                Rectangle rect = new Rectangle(
                    e.RowBounds.Left, e.RowBounds.Top,
                    dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                //行番号を描画する
                TextRenderer.DrawText(e.Graphics,
                                    (idx).ToString(),
                                    e.InheritedRowStyle.Font,
                                    rect,
                                    e.InheritedRowStyle.ForeColor,
                                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
