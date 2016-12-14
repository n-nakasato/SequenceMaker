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
    public class CCellFormats
    {
        protected CellFormats m_CellFormats = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public CellFormats CellFormats
        {
            get { return this.m_CellFormats; }
        }

        public CCellFormats()
        {
            this.m_CellFormats = new CellFormats() ;
            this.m_Items = new Dictionary<string, uint>();

            this.Add(0, 0, 0, 0, 0, HorizontalAlignmentValues.Left, VerticalAlignmentValues.Top);
        }

        public static HorizontalAlignmentValues ToHorizontalAlignmentValues(string str)
        {
            HorizontalAlignmentValues ret;

            switch(str)
            {
                case "Left":
                    ret = HorizontalAlignmentValues.Left;
                    break;

                case "Right":
                    ret = HorizontalAlignmentValues.Right;
                    break;
                
                case "Center":
                    ret = HorizontalAlignmentValues.Center;
                    break;

                case "Fill":
                    ret = HorizontalAlignmentValues.Fill;
                    break;

                case "General":
                    ret = HorizontalAlignmentValues.General;
                    break;

                case "Distributed":
                    ret = HorizontalAlignmentValues.Distributed;
                    break;

                case "CenterContinuous":
                    ret = HorizontalAlignmentValues.CenterContinuous;
                    break;

                case "Justify":
                    ret = HorizontalAlignmentValues.Justify;
                    break;

                default:
                    ret = HorizontalAlignmentValues.Left;
                    break;
            }

            return ret;
        }

        public static VerticalAlignmentValues ToVerticalAlignmentValues(string str)
        {
            VerticalAlignmentValues ret;

            switch (str)
            {
                case "Bottom":
                    ret = VerticalAlignmentValues.Bottom;
                    break;

                case "Center":
                    ret = VerticalAlignmentValues.Center;
                    break;

                case "Distributed":
                    ret = VerticalAlignmentValues.Distributed;
                    break;

                case "Justify":
                    ret = VerticalAlignmentValues.Justify;
                    break;

                case "Top":
                    ret = VerticalAlignmentValues.Top;
                    break;

                default:
                    ret = VerticalAlignmentValues.Bottom;
                    break;
            }

            return ret;
        }

        public uint Add(
            uint numFormatId = 0, 
            uint fontId = 0, 
            uint fillId = 0, 
            uint borderId = 0, 
            uint formatId = 0, 
            HorizontalAlignmentValues horizon = HorizontalAlignmentValues.Left, 
            VerticalAlignmentValues vertical = VerticalAlignmentValues.Top
        )
        {
            string contents = "";

            contents = string.Format("{0},{1},{2},{3},{4},{5},{6}", numFormatId, fontId, fillId, borderId, formatId, horizon.ToString(), vertical.ToString());

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            CellFormat cellFormat = new CellFormat();

            // ？？？
            cellFormat.NumberFormatId = (UInt32Value)numFormatId;
            if(0 < cellFormat.NumberFormatId)
            {
                cellFormat.ApplyNumberFormat = true;
            }

            // フォント
            cellFormat.FontId = (UInt32Value)fontId;
            if (0 < cellFormat.FontId)
            {
                cellFormat.ApplyFont = true;
            }

            // 塗りつぶし
            cellFormat.FillId = (UInt32Value)fillId;
            if (0 < cellFormat.FillId)
            {
                cellFormat.ApplyFill = true;
            }

            // 罫線
            cellFormat.BorderId = (UInt32Value)borderId;
            if (0 < cellFormat.BorderId)
            {
                cellFormat.ApplyBorder = true;
            }

            // ？？？
            cellFormat.FormatId = (UInt32Value)formatId;

            // 文字位置
            cellFormat.Alignment = new Alignment() { Horizontal = horizon, Vertical = vertical };
            cellFormat.ApplyAlignment = true;

            this.m_CellFormats.Append(cellFormat);
            this.m_CellFormats.Count = UInt32Value.FromUInt32((uint)this.m_CellFormats.ChildElements.Count);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }

        public string[] Get(uint styleId)
        {
            if(this.m_Items.ContainsValue(styleId))
            {
                foreach(string now_key in this.m_Items.Keys)
                {
                    if(styleId == this.m_Items[now_key])
                    {
                        return now_key.Split(new char[]{','});
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
