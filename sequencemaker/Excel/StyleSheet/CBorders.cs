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
    public class CBorders
    {
        protected Borders m_Borders = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public Borders Borders
        {
            get { return this.m_Borders; }
        }

        public CBorders()
        {
            this.m_Borders = new Borders();
            this.m_Items = new Dictionary<string, uint>();

            // システム予約を設定(2からがユーザー設定)
            this.Add(BorderStyleValues.None, BorderStyleValues.None, BorderStyleValues.None, BorderStyleValues.None);
            this.Add(BorderStyleValues.Thin, BorderStyleValues.Thin, BorderStyleValues.Thin, BorderStyleValues.Thin);
        }

        public uint Add(BorderStyleValues top, BorderStyleValues left, BorderStyleValues right, BorderStyleValues bottom)
        {
            string contents = "";

            contents = string.Format("{0},{1},{2},{3}", top.ToString(), left.ToString(), right.ToString(), bottom.ToString());

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            CBorder border = new CBorder() { Top = top, Left = left, Right = right, Bottom = bottom };

            this.m_Borders.Append(border.Border);
            this.m_Borders.Count = UInt32Value.FromUInt32((uint)this.m_Borders.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }
    }
}
