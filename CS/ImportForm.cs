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

namespace SmallUltraGrid
{
    public partial class ImportForm : Form
    {
        public enum FileType
        {
            Excel,
            Text
        }



        public class OneSheet
        {
            public string fileName = string.Empty;
            public string fullPath = string.Empty;
            public string sheetName = string.Empty;
            public List<List<string>> cellValues = new List<List<string>>();
            public FileType type;
        }

        

        public ImportForm()
        {
            InitializeComponent();
        }

        public void SetTbNum(int col , int row)
        {
            tbColumn.Text = ""+col;
            tbRow.Text = ""+row;
        }


        public void button1_Click(object sender, EventArgs e)
        {

            List<OneSheet> tmpList;
            if (!ReadFiles(out tmpList))
            {
                MessageBox.Show("取込失敗");
                return;
            }
            Form1.sheetList = tmpList;

            SaveData();
        }


        private bool ReadFiles(out List<OneSheet> retList)
        {
            retList = new List<OneSheet>();
            bool ret = true;
            try
            {
                string directory = Environment.CurrentDirectory + @"\";
                string[] files = Directory.GetFiles(directory);

                List<string> excelFiles = (from file in files
                                           where file.Contains(".xlsx") ||
                                           file.Contains(".xls")
                                           select file).ToList();
                List<string> textFiles = (from file in files
                                          where file.Contains(".txt")
                                          select file).ToList();

                List<Task> taskList = new List<Task>();
                List<OneSheet> tmpList = new List<OneSheet>();
                foreach (string filePath in excelFiles)
                {
                    Task t = Task.Run(() =>
                    {
                        tmpList.AddRange(ReadExcel(filePath));
                    });
                    taskList.Add(t);
                }

                foreach (string filePath in textFiles)
                {
                    Task t = Task.Run(() =>
                    {
                        tmpList.AddRange(ReadText(filePath));
                    });
                    taskList.Add(t);
                }


                foreach (Task t in taskList)
                {
                    t.Wait();
                }

                retList = tmpList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ret = false;
            }
            return ret;
        }
        #region テキスト読込

        public List<OneSheet> ReadText(string fileName)
        {
            List<OneSheet> ret = new List<OneSheet>();

            string fName = System.IO.Path.GetFileName(fileName);
            string fullPath = System.IO.Path.GetFullPath(fName);

            StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("SHIFT_JIS"));
            OneSheet os = new OneSheet();
            os.type = FileType.Text;
            os.fileName = fName;
            os.fullPath = fullPath;
            os.sheetName = string.Empty;
            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();
                List<string> rowList = new List<string>();
                rowList.Add(line);
                os.cellValues.Add(rowList);
            }

            ret.Add(os);
            sr.Close();
            return ret;
        }


        #endregion

        #region Excel読込

        public List<OneSheet> ReadExcel(string fileName)
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

            int maxColumn;
            int maxRow;
            if (!int.TryParse(tbColumn.Text, out maxColumn))
            {
                maxColumn = 100;
            }
            if (!int.TryParse(tbRow.Text, out maxRow))
            {
                maxRow = 100;
            }



            string endCell = ToAlph(maxColumn) + maxRow;

            foreach (Worksheet ws in wb.Sheets)
            {
                ws.Select(Type.Missing);
                Range range = ExcelApp.get_Range("A1", endCell);


                OneSheet os = new OneSheet();
                os.type = FileType.Excel;
                os.fileName = fName;
                os.fullPath = fullPath;
                os.sheetName = ws.Name;

                if (range != null)
                {
                    object[,] obj = range.Value2;
                    for (int i = 1; i < maxRow; i++)
                    {
                        List<string> rowList = new List<string>();
                        for (int j = 1; j < maxColumn; j++)
                        {
                            rowList.Add((obj[i, j] != DBNull.Value ? obj[i, j] : string.Empty) + string.Empty);
                        }
                        os.cellValues.Add(rowList);
                    }
                }
                ret.Add(os);
            }

            wb.Close(false, Type.Missing, Type.Missing);
            ExcelApp.Quit();
            return ret;
        }


        public static string ToAlph(int columnNo)
        {
            if (columnNo < 1)
            {
                string tmp = "--";
                for (int i = 0; i <= Math.Abs(columnNo); i++)
                {
                    tmp += " ";
                }
                return tmp;
            }

            string alphabet = "ZABCDEFGHIJKLMNOPQRSTUVWXY";
            string columnStr = string.Empty;
            int m = 0;

            do
            {
                m = columnNo % 26;
                columnStr = alphabet[m] + columnStr;
                columnNo = columnNo / 26;
            } while (0 < columnNo && m != 0);

            return columnStr;
        }


        #endregion

        #region プロセス終了
        private void button2_Click_1(object sender, EventArgs e)
        {
            Process[] pList = Process.GetProcessesByName("Excel");
            foreach (Process p in pList)
            {
                p.Kill();
            }
        }
        #endregion

        #region xml書込読込

        public static readonly string FolderName = Environment.CurrentDirectory + @"\";
        public static readonly string FileN = "Data.xml";

        public class ForSaveLoad
        {
            public List<OneSheet> sheetDataList = new List<OneSheet>();
        }

        public static void SaveData()
        {
            string fileName = FolderName + FileN;

            // バックアップ作成
            for (int i = 5; 0 < i; i--)
            {
                try
                {
                    string file = fileName + i;
                    string dist = fileName + (i + 1);
                    if (File.Exists(dist))
                    {
                        File.Delete(dist);
                    }
                    if (!(1 == i))
                    {
                        File.Move(file, dist);
                    }
                    else
                    {
                        file = fileName;
                        File.Copy(file, dist);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            ForSaveLoad f = new ForSaveLoad();

            f.sheetDataList = Form1.sheetList;


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

        public static void LoadData()
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
                Form1.sheetList = obj.sheetDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        #endregion

    }
}
