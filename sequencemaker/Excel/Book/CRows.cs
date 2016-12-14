using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;

namespace Excel.Book
{
    public class CRows
    {
        protected SheetData m_SheetData = null;

        protected Dictionary<uint, CRow> m_Rows;

        public CRows(SheetData sheetData)
        {
            this.m_Rows = new Dictionary<uint,CRow>();
            this.m_SheetData = sheetData;
        }

        public CRow this[uint index]
        {
            get
            {
                if (this.m_Rows.ContainsKey(index))
                {
                    return this.m_Rows[index];
                }
                else
                {
                    CRow workRow; 
                    workRow = new CRow(index);

                    this.m_SheetData.Append(workRow.Row);
                    this.m_Rows.Add(index, workRow);

                    return this.m_Rows[index];
                }
            }
        }
    }
}
