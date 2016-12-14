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
    public class CRow
    {
        protected Row m_Row = null;

        protected Dictionary<string, CRange> m_Cells;

        public CRow(uint index)
        {
            this.m_Row = new Row();
            this.m_Row.RowIndex = (UInt32Value)index;

            this.m_Cells = new Dictionary<string, CRange>();
        }

        public Row Row
        {
            get { return this.m_Row; }
        }

        public void AddCell(CRange cell)
        {
            this.m_Cells.Add(cell.ColumnName, cell);
            this.m_Row.Append(cell.Cell);
            if(0 < this.StyleIndex)
            {
                cell.StyleIndex = this.StyleIndex;
            }
        }

        public uint StyleIndex
        {
            get 
            {
                if(null != this.m_Row.StyleIndex)
                {
                    return this.m_Row.StyleIndex; 
                }
                else
                {
                    return 0;
                }
            }
            set 
            {
                this.m_Row.StyleIndex = value;
                this.m_Row.CustomFormat = true;

                foreach(CRange now_cell in this.m_Cells.Values)
                {
                    now_cell.StyleIndex = value;
                }
            }
        }
    }
}
