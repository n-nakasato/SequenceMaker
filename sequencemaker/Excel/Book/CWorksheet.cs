using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using Xdr = DocumentFormat.OpenXml.Drawing.Spreadsheet;
using A = DocumentFormat.OpenXml.Drawing;

namespace Excel.Book
{
    public class CWorksheet
    {
        protected WorkbookPart m_WorkbookPart = null;
        protected WorksheetPart m_WorksheetPart = null;
        protected Sheet m_Sheet = null;
        protected SheetData m_SheetData = null;
        protected DrawingsPart m_DrawingsPart = null;
        protected uint m_DrawingNum = 1;

        protected uint m_SheetNum = 0;
        protected string m_SheetName = "";
        protected CCells m_Cells = null;
        protected CRows m_Rows = null;

        /// <summary>
        /// ワークシートのプロパティ
        /// </summary>
        public Sheet Sheet
        {
            get { return this.m_Sheet; }
        }

        /// <summary>
        /// セルへの参照プロパティ
        /// </summary>
        public CCells Cells
        {
            get { return this.m_Cells; }
        }

        /// <summary>
        /// 行への参照プロパティ
        /// </summary>
        public CRows Rows
        {
            get { return this.m_Rows; }
        }

        protected double ToColumnWidth(double org)
        {
            return (org * 1.3125);
        }

        protected double ReverseColumnWidth(double org)
        {
            return (org * 0.761904);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="worksheet"></param>
        /// <param name="sheetNum"></param>
        /// <param name="sheetName"></param>
        public CWorksheet(WorkbookPart workbook, uint sheetNum, string sheetName)
        {
            this.m_SheetNum = sheetNum;
            this.m_SheetName = sheetName;
            this.m_WorkbookPart = workbook;

            // ワークブックパートに、ワークシートパートを設定
            this.m_WorksheetPart = this.m_WorkbookPart.AddNewPart<WorksheetPart>();
            this.m_SheetData = new SheetData();
            this.m_WorksheetPart.Worksheet = new Worksheet(this.m_SheetData);
            this.m_WorksheetPart.Worksheet.Append(new Drawing() { Id = this.m_WorkbookPart.GetIdOfPart(this.m_WorksheetPart) });

            // 図形描画用の設定
            this.m_DrawingsPart = this.m_WorksheetPart.AddNewPart<DrawingsPart>(this.m_WorkbookPart.GetIdOfPart(this.m_WorksheetPart));
            this.m_DrawingsPart.WorksheetDrawing = new Xdr.WorksheetDrawing();
            this.m_DrawingsPart.WorksheetDrawing.AddNamespaceDeclaration("xdr", "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
            this.m_DrawingsPart.WorksheetDrawing.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            // シートを1つ追加
            this.m_Sheet = new Sheet() { Id = this.m_WorkbookPart.GetIdOfPart(this.m_WorksheetPart), SheetId = UInt32Value.FromUInt32(this.m_SheetNum), Name = sheetName };

            // 行オブジェクト生成
            this.m_Rows = new CRows(this.m_SheetData);

            // セルオブジェクト生成
            this.m_Cells = new CCells(this.m_Rows);
        }

        /// <summary>
        /// コンストラクタ(行幅、列幅指定付き)
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sheetNum"></param>
        /// <param name="sheetName"></param>
        /// <param name="rowHeight"></param>
        /// <param name="columnWidth"></param>
        public CWorksheet(WorkbookPart workbook, uint sheetNum, string sheetName, double rowHeight, double columnWidth)
        {
            this.m_SheetNum = sheetNum;
            this.m_SheetName = sheetName;
            this.m_WorkbookPart = workbook;

            // ワークブックパートに、ワークシートパートを設定
            this.m_WorksheetPart = this.m_WorkbookPart.AddNewPart<WorksheetPart>();
            this.m_SheetData = new SheetData();
            this.m_WorksheetPart.Worksheet = new Worksheet(this.m_SheetData);
            this.m_WorksheetPart.Worksheet.Append(new Drawing() { Id = this.m_WorkbookPart.GetIdOfPart(this.m_WorksheetPart) });

            // 行、列幅指定
            this.m_WorksheetPart.Worksheet.SheetFormatProperties = new SheetFormatProperties();
            this.m_WorksheetPart.Worksheet.SheetFormatProperties.DefaultColumnWidth = DoubleValue.FromDouble(this.ToColumnWidth(columnWidth));
            this.m_WorksheetPart.Worksheet.SheetFormatProperties.DefaultRowHeight = DoubleValue.FromDouble(rowHeight);
            this.m_WorksheetPart.Worksheet.SheetFormatProperties.CustomHeight = true;

            // 図形描画用の設定
            this.m_DrawingsPart = this.m_WorksheetPart.AddNewPart<DrawingsPart>(this.m_WorkbookPart.GetIdOfPart(this.m_WorksheetPart));
            this.m_DrawingsPart.WorksheetDrawing = new Xdr.WorksheetDrawing();
            this.m_DrawingsPart.WorksheetDrawing.AddNamespaceDeclaration("xdr", "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
            this.m_DrawingsPart.WorksheetDrawing.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            // シートを1つ追加
            this.m_Sheet = new Sheet() { Id = this.m_WorkbookPart.GetIdOfPart(this.m_WorksheetPart), SheetId = UInt32Value.FromUInt32(this.m_SheetNum), Name = sheetName };

            // 行オブジェクト生成
            this.m_Rows = new CRows(this.m_SheetData);

            // セルオブジェクト生成
            this.m_Cells = new CCells(this.m_Rows);
        }

        /// <summary>
        /// 直線の描画
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        /// <returns></returns>
        public CShapeLine DrawShape_AllowLine(uint startRow, uint startColumn, uint endRow, uint endColumn)
        {
            CShapeLine shape = new CShapeLine(this.m_DrawingNum, startRow, startColumn, endRow, endColumn, this.m_WorksheetPart.Worksheet.SheetFormatProperties.DefaultRowHeight, this.m_WorksheetPart.Worksheet.SheetFormatProperties.DefaultColumnWidth);
            this.m_DrawingNum++;
            this.m_DrawingsPart.WorksheetDrawing.Append(shape.TwoCellAnchor);

            return (shape);
        }

        /// <summary>
        /// テキスト付のシェイプを描画
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        /// <returns></returns>
        public CShapeText DrawShape_Text(A.ShapeTypeValues shapeType, uint startRow, uint startColumn, uint endRow, uint endColumn)
        {
            CShapeText shape = new CShapeText(this.m_DrawingNum, shapeType, startRow, startColumn, endRow, endColumn);
            this.m_DrawingNum++;
            this.m_DrawingsPart.WorksheetDrawing.Append(shape.TwoCellAnchor);

            return (shape);
        }
        
    }
}
