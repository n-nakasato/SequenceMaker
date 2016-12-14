using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Book
{
    public class CWorksheets
    {
        protected WorkbookPart m_WorkbookPart = null;
        protected Sheets m_Sheets = null;

        protected Dictionary<string, CWorksheet> m_Worksheets = new Dictionary<string, CWorksheet>();
        protected uint m_SheetNum = 1;

        public WorkbookPart WorksheetPart
        {
            get { return this.m_WorkbookPart; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="package"></param>
        public CWorksheets(WorkbookPart workbook)
        {
            this.m_WorkbookPart = workbook;

            // ワークブックにシートを設定
            this.m_Sheets = this.m_WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
        }

        /// <summary>
        /// ワークシートを取得する
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public CWorksheet this[string sheetName]
        {
            get
            {
                CWorksheet ret = null;

                if(this.m_Worksheets.ContainsKey(sheetName))
                {
                    ret = this.m_Worksheets[sheetName];
                }

                return (ret);
            }
        }

        /// <summary>
        /// ワークシートを作成
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public bool Add(string sheetName)
        {
            bool ret = false;
            CWorksheet sheetItem;

            if (!this.m_Worksheets.ContainsKey(sheetName))
            {
                sheetItem = new CWorksheet(this.m_WorkbookPart, this.m_SheetNum, sheetName);
                this.m_Worksheets.Add(sheetName, sheetItem);

                this.m_Sheets.Append(sheetItem.Sheet);

                this.m_SheetNum++;

                ret = true;
            }

            return (ret);
        }

        /// <summary>
        /// ワークシートを作成
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool Add(string sheetName, double height, double width)
        {
            bool ret = false;
            CWorksheet sheetItem;

            if (!this.m_Worksheets.ContainsKey(sheetName))
            {
                sheetItem = new CWorksheet(this.m_WorkbookPart, this.m_SheetNum, sheetName, height, width);
                this.m_Worksheets.Add(sheetName, sheetItem);

                this.m_Sheets.Append(sheetItem.Sheet);

                this.m_SheetNum++;

                ret = true;
            }

            return (ret);
        }

        /// <summary>
        /// ワークシートを削除
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public bool Delete(string sheetName)
        {
            bool ret = false;

            if (!this.m_Worksheets.ContainsKey(sheetName))
            {
                this.m_Worksheets.Remove(sheetName);

                ret = true;
            }

            return (ret);
        }
    }
}
