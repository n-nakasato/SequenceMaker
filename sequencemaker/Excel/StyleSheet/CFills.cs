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
    public class CFills
    {
        protected Fills m_Fills = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public Fills Fills
        {
            get { return this.m_Fills; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CFills()
        {
            this.m_Fills = new Fills();
            this.m_Items = new Dictionary<string, uint>();

            // エクセル予約を追加
            this.Add(PatternValues.None);
            this.Add(PatternValues.Gray125);
        }

        /// <summary>
        /// 色を追加
        /// </summary>
        /// <param name="ptn"></param>
        /// <param name="rgb">nullは禁止</param>
        /// <returns></returns>
        public uint Add(PatternValues ptn, string color = "")
        {
            Fill fill;

            string contents = "";

            contents = string.Format("{0},{1}", ptn.ToString(), color);

            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            fill = new Fill();
            fill.PatternFill = new PatternFill() { PatternType = ptn };

            if ("" != color)
            {
                fill.PatternFill.ForegroundColor = new ForegroundColor();
                fill.PatternFill.ForegroundColor.Rgb = HexBinaryValue.FromString(color);

                fill.PatternFill.BackgroundColor = new BackgroundColor();
                fill.PatternFill.BackgroundColor.Rgb = fill.PatternFill.ForegroundColor.Rgb;
            }

            this.m_Fills.Append(fill);
            this.m_Fills.Count = UInt32Value.FromUInt32((uint)this.m_Fills.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;
            return this.m_Items[contents];
        }
    }
}
