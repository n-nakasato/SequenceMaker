using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using System.Diagnostics;

namespace Excel.Book
{
    /// <summary>
    /// VBAのRangeに相当するクラス
    /// </summary>
    public class CRange
    {
        protected string m_Address = "A1";
        protected Cell m_Cell = null;

        public CRange(string address)
        {
            this.m_Address = address;

            this.m_Cell = new Cell();
            this.m_Cell.CellReference = this.m_Address;
        }

        /// <summary>
        /// アドレス文字列を取得する
        /// </summary>
        public string Address
        {
            get
            {
                return (this.m_Address);
            }
        }

        /// <summary>
        /// 行番号を取得する
        /// 1から始まる番号。
        /// </summary>
        /// <returns></returns>
        public UInt32Value RowIndex
        {
            get
            {
                // Regexオブジェクトを作成
                Regex r = new Regex(@"\d+", RegexOptions.None);

                // 正規表現と一致する対象を1つ検索
                Match m = r.Match(this.m_Address);

                if (m.Success)
                {
                    return (new UInt32Value(uint.Parse(m.Value)));
                }
                else
                {
                    return (new UInt32Value((uint)0));
                }
            }
        }

        /// <summary>
        /// 列名を取得する
        /// </summary>
        /// <returns></returns>
        public string ColumnName
        {
            get
            {
                // Regexオブジェクトを作成
                Regex r = new Regex(@"[A-Za-z]+", RegexOptions.None);

                // 正規表現と一致する対象を1つ検索
                Match m = r.Match(this.m_Address);

                if (m.Success)
                {
                    return (m.Value);
                }
                else
                {
                    return ("");
                }
            }
        }

        /// <summary>
        /// 列番号から列名に変換する
        /// </summary>
        /// <param name="columnIndex">列番号</param>
        /// <returns>列名文字列</returns>
        public static string ColumnIndexToColumnName(uint columnIndex)
        {
            uint alpha;
            uint remainder;
            string name = "";

            alpha = (uint)((columnIndex - 1) / 26);
            remainder = columnIndex - (alpha * 26);

            if(0 < alpha)
            {
                name += (char)(alpha + 0x40);
            }

            if(0 < remainder)
            {
                name += (char)(remainder + 0x40);
            }

            return name;
        }

        /// <summary>
        /// セルを取得する
        /// </summary>
        public Cell Cell
        {
            get { return this.m_Cell; }
        }

        /// <summary>
        /// セルの値を設定/取得する
        /// </summary>
        public string Value
        {
            get
            {
                if(null != this.m_Cell.CellValue)
                {
                    return this.m_Cell.CellValue.Text;
                }
                else
                {
                    return "";
                }
            }

            set
            {
                if (null != this.m_Cell.CellValue)
                {
                    this.m_Cell.CellValue.Text = value;
                }
                else
                {
                    this.m_Cell.DataType = CellValues.String;
                    this.m_Cell.CellValue = new CellValue(value);
                }
            }
        }

        /// <summary>
        /// セルの書式を設定/取得する
        /// </summary>
        public string Formula
        {
            get 
            {
                if(null != this.m_Cell.CellFormula)
                {
                    return this.m_Cell.CellFormula.Text;
                }
                else
                {
                    return "";
                }
            }
            set 
            {
                if(null != this.m_Cell.CellFormula)
                {
                    this.m_Cell.CellFormula.Text = value;
                }
                else
                {
                    this.m_Cell.DataType = CellValues.String;
                    this.m_Cell.CellFormula = new CellFormula(value);
                }
            }
        }

        /// <summary>
        /// セルのスタイルを設定/取得する
        /// </summary>
        public uint StyleIndex
        {
            get 
            {
                if (null == this.m_Cell.StyleIndex)
                {
                    return 0;
                }
                else
                {
                    return this.m_Cell.StyleIndex;
                }
            }
            set 
            {
                this.m_Cell.StyleIndex = UInt32Value.FromUInt32(value);
            }
        }
    }
}
