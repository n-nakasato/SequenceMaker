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
    public class CCellStyles
    {
        protected CellStyles m_CellStyles = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public CellStyles CellStyles
        {
            get { return this.m_CellStyles; }
        }

        public CCellStyles()
        {
            this.m_CellStyles = new CellStyles();
            this.m_Items = new Dictionary<string, uint>();

            this.Add("標準", 0, 0);
        }

        public uint Add(string name, uint formatId, uint builtinId)
        {
            string contents = "";

            contents = string.Format("{0},{1},{2}", name, formatId, builtinId);

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            CellStyle cellStyle = new CellStyle() { Name = name, FormatId = (UInt32Value)formatId, BuiltinId = (UInt32Value)builtinId };

            this.m_CellStyles.Append(cellStyle);
            this.m_CellStyles.Count = UInt32Value.FromUInt32((uint)this.m_CellStyles.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }
    }
}
