using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Vbe.Interop;
using static Manual.DataMng;

namespace Manual
{
    public class OutputUtil
    {

        public static readonly string FileName = Environment.CurrentDirectory + @"\Manual.xlsx";


        public void ExcelExport()
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
        //public void Outputter(Excel.Range w_rgn, int row, int col, string val)
        //{
        //    // Excelのcell指定
        //    Excel.Range rgn = w_rgn[row, col];

        //    try
        //    {
        //        // Excelにデータをセット
        //        rgn.Value2 = val;
        //    }
        //    finally
        //    {
        //        Marshal.ReleaseComObject(rgn);

        //        rgn = null;
        //    }



        //}

        public void WordExport()
        {
            Document document = null;
            Word.Application word = null;
            try
            {


                // Word アプリケーションオブジェクトを作成
                word = new Word.Application();
                // Word の GUI を起動しないようにする
                word.Visible = false;

                // 新規文書を作成
                document = word.Documents.Add();

                //// ヘッダーを編集
                //editHeaderSample(ref document, 10, WdColorIndex.wdPink, "Header Area");

                //// フッターを編集
                //editFooterSample(ref document, 10, WdColorIndex.wdBlue, "Footer Area");

                //// 見出しを追加
                //addHeadingSample(ref document, "見出し");

                //// パラグラフを追加
                //document.Content.Paragraphs.Add();

                //// テキストを追加
                //addTextSample(ref document, WdColorIndex.wdGreen, "Hello, ");
                //addTextSample(ref document, WdColorIndex.wdRed, "World");

                foreach (Title ttl in TitleList)
                {
                    if (string.IsNullOrWhiteSpace(ttl.Rtf.Replace("\r\n", "")) ||
                        string.IsNullOrWhiteSpace(ttl.Text.Trim()))
                    {
                        continue;
                    }
                    word.Selection.Start = document.Content.End;
                    word.Selection.End = document.Content.End;
                    word.Selection.InsertBreak();

                    addTextSample(ref document, WdColorIndex.wdGreen, "【" + ttl.Text + "】" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    word.Selection.Start = document.Content.End;
                    word.Selection.End = document.Content.End;


                    Clipboard.SetText(ttl.Rtf, System.Windows.Forms.TextDataFormat.Rtf);

                    word.Selection.Paste();




                }
                // 名前を付けて保存
                object filename = System.IO.Directory.GetCurrentDirectory() + @"\out.docx";
                document.SaveAs2(ref filename);

                // 文書を閉じる


                Console.WriteLine("Document created successfully !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                document.Close();
                document = null;
                word.Quit();
                word = null;

            }

        }
        /// <summary>
        /// 文書のヘッダーを編集する.
        /// </summary>
        private static void editHeaderSample(ref Document document, int fontSize, WdColorIndex color, string text)
        {
            foreach (Section section in document.Sections)
            {
                //Get the header range and add the header details.
                Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                headerRange.Font.ColorIndex = color;
                headerRange.Font.Size = fontSize;
                headerRange.Text = text;
            }
        }

        /// <summary>
        /// 文書のフッターを編集する.
        /// </summary>
        private static void editFooterSample(ref Document document, int fontSize, WdColorIndex color, string text)
        {
            foreach (Section wordSection in document.Sections)
            {
                //Get the footer range and add the footer details.
                Range footerRange = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Font.ColorIndex = color;
                footerRange.Font.Size = fontSize;
                footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                footerRange.Text = text;
            }
        }

        /// <summary>
        /// 文書に見出しを追加する.
        /// </summary>
        private static void addHeadingSample(ref Document document, string text)
        {
            Paragraph para = document.Content.Paragraphs.Add(System.Reflection.Missing.Value);
            object styleHeading1 = "見出し 1";
            para.Range.set_Style(ref styleHeading1);
            para.Range.Text = text;
            para.Range.InsertParagraphAfter();
        }

        /// <summary>
        /// 文書の末尾位置を取得する.
        /// </summary>
        /// <returns></returns>
        private static int getLastPosition(ref Document document)
        {
            return document.Content.End - 1;
        }

        /// <summary>
        /// 文書の末尾にテキストを追加する.
        /// </summary>
        private static void addTextSample(ref Document document, WdColorIndex color, string text)
        {
            int before = getLastPosition(ref document);
            Range rng = document.Range(document.Content.End - 1, document.Content.End - 1);
            rng.Text += text;
            int after = getLastPosition(ref document);

            document.Range(before, after).Font.ColorIndex = color;
        }
    }
}
