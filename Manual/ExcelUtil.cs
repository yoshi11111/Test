using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Manual
{
    public class ExcelUtil
    {
        public static readonly string FileName = Environment.CurrentDirectory + @"\Manual.xlsx";


        public void Export()
        {
            ////Excelオブジェクトの初期化
            //Excel.Application ExcelApp = null;
            //Excel.Workbooks wbs = null;
            //Excel.Workbook wb = null;
            //// Excel.Sheets shs = null;
            //Excel.Worksheet ws = null;

            //try
            //{
            //    //Excelシートのインスタンスを作る
            //    ExcelApp = new Excel.Application();
            //    wbs = ExcelApp.Workbooks;
            //    wb = wbs.Add();
            //    //  shs = wb.Sheets;
            //    ExcelApp.Visible = false;
            //    int sheetNm = 1;
            //    for (int i = 1; i < wb.Worksheets.Count; i++)
            //    {
            //        wb.Worksheets[i].Delete();
            //    }
            //    foreach (Title title in DataMng.TitleList)
            //    {

            //        List<List<string>> values = new List<List<string>>();
            //        List<string> val = new List<string>();
            //        foreach (MajorItem major in title.items)
            //        {
            //            val = new List<string>();
            //            val.Add(major.text);
            //            values.Add(val);

            //            foreach (MiddleItem middle in major.items)
            //            {
            //                val = new List<string>();
            //                val.Add("");
            //                val.Add(middle.text);
            //                values.Add(val);
            //                foreach (SmallItem small in middle.items)
            //                {
            //                    val = new List<string>();
            //                    val.Add("");
            //                    val.Add("");
            //                    val.Add(small.text);
            //                    values.Add(val);
            //                }
            //            }
            //        }

            //        //  ws = wb.Worksheets.Add();
            //    //    wb.Worksheets.Add();
            //        ws = wb.Worksheets[sheetNm];
            //        ws.Name = title.text + sheetNm;
            //        sheetNm++;
            //        //                   wb.Worksheets.Add(After: ws, Count: sheetNm++);
            //        //ws.Select(Type.Missing);
            //        // wb = wbs.Add("name"+sheetNm, sheetNm++);
            //        // ws = wb.Worksheets.Add();
            //        // wb.AddWorksheet(sheetName, 1);
            //        //wb.Worksheets.Add(Type.Missing, wb.Worksheets.Last());
            //        //shs = wb.Sheets;
            //        // エクセルファイルにデータをセットする
            //        // Excelのcell指定

            //        for (int i = 0; i < values.Count; i++)
            //        {
            //            for (int j = 0; j < values[i].Count; j++)
            //            {
            //                Excel.Range w_rgn = ws.Cells;
            //                try
            //                {
            //                    Outputter(w_rgn, i + 1, j + 1, values[i][j]);
            //                }
            //                finally
            //                {
            //                    // Excelのオブジェクトはループごとに開放する
            //                    Marshal.ReleaseComObject(w_rgn);
            //                    w_rgn = null;
            //                }

            //            }

            //        }
            //        Marshal.ReleaseComObject(ws);
            //        ws = null;
            //    }
            //    //excelファイルの保存
            //    wb.SaveAs(FileName);
            //    wb.Close(false);
            //    ExcelApp.Quit();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //    //Excelのオブジェクトを開放し忘れているとプロセスが落ちないため注意
            //    if (ws != null)
            //        Marshal.ReleaseComObject(ws);
            //    //   Marshal.ReleaseComObject(shs);
            //    Marshal.ReleaseComObject(wbs);
            //    Marshal.ReleaseComObject(wb);
            //    Marshal.ReleaseComObject(ExcelApp);
            //    ws = null;
            //    //  shs = null;
            //    wb = null;
            //    wbs = null;
            //    ExcelApp = null;

            //    GC.Collect();
            //}
        }
        public void Outputter(Excel.Range w_rgn, int row, int col, string val)
        {
            // Excelのcell指定
            Excel.Range rgn = w_rgn[row, col];

            try
            {
                // Excelにデータをセット
                rgn.Value2 = val;
            }
            finally
            {
                Marshal.ReleaseComObject(rgn);

                rgn = null;
            }



        }

    }
}
