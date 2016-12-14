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
    public class CDifferentialFormats
    {
        protected DifferentialFormats m_DifferentialFormats = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public DifferentialFormats DifferentialFormats
        {
            get { return this.m_DifferentialFormats; }
        }

        public CDifferentialFormats()
        {
            this.m_DifferentialFormats = new DifferentialFormats();
            this.m_Items = new Dictionary<string, uint>();
        }

        public uint Add()
        {
            string contents = "";

            contents = string.Format("{0},{1},{2}", "arg1", "arg2");

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            DifferentialFormat differentialFormat = new DifferentialFormat();

            this.m_DifferentialFormats.Append(differentialFormat);
            this.m_DifferentialFormats.Count = UInt32Value.FromUInt32((uint)this.m_DifferentialFormats.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }
    }
}
