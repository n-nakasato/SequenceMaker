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
    public class CCellStyleFormats
    {
        protected CellStyleFormats m_CellStyleFormats = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public CellStyleFormats CellStyleFormats
        {
            get { return this.m_CellStyleFormats; }
        }

        public CCellStyleFormats()
        {
            this.m_CellStyleFormats = new CellStyleFormats();
            this.m_Items = new Dictionary<string, uint>();

            this.Add(0, 0, 0, 0);
        }

        public uint Add(uint numFormatId, uint fontId, uint fillId, uint borderId)
        {
            string contents = "";

            contents = string.Format("{0},{1},{2},{3}", numFormatId, fontId, fillId, borderId);

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            CellFormat cellFormat = new CellFormat() { NumberFormatId = (UInt32Value)numFormatId, FontId = (UInt32Value)fontId, FillId = (UInt32Value)fillId, BorderId = (UInt32Value)borderId };

            this.m_CellStyleFormats.Append(cellFormat);
            this.m_CellStyleFormats.Count = UInt32Value.FromUInt32((uint)this.m_CellStyleFormats.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }
    }
}
