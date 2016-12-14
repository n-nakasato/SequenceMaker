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

namespace Excel.StyleSheet
{
    public class CStyleSheet
    {
        private Stylesheet m_StyleSheet = null;

        private CFonts m_Fonts = null;
        private CFills m_Fills = null;
        private CBorders m_Borders = null;
        private CCellStyleFormats m_CellStyleFormats = null;
        private CCellFormats m_CellFormats = null;
        private CCellStyles m_CellStyles = null;
        private CDifferentialFormats m_DifferentialFormats = null;
        private CTableStyles m_TableStyles = null;
        private CStylesheetExtensionList m_StylesheetExtensionList = null;

        public Stylesheet Stylesheet
        {
            get { return this.m_StyleSheet; }
        }

        public CFonts Fonts
        {
            get { return this.m_Fonts; }
        }

        public CFills Fills
        {
            get { return this.m_Fills; }
        }

        public CBorders Borders
        {
            get { return this.m_Borders; }
        }

        public CCellFormats CCellFormats
        {
            get { return this.m_CellFormats; }
        }

        public CStyleSheet()
        {
            // スタイルシート作成
            this.m_StyleSheet = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            this.m_StyleSheet.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            this.m_StyleSheet.AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");
            this.m_StyleSheet.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            this.m_StyleSheet.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            this.m_StyleSheet.AddNamespaceDeclaration("x", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");

            // フォント作成
            this.m_Fonts = new CFonts();

            // 塗りつぶしスタイル
            this.m_Fills = new CFills();

            // 罫線用の設定
            this.m_Borders = new CBorders();

            // セルスタイルフォーマット
            this.m_CellStyleFormats = new CCellStyleFormats();

            // セルフォーマット
            this.m_CellFormats = new CCellFormats();

            // セルスタイル
            this.m_CellStyles = new CCellStyles();

            // ？？？
            this.m_DifferentialFormats = new CDifferentialFormats();

            // ？？？
            this.m_TableStyles = new CTableStyles();

            // スタイルシートエクステンション
            this.m_StylesheetExtensionList = new CStylesheetExtensionList();

            this.m_StyleSheet.Append(this.m_Fonts.Fonts);
            this.m_StyleSheet.Append(this.m_Fills.Fills);
            this.m_StyleSheet.Append(this.m_Borders.Borders);
            this.m_StyleSheet.Append(this.m_CellStyleFormats.CellStyleFormats);
            this.m_StyleSheet.Append(this.m_CellFormats.CellFormats);
            this.m_StyleSheet.Append(this.m_CellStyles.CellStyles);
            this.m_StyleSheet.Append(this.m_DifferentialFormats.DifferentialFormats);
            this.m_StyleSheet.Append(this.m_TableStyles.TableStyles);
            this.m_StyleSheet.Append(this.m_StylesheetExtensionList.StylesheetExtensionList);
        }
    }
}
