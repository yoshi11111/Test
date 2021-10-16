using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SmallUltraGrid
{
    public class ExcelSheetReader
    {
       



        //private string fileName = string.Empty;

        ///// <summary>
        ///// 指定されたパスのエクセルワークブックを開く
        ///// </summary>
        ///// <param name="filePath">エクセルワークブックのパス(相対パスでも絶対パスでもOK)</param>
        ///// <returns>エクセルワークブックのオープンに成功したら true. それ以外 false.</returns>
        //protected bool Open(string filePath)
        //{
        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        mApp = new Microsoft.Office.Interop.Excel.Application();
        //        mApp.Visible = false;

        //        // filePath が相対パスのとき例外が発生するので fullPath に変換
        //        string fullPath = System.IO.Path.GetFullPath(filePath);
        //        this.fileName = System.IO.Path.GetFileName(filePath);
        //        mWorkBook = mApp.Workbooks.Open(fullPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        Close();
        //        Console.WriteLine(ex);

        //        return false;
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// 開いているワークブックとエクセルのプロセスを閉じる.
        ///// </summary>
        //protected void Close()
        //{
        //    if (mWorkBook != null)
        //    {
        //        mWorkBook.Close();
        //        Marshal.ReleaseComObject(mWorkBook);
        //        mWorkBook = null;
        //    }

        //    if (mApp != null)
        //    {
        //        mApp.Quit();
        //        Marshal.ReleaseComObject(mApp);
        //        mApp = null;
        //    }
        //}

        //~ExcelSheetReader()
        //{
        //    Close();
        //}

        //protected Microsoft.Office.Interop.Excel.Application mApp = null;
        //protected Microsoft.Office.Interop.Excel.Workbook mWorkBook = null;
        ///// <summary>
        ///// エクセルファイルの指定したシートを2次元配列に読み込む.
        ///// </summary>
        ///// <param name="filePath">エクセルファイルのパス</param>
        ///// <param name="sheetIndex">シートの番号 (1, 2, 3, ...)</param>
        ///// <param name="startRow">最初の行 (>= 1)</param>
        ///// <param name="startColmn">最初の列 (>= 1)</param>
        ///// <param name="lastRow">最後の行</param>
        ///// <param name="lastColmn">最後の列</param>
        ///// <returns>シート情報を格納した2次元文字配列. ただしファイル読み込みに失敗したときには null.</returns>
        //public List<OneSheet> Read(string filePath)
        //{
        //    List<OneSheet> ret = new List<OneSheet>();
        //    List<Microsoft.Office.Interop.Excel.Worksheet> sheetList = new List<Excel.Worksheet>();
        //    try
        //    {

        //        // ワークブックを開く
        //        if (!Open(filePath)) { return ret; }

        //        List<Task> taskList = new List<Task>();

        //        for (int sheetIdx = 1; sheetIdx <= mWorkBook.Sheets.Count; sheetIdx++)
        //        {

        //            Microsoft.Office.Interop.Excel.Worksheet sheet = mWorkBook.Sheets[sheetIdx];
        //            sheetList.Add(sheet);

        //            // sheet.Select();
        //            int lastRow = 100;
        //            int lastColmn = 100;


        //            OneSheet one = new OneSheet();
        //            one.fileName = this.fileName;
        //            one.sheetName = sheet.Name;
        //            Task t = Task.Run(() =>
        //            {
        //                for (int r = 1; r < lastRow - 1; r++)
        //                {

        //                    // 一行読み込む
        //                    string row = string.Empty;
        //                    for (int c = 1; c < lastColmn - 1; c++)
        //                    {


        //                        Microsoft.Office.Interop.Excel.Range xlRange = sheet.Cells[r, c] as Microsoft.Office.Interop.Excel.Range;
        //                        //                            var cell = sheet.Cells[r, c];
        //                        if (xlRange == null || xlRange.Value == null)
        //                        {
        //                            row += string.Empty;
        //                        }
        //                        else
        //                        {
        //                            row += xlRange.Value.ToString();
        //                        }
        //                        row += Sepalator;

        //                    }
        //                    one.rowValues[r] = Sepalator;

        //                }

        //            });
        //            taskList.Add(t);

        //            foreach (Task tsk in taskList)
        //            {
        //                tsk.Wait();
        //            }
        //            ret.Add(one);



        //        }

        //        // ワークブックとエクセルのプロセスを閉じる
        //        Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            // ワークシートを閉じる
        //            foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in sheetList)
        //            {
        //                if (sheet != null)
        //                {
        //                    Marshal.ReleaseComObject(sheet);
        //                }
        //            }
        //            if (mWorkBook != null)
        //            {
        //                Marshal.ReleaseComObject(mWorkBook);
        //            }
        //            if (mApp != null)
        //            {
        //                Marshal.ReleaseComObject(mApp);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //        }
        //    }


        //    return ret;
        //}
    }
}
