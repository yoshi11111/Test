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
        public class OneSheet
        {
            public string fileName = string.Empty;
            public string fullPath = string.Empty;
            public string sheetName = string.Empty;
            public List<List<string>> cellValues = new List<List<string>>();
        }


        public ImportForm()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            List<OneSheet> tmpList = new List<OneSheet>();
            if (!ReadExcels(out tmpList))
            {
                MessageBox.Show("取込失敗");
                return;
            }
            Form1.sheetList = tmpList;
            SaveData();
        }

        public List<OneSheet> Read(string fileName)
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

            //範囲指定
            int maxColumn;
            int maxRow;
            if(!int.TryParse(tbColumn.Text, out maxColumn))
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
                string tmp = string.Empty;
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


        private bool ReadExcels(out List<OneSheet> retList)
        {
            bool ret = true;

            string directory = Environment.CurrentDirectory;
            string[] files = Directory.GetFiles(directory);

            // 同ディレクトリのエクセルファイル絶対パス
            List<string> excelFiles = (from file in files
                                       where file.Contains(".xlsx") ||
                                       file.Contains(".xls")
                                       select file).ToList();

            List<Task> taskList = new List<Task>();
            List<OneSheet> tmpList = new List<OneSheet>();
            foreach (string filePath in excelFiles)
            {
                Task t = Task.Run(() =>
                {
                    tmpList.AddRange(Read(filePath));
                });
                taskList.Add(t);
            }
            foreach (Task t in taskList)
            {
                t.Wait();
            }

            retList = tmpList;

            return ret;

        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            Process[] pList = Process.GetProcessesByName("Excel");
            foreach (Process p in pList)
            {
                p.Kill();
            }
        }


        public static readonly string FolderName = Environment.CurrentDirectory;
        public static readonly string FileN = "Data.xml";

        public class ForSaveLoad
        {
            public List<OneSheet> sheetDataList = new List<OneSheet>();
        }



        public static void SaveData()
        {
            //保存先のファイル名
            string fileName = FolderName+ FileN;

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

            //保存するクラス(SampleClass)のインスタンスを作成
            ForSaveLoad f = new ForSaveLoad();

            f.sheetDataList = Form1.sheetList;


            try
            {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, f);
                //ファイルを閉じる
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void LoadData()
        {
            //保存元のファイル名
            string fileName = FolderName + FileN;

            try
            {
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(ForSaveLoad));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                ForSaveLoad obj = (ForSaveLoad)serializer.Deserialize(sr);
                //ファイルを閉じる
                sr.Close();
                Form1.sheetList = obj.sheetDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        

    }
}
