using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;
using X15 = DocumentFormat.OpenXml.Office2013.Excel;
using A = DocumentFormat.OpenXml.Drawing;

using Excel.StyleSheet;
using System.Diagnostics;

namespace Excel.Book
{
    public class CWorkbook
    {
        protected CWorksheets m_Worksheets;
        protected string m_FileName = "";
        protected SpreadsheetDocument m_Package = null;
        protected CStyleSheet m_StyleSheet = null;

        public string FileName
        {
            get { return this.m_FileName; }
            set { this.m_FileName = value; }
        }

        public CWorksheets Worksheets
        {
            get
            {
                return this.m_Worksheets;
            }
        }

        public CStyleSheet StyleSheet
        {
            get
            {
                return this.m_StyleSheet;
            }
        }

        /// <summary>
        /// ファイルを開く
        /// </summary>
        public bool Open()
        {
            bool ret;
            
            ret = false;

            try
            {
                this.m_Package = SpreadsheetDocument.Create(this.m_FileName, SpreadsheetDocumentType.Workbook, true);

                // ドキュメントのワークブックパートに、ワークブックを設定
                WorkbookPart wbpart = this.m_Package.AddWorkbookPart();
                wbpart.Workbook = new Workbook();

                WorkbookStylesPart workbookStylesPart1 = wbpart.AddNewPart<WorkbookStylesPart>("rId4");
                this.m_StyleSheet = new CStyleSheet();
                workbookStylesPart1.Stylesheet = this.m_StyleSheet.Stylesheet;

                // ワークシートを設定
                this.m_Worksheets = new CWorksheets(wbpart);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(null != this.m_Package)
                {
                    ret = true;
                }
            }

            return ret;
        }

        /// <summary>
        /// ファイルを閉じる
        /// </summary>
        public void Close()
        {
            // クローズ
            this.m_Package.Close();
        }

        /// <summary>
        /// 任意のタイミングで保存
        /// </summary>
        public void Save()
        {
            this.m_Package.WorkbookPart.Workbook.Save();
        }

        public string GetStyleId(Color color)
        {
            Fill fill = new Fill();
            PatternFill patternFill = new PatternFill() { PatternType = PatternValues.Gray125 };

            return null;
        }

        public string GetStyleId(Color color, CBorder border)
        {
            return null;

        }

        [STAThread]
        static void Main()
        {
            CWorkbook book = new CWorkbook();
            book.FileName = "test.xlsx";
            book.Open();

            book.Worksheets.Add("元データ");
            book.Worksheets.Add("シーケンス図", 10, 2);

            book.Worksheets["元データ"].Cells["A1"].Value = "テストデータ！0";
            book.Worksheets["元データ"].Cells["B1"].Value = "テストデータ！10";
            book.Worksheets["元データ"].Cells["A2"].Value = "テストデータ！1";
            book.Worksheets["元データ"].Cells["A3"].Value = "テストデータ！2";
            book.Worksheets["元データ"].Cells["A4"].Value = "ほげほげほげほげ";

            //string link = "元データ!A4";
            //book.Worksheets["シーケンス図"].Cells["B4"].Value = "";
            //book.Worksheets["シーケンス図"].Cells["B4"].Formula = "=HYPERLINK(\"[" + book.FileName + "]" + link + "\"," + link + ")";

            CShapeLine shape1 = book.Worksheets["シーケンス図"].DrawShape_AllowLine(1, 1, 5, 5);
            shape1.LineColor = "FF00FF";
            shape1.PresetDash = A.PresetLineDashValues.Dash;
            //shape1.HeadEndStyle = A.LineEndValues.Arrow;
            shape1.TailEndStyle = A.LineEndValues.Oval;
            //shape1.HeadEndLength = A.LineEndLengthValues.Large;
            shape1.LineWidth = 6.25;

            CShapeLine shape2 = book.Worksheets["シーケンス図"].DrawShape_AllowLine(5, 5, 1, 1);
            shape2.LineColor = "00FFFF";
            //shape2.HeadEndStyle = A.LineEndValues.Triangle;
            shape2.TailEndStyle = A.LineEndValues.Stealth;
            shape2.TailEndLength = A.LineEndLengthValues.Small;
            shape2.TailEndWidth = A.LineEndWidthValues.Large;

            //CShapeText shape3 = book.Worksheets["元データ"].DrawShape_Text(A.ShapeTypeValues.FlowChartAlternateProcess, 2, 1, 6, 5);
            //shape3.LineColor = "0000FF";
            //shape3.FillColor = "FF0000";
            //shape3.PresetDash = A.PresetLineDashValues.Dash;
            //shape3.LineWidth = 6.25;
            //shape3.Text = "てすとだよー！";
            //shape3.FontColor = "FFFF00";
            //shape3.TextAlignment = A.TextAlignmentTypeValues.Center;

            //uint fontId;
            //uint borderId;
            //uint fillId;
            //uint cellFormatId1;
            //uint cellFormatId2;

            //// 色追加
            //fontId = book.StyleSheet.Fonts.Add(size: 11.5, fontColor: "FFFF0000");

            //book.m_StyleSheet.Fills.Add(PatternValues.Solid, "FFFF00FF");
            //fillId = book.m_StyleSheet.Fills.Add(PatternValues.Solid, "FFFFFF00");

            //// 罫線追加
            //book.m_StyleSheet.Borders.Add(BorderStyleValues.Double, BorderStyleValues.Thin, BorderStyleValues.Thin, BorderStyleValues.Thin);
            //book.m_StyleSheet.Borders.Add(BorderStyleValues.Thin, BorderStyleValues.Double, BorderStyleValues.Thin, BorderStyleValues.Double);
            //book.m_StyleSheet.Borders.Add(BorderStyleValues.Thin, BorderStyleValues.Thin, BorderStyleValues.Double, BorderStyleValues.Thin);
            //book.m_StyleSheet.Borders.Add(BorderStyleValues.Thin, BorderStyleValues.Thin, BorderStyleValues.Thin, BorderStyleValues.Double);
            //borderId = book.m_StyleSheet.Borders.Add(BorderStyleValues.None, BorderStyleValues.Thin, BorderStyleValues.None, BorderStyleValues.None);

            //cellFormatId1 = book.m_StyleSheet.CCellFormats.Add(0, fontId, fillId, 0, 0, HorizontalAlignmentValues.Right, VerticalAlignmentValues.Bottom);
            //cellFormatId2 = book.m_StyleSheet.CCellFormats.Add(0, fontId, fillId, borderId, 0, HorizontalAlignmentValues.Right, VerticalAlignmentValues.Bottom);

            //book.Worksheets["元データ"].Rows[4].StyleIndex = cellFormatId1;
            //book.Worksheets["元データ"].Cells["C4"].StyleIndex = cellFormatId2;

            //book.Worksheets["元データ"].Cells[10, 26].Value = "test!!";
            //book.Worksheets["元データ"].Cells[10, 27].Value = "testc!!!!";
            //book.Worksheets["元データ"].Cells[10, 28].Value = "testc2222";
            //book.Worksheets["元データ"].Cells[10, 255].Value = "testc2222";
            //book.Worksheets["元データ"].Cells[10, 256].Value = "testc2222";
            //book.Worksheets["元データ"].Cells[10, 729].Value = "testc2222";
            //book.Worksheets["元データ"].Cells[10, 730].Value = "testc2222";
            //book.Worksheets["元データ"].Cells[10, 731].Value = "testc2222";


            book.Close();

            Process.Start("test.xlsx");
        }
    }
}
