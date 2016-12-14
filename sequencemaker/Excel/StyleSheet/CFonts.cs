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
    public class CFonts
    {
        private Fonts m_Fonts = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public Fonts Fonts
        {
            get { return this.m_Fonts; }
        }

        public CFonts()
        {
            this.m_Fonts = new Fonts() { KnownFonts = true };
            this.m_Items = new Dictionary<string, uint>();

            // デフォルト値を設定
            this.Add("ＭＳ ゴシック", 11, "FF000000");

            // デフォルト値を設定
            this.Add("ＭＳ ゴシック", 10, "FF000000");
        }

        /// <summary>
        /// フォント追加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="fontColor"></param>
        /// <returns></returns>
        public uint Add(
            string name = "ＭＳ ゴシック", 
            double size = 11,
            string fontColor = "FF000000"
        )
        {
            string contents = "";

            contents = string.Format("{0},{1},{2}", name, size, fontColor);

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            Font font = new Font();

            FontName fontName = new FontName() { Val = name };
            FontSize fontSize = new FontSize() { Val = size };
            fontSize.Val.Value = size;
            Color color = new Color() { Rgb = fontColor };

            font.Append(fontName);
            font.Append(fontSize);
            font.Append(color);

            this.m_Fonts.Append(font);
            this.m_Fonts.Count = UInt32Value.FromUInt32((uint)this.m_Fonts.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }
    }
}
