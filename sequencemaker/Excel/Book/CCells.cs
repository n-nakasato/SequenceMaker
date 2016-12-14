using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;

namespace Excel.Book
{
    /// <summary>
    /// VBAのCellsに相当するクラス
    /// </summary>
    public class CCells
    {
        protected Dictionary<string, CRange> m_Cells = null;
        protected CRows m_Rows = null;

        public CCells(CRows rows)
        {
            this.m_Cells = new Dictionary<string,CRange>();
            this.m_Rows = rows;
        }

        /// <summary>
        /// セルの選択情報を取得する
        /// </summary>
        /// <param name="address">セルの位置を表すアドレス文字列</param>
        /// <returns>セルの選択情報を返す</returns>
        public CRange this[string address]
        {
            get
            {
                if(this.m_Cells.ContainsKey(address))
                {
                    return this.m_Cells[address];
                }
                else
                {
                    CRange appendCell = new CRange(address);

                    this.m_Cells.Add(address, appendCell);
                    this.m_Rows[appendCell.RowIndex].AddCell(appendCell);

                    return this.m_Cells[address];
                }
            }
        }

        /// <summary>
        /// セルの選択情報を取得する
        /// </summary>
        /// <param name="row">行番号</param>
        /// <param name="column">列番号</param>
        /// <returns>単セルの選択情報を返す</returns>
        public CRange this[uint row, uint column]
        {
            get
            {
                string address;

                address = CRange.ColumnIndexToColumnName(column);
                address += row.ToString();

                return this[address];
            }
        }
    }
}
