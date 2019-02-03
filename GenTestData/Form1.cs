using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DataGenerator
{
    public partial class Form1 : Form
    {

        #region コンストラクタ
        public Form1()
        {
            InitializeComponent();
            LoadXml();
        }
        #endregion

        #region テーブル定義に基づきデータINSERT用SQL作成
        public class TableInfo
        {
            public string TableName { get; set; }
            public string TableNameJa { get; set; }
            public List<ColumnInfo> ColNameAndSize { get; set; }
        }
        public class ColumnInfo
        {
            public string ColName { get; set; }
            public int Size { get; set; }
        }

        public class RowData
        {
            public string TableName { get; set; }
            public Dictionary<string, string> colAndVal;
        }
        public List<TableInfo> TableInfoList;



        private void button1_Click_2(object sender, EventArgs e)
        {
            List<RowData> rowDataList = new List<RowData>(); ;

            Dictionary<string, string> fixedData = new Dictionary<string, string>();
            int seed = DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;

            foreach (TableInfo tbl in this.TableInfoList)
            {
                RowData row = new RowData();
                row.colAndVal = new Dictionary<string, string>();
                row.TableName = tbl.TableName;
                Random ran = new Random(seed);

                foreach (ColumnInfo colInfo in tbl.ColNameAndSize)
                {

                    string val = "";
                    if (fixedData.ContainsKey(colInfo.ColName))
                    {
                        val = fixedData[colInfo.ColName];
                    }
                    else
                    {
                        for (int i = 0; i < colInfo.Size; i++)
                        {
                            if (seed > int.MaxValue / 3)
                            {
                                seed = 0;
                            }
                            seed += ran.Next(1, 10);
                            val += ran.Next(1, 10);

                        }
                        fixedData[colInfo.ColName] = val;
                    }
                    row.colAndVal[colInfo.ColName] = val;
                }
                rowDataList.Add(row);
            }

            CreateSql(rowDataList);
        }
        public void CreateSql(List<RowData> rdList)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder into = new StringBuilder();
            StringBuilder values = new StringBuilder();


            foreach (RowData rd in rdList)
            {
                sql.Append(" INSERT INTO " + rd.TableName + " ( ");
                into = new StringBuilder();
                values = new StringBuilder();

                foreach (KeyValuePair<string, string> kvp in rd.colAndVal)
                {
                    into.Append(kvp.Key + ", ");
                    values.Append(kvp.Value + ", ");
                }
                sql.AppendLine(into.ToString().TrimEnd(' ', ',') + " ) ");
                sql.AppendLine(" VALUES( " + values.ToString().TrimEnd(' ', ',') + " ); ");
                sql.AppendLine("");
            }

            ResultForm ret = new ResultForm(sql.ToString());
            ret.Show();
        }
        #endregion

        #region テーブル定義書からTableInfo.xmlを生成

        public static readonly string FolderName = Environment.CurrentDirectory + @"\";
        public static readonly string FileN = "TableInfo.xml";
        public List<string> SheetNameList = new List<string>();

        public class ForSaveLoad
        {
            public List<TableInfo> sheetDataList = new List<TableInfo>();
        }

        public class OneSheet
        {
            public string sheetName = string.Empty;
            public System.Data.DataTable cellValues = new System.Data.DataTable();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "(*.xlsx;*.xls)|*.xlsx;*.xls";
            ofd.Title = "ローカルにコピーしたテーブル定義ファイルを選択してください";
            //ダイアログを表示する
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            textBox1.Text = ofd.FileName;
            this.SheetNameList = ReadSheetNames(textBox1.Text);
            flowLayoutPanel1.Controls.Clear();
            foreach (string sheetName in SheetNameList)
            {
                System.Windows.Forms.CheckBox cb = new System.Windows.Forms.CheckBox();
                cb.Text = sheetName;
                cb.Checked = true;
                flowLayoutPanel1.Controls.Add(cb);
            }

        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                this.SheetNameList = new List<string>();
                foreach (System.Windows.Forms.CheckBox cb in flowLayoutPanel1.Controls)
                {
                    if (!cb.Checked)
                    {
                        continue;
                    }
                    SheetNameList.Add(cb.Text);
                }
                string tblNmCol = tbTblNmCol.Text.Trim();
                int tblNmRow = 0;
                string colNameCol = tbColName.Text.Trim();
                string sizeCol = tbSize.Text.Trim();

                if (SheetNameList.Count <= 0 ||
                    string.IsNullOrEmpty(tblNmCol)
                    || !int.TryParse(tbTblNmRow.Text.Trim(), out tblNmRow)
                    || string.IsNullOrEmpty(colNameCol)
                    || string.IsNullOrEmpty(sizeCol))
                {
                    MessageBox.Show("入力エラー");
                    return;
                }

                List<OneSheet> sheetInfoList = ReadExcel(textBox1.Text, this.SheetNameList);
                this.TableInfoList = AnalyzeSheets(sheetInfoList, tblNmCol, tblNmRow, colNameCol, sizeCol);
                SaveXml();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private List<TableInfo> AnalyzeSheets(List<OneSheet> sheetInfoList, string tblNmCol, int tblNmRow, string colNmCol, string sizeCol)
        {
            List<TableInfo> ret = new List<TableInfo>();
            foreach (OneSheet os in sheetInfoList)
            {
                TableInfo info = new TableInfo();
                info.ColNameAndSize = new List<ColumnInfo>();
                info.TableName = os.cellValues.Rows[tblNmRow - 1][tblNmCol].ToString();

                var targetRows = from row in os.cellValues.Rows.OfType<DataRow>()
                                 where !string.IsNullOrEmpty(row[colNmCol].ToString().Trim()) &&
                                 !Regex.IsMatch(row[colNmCol].ToString(), @"[^a-zA-z0-9-_]")
                                 ////      where Regex.IsMatch(row[colNmCol].ToString(), @"^[!-~]*$") // 一文字以上の半角英数字と記号
                                 select row;
                foreach (DataRow row in targetRows)
                {
                    string colNm = row[colNmCol].ToString().Trim();
                    string sizeStr = row[sizeCol].ToString().Trim();
                    if (string.IsNullOrEmpty(colNm))
                    {
                        continue;
                    }
                    int size;
                    if (!int.TryParse(sizeStr, out size))
                    {
                        size = 2;
                    }
                    ColumnInfo colInfo = (from ci in info.ColNameAndSize
                                          where ci.ColName == colNm
                                          select ci).FirstOrDefault();
                    if (colInfo == null)
                    {
                        colInfo = new ColumnInfo();
                        colInfo.ColName = colNm;
                    }
                    colInfo.Size = size;

                    info.ColNameAndSize.Add(colInfo);
                }
                ret.Add(info);
            }

            return ret;
        }
        private List<string> ReadSheetNames(string fileName)
        {
            List<string> ret = new List<string>();
            string ExcelBookFileName = fileName;

            Excel.Application ExcelApp = new Excel.Application();
            ExcelApp.Visible = false;
            Workbook wb = ExcelApp.Workbooks.Open(ExcelBookFileName,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Type.Missing);

            string fName = System.IO.Path.GetFileName(fileName);
            string fullPath = System.IO.Path.GetFullPath(fName);
            foreach (Worksheet ws in wb.Sheets)
            {
                ret.Add(ws.Name);
            }
            wb.Close(false, Type.Missing, Type.Missing);
            ExcelApp.Quit();
            return ret;
        }

        public List<OneSheet> ReadExcel(string fileName, List<string> sheetnameList)
        {
            List<OneSheet> ret = new List<OneSheet>();

            string ExcelBookFileName = fileName;

            Microsoft.Office.Interop.Excel.Application ExcelApp
              = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = false;
            Workbook wb = ExcelApp.Workbooks.Open(ExcelBookFileName,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Type.Missing);

            string fName = System.IO.Path.GetFileName(fileName);
            string fullPath = System.IO.Path.GetFullPath(fName);

            int maxColumn = 100;
            int maxRow = 200;
            string endCell = ToColumnName(maxColumn) + maxRow;
            foreach (Worksheet ws in wb.Sheets)
            {
                // 対象シートのみ
                if (!sheetnameList.Contains(ws.Name))
                {
                    continue;
                }
                ws.Select(Type.Missing);
                Range range = ExcelApp.get_Range("A1", endCell);
                OneSheet os = new OneSheet();
                os.sheetName = ws.Name;

                if (range != null)
                {
                    object[,] obj = range.Value2;
                    for (int j = 1; j < maxColumn; j++)
                    {
                        os.cellValues.Columns.Add(ToColumnName(j));
                    }
                    for (int i = 1; i < maxRow; i++)
                    {
                        DataRow row = os.cellValues.NewRow();
                        List<string> rowList = new List<string>();
                        for (int j = 1; j < maxColumn; j++)
                        {
                            row[ToColumnName(j)] = (obj[i, j] == DBNull.Value ? string.Empty : "" + obj[i, j]);
                        }
                        os.cellValues.Rows.Add(row);
                    }
                }
                ret.Add(os);
            }
            wb.Close(false, Type.Missing, Type.Missing);
            ExcelApp.Quit();
            return ret;
        }

        private string ToColumnName(int index)
        {
            index--;
            string str = "";
            do
            {
                str = Convert.ToChar(index % 26 + 0x41) + str;
            } while ((index = index / 26 - 1) != -1);

            return str;
        }
        #endregion

        #region Excelプロセス終了
        private void btnExcellKill_Click(object sender, EventArgs e)
        {
            Process[] pList = Process.GetProcessesByName("Excel");
            foreach (Process p in pList)
            {
                p.Kill();
            }
        }
        #endregion

        #region TableInfo.xml保存・読込
        public void SaveXml()
        {
            string fileName = FolderName + FileN;
            ForSaveLoad f = new ForSaveLoad();
            f.sheetDataList = this.TableInfoList;

            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                serializer.Serialize(sw, f);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void LoadXml()
        {
            string fileName = FolderName + FileN;

            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                ForSaveLoad obj = (ForSaveLoad)serializer.Deserialize(sr);
                sr.Close();
                this.TableInfoList = obj.sheetDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion
    }
}

