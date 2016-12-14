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
    public class CTableStyles
    {
        protected TableStyles m_TableStyles = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public TableStyles TableStyles
        {
            get { return this.m_TableStyles; }
        }

        public CTableStyles()
        {
            this.m_TableStyles = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleMedium9" };
            this.m_Items = new Dictionary<string, uint>();
        }

        public uint Add()
        {
            string contents = "";

            contents = string.Format("{0},{1}", "hogehoge", "hugahuga");

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            TableStyle tableStyle = new TableStyle();

            this.m_TableStyles.Append(tableStyle);
            this.m_TableStyles.Count = UInt32Value.FromUInt32((uint)this.m_TableStyles.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];
        }
    }
}
