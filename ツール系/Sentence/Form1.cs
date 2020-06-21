using Microsoft.VisualBasic;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            public FileType type;
        }

        public Form1()
        {
            InitializeComponent();

            gridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridResult.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string manualFile = ".xls";
            Process.Start(manualFile);
        }
        bool closeOpe = false;
        private void setComponents()
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Icon = SentenceSearch.Properties.Resources.app;

            icon.Visible = true;
            icon.Text = "常駐アプリテスト";
            icon.MouseDown += new MouseEventHandler(IconClicked);
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem menuItem2 = new ToolStripMenuItem();
            menuItem2.Text = "&exit";
            menuItem2.Click += new EventHandler(Close_Click);
            menu.Items.Add(menuItem2);
            icon.ContextMenuStrip = menu;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            closeOpe = true;
            System.Windows.Forms.Application.Exit();
        }
        private void IconClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = !this.Visible;
                if (this.Visible)
                {
                    this.BringToFront();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.setComponents();
            ImportForm.LoadData();

            //    btnReload.Enabled = false;

            btnShow.Enabled = false;
            btnShow.Visible = false;

            RSzLVClmn();



        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox2.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeOpe)
            {
                e.Cancel = true;

            }
            this.Visible = false;
        }
        #region 検索とリストビュー表示

        private void button1_Click(object sender, EventArgs e)
        {
            string word = richTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                return;
            }


            List<ItemInfo> retList = new List<ItemInfo>();
            foreach (OneSheet os in sheetList)
            {
                string fileName = os.fileName;
                string filePath = os.fullPath;
                string sheetName = os.sheetName;
                string[] del = new string[] { "。" };

                for (int i = 0; i < os.cellValues.Count; i++)
                {
                    for (int j = 0; j < os.cellValues[i].Count; j++)
                    {
                        if (string.IsNullOrWhiteSpace(os.cellValues[i][j]))
                        {
                            continue;
                        }
                        foreach (string str in os.cellValues[i][j].Split(del, StringSplitOptions.None))
                        {
                            if (str.Length < 5)
                            {
                                continue;
                            }

                            if (IsMatch(word, str))
                            {
                                ItemInfo tmp = new ItemInfo();
                                tmp.FileName = fileName;
                                tmp.FilePath = filePath;
                                tmp.SheetName = sheetName;
                                tmp.type = os.type;
                                tmp.ListStr = str;
                                tmp.GridStrs = GetGridStr(os.type, os.cellValues, i, j);
                                tmp.Row = i + 1;
                                tmp.Col = j + 1;
                                tmp.Range = ImportForm.ToAlph(tmp.Col) + tmp.Row;
                                retList.Add(tmp);
                            }
                        }
                    }
                }
            }
            listResult.Items.Clear();

            foreach (ItemInfo ii in retList)
            {
                string[] contents;
                if (ii.type == FileType.Excel)
                {
                    contents = new string[] { ii.ListStr, ii.FileName, ii.SheetName, ii.Range };
                }
                else
                {
                    contents = new string[] { ii.ListStr, ii.FileName, "", "" };
                }
                ListViewItem lvi = new ListViewItem(contents);
                lvi.Tag = ii;
                listResult.Items.Add(lvi);
            }
            RSzLVClmn();
        }

        private bool IsMatch(string word, string cellVal)
        {
            if (cellVal.Contains(word))
            {
                return true;
            }
            if (chkPrfct.Checked)
            {
                return false;
            }
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
            if (!chkAbst.Checked)
            {
                return false;
            }
            // あいまい検索
            if (Strings.StrConv(cellVal, VbStrConv.Hiragana)
                .Contains(Strings.StrConv(word, VbStrConv.Hiragana)))
            {
                return true;
            }

            //全角を半角に変換して比較
            if (Microsoft.VisualBasic.Strings.StrConv(cellVal, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411)
                .Contains(Microsoft.VisualBasic.Strings.StrConv(word, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411)))
            {
                return true;
            }


            return false;
        }

        #endregion

        #region 幅高さ調整
        private void Form1_Resize(object sender, EventArgs e)
        {
            RSzLVClmn();
        }

        private void RSzLVClmn()
        {
            int listColNum = listResult.Columns.Count;
            int gridRowNum = gridResult.Rows.Count;
            if (listColNum < 1)
            {
                return;
            }


            int listW = (listResult.Width - 20) / (listColNum + 1);
            listResult.Columns[0].Width = listW * 5;
            listResult.Columns[1].Width = listW / 2;
            listResult.Columns[2].Width = listW / 2;
            listResult.Columns[3].Width = listW / 2;

            if (gridRowNum < 1)
            {
                return;
            }


            //int gridH = (panel1.Height - 20) / gridRowNum;
            //foreach (DataGridViewRow row in gridResult.Rows)
            //{
            //    row.Height = gridH;
            //}



            int gridColumnNum = gridResult.Columns.Count;
            DataTable dt = gridResult.DataSource as DataTable;
            if (gridColumnNum < 1 || dt == null)
            {
                return;
            }

            int defaultWidth = (panel1.Width - 10) / gridColumnNum;
            foreach (DataGridViewColumn col in gridResult.Columns)
            {
                bool noData = false;
                if (col.Name.Trim() == "--")
                {
                    noData = true;
                }
                else
                {

                    string sql = col.Name + " <> " + "''";
                    if (!(dt.Select(sql).Count() > 0))
                    {
                        noData = true;
                    }

                }
                if (noData)
                {
                    col.Width = 30;
                }

            }

        }
        #endregion

        #region リストアイテム選択・ファイル表示
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

            if (ii.type == FileType.Excel)
            {
                ExcelSelected(ii);
            }
            if (ii.type == FileType.Text)
            {
                TextSelected(ii);
            }
            richTextBox1.Text = ii.ListStr;

        }

        public void TextSelected(ItemInfo ii)
        {
            string columnName = "Text";
            gridResult.DataSource = null;

            DataTable dt = new DataTable();
            dt.Columns.Add(columnName);

            List<List<string>> gridStrs = ii.GridStrs;

            foreach (List<string> row in gridStrs)
            {
                DataRow dr = dt.NewRow();
                try
                {
                    dr[0] = row[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                dt.Rows.Add(dr);
            }
            gridResult.DataSource = dt;
            gridResult.Columns[columnName].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            try
            {
                foreach (DataGridViewRow row in gridResult.Rows)
                {
                    row.Selected = false;
                }
                gridResult.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            gridStartRow = ii.Row;
            RSzLVClmn();
        }

        public void ExcelSelected(ItemInfo ii)
        {

            gridResult.DataSource = null;
            List<string> columnList = new List<string>();
            for (int i = -3; i < 4; i++)
            {
                columnList.Add(ImportForm.ToAlph(ii.Col + i));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add(columnList[0]);
            dt.Columns.Add(columnList[1]);
            dt.Columns.Add(columnList[2]);
            dt.Columns.Add(columnList[3]);
            dt.Columns.Add(columnList[4]);
            dt.Columns.Add(columnList[5]);
            dt.Columns.Add(columnList[6]);


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
                    dr[5] = list[5];
                    dr[6] = list[6];

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
                gridResult.Rows[3].Cells[3].Selected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            gridStartRow = ii.Row - 3;
            RSzLVClmn();
        }



        public List<List<string>> GetGridStr(FileType type, List<List<string>> arr, int i, int j)
        {
            List<List<string>> ret = new List<List<string>>();
            if (type == FileType.Excel)
            {
                ret = new List<List<string>>();
                for (int i1 = -3; i1 < 4; i1++)
                {
                    List<string> tmp = new List<string>();
                    for (int j1 = -3; j1 < 4; j1++)
                    {
                        try
                        {
                            tmp.Add(arr[i + i1][j + j1]);
                        }
                        catch
                        {
                            tmp.Add(string.Empty);
                        }
                    }
                    ret.Add(tmp);
                }
            }

            if (type == FileType.Text)
            {
                ret = new List<List<string>>();

                for (int i1 = 0; i1 < 50; i1++)
                {
                    try
                    {
                        List<string> tmp = new List<string>();
                        tmp.Add(arr[i + i1][0]);
                        ret.Add(tmp);
                    }
                    catch
                    {
                        List<string> tmp = new List<string>();
                        tmp.Add(string.Empty);
                        ret.Add(tmp);
                    }
                }

            }

            return ret;
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

                Rectangle rect = new Rectangle(
                    e.RowBounds.Left, e.RowBounds.Top,
                    dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics,
                                    (idx).ToString(),
                                    e.InheritedRowStyle.Font,
                                    rect,
                                    e.InheritedRowStyle.ForeColor,
                                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void listResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!chDouble.Checked)
            {
                return;
            }
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


            try
            {
                string filePpath = ii.FilePath;
                using (Process p = Process.Start(filePpath))
                {
                    p.WaitForInputIdle(4000);
                    //SendKeys.Send("^G");
                    //SendKeys.Send(ii.SheetName + "!" + ii.Range);
                    //SendKeys.Send("~");

                }

            }
            catch { }




        }
        #endregion

        #region データ取り込み


        private void btnReload_Click(object sender, EventArgs e)
        {
            using (ImportForm f = new ImportForm())
            {
                f.Visible = false;
                f.SetTbNum(100, 100);
                f.button1_Click(null, null);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            using (ImportForm f = new ImportForm())
            {
                try
                {
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        #endregion


    }
}
