using System;
using System.Drawing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = DocumentFormat.OpenXml.Drawing;
using Xdr = DocumentFormat.OpenXml.Drawing.Spreadsheet;

namespace Excel.Book
{
    public class CShape
    {
        protected uint Id = 0;
        protected TwoCellAnchor m_TwoCellAnchor = null;
        protected A.Outline m_Outline = null;
        protected A.RgbColorModelHex m_LineColor = null;
        protected A.PresetDash m_PresetDash = null;

        /// <summary>
        /// TwoCellAnchor取得
        /// </summary>
        public TwoCellAnchor TwoCellAnchor
        {
            get { return this.m_TwoCellAnchor; }
        }

        /// <summary>
        /// 線色設定
        /// </summary>
        public string LineColor
        {
            get { return (this.m_LineColor.Val); }
            set { this.m_LineColor.Val = value; }
        }

        /// <summary>
        /// 線幅設定
        /// </summary>
        public double LineWidth
        {
            get 
            {
                double ret = (double)this.m_Outline.Width.Value;
                ret /= 12700;
                return (ret);
            }

            set 
            {
                double tmp = 12700;
                tmp *= value;
                this.m_Outline.Width = new Int32Value((int)tmp);
            }
        }

        /// <summary>
        /// 線の種類を設定
        /// </summary>
        public A.PresetLineDashValues PresetDash
        {
            get {  return (this.m_PresetDash.Val); }
            set { this.m_PresetDash.Val = value; }
        }

        /// <summary>
        /// FromMakerを作成する
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        protected Xdr.FromMarker CreateFromMarker(uint row, uint column, uint rowOffset, uint columnOffset)
        {
            Xdr.FromMarker fromMarker1 = new Xdr.FromMarker();

            Xdr.ColumnId columnId1 = new Xdr.ColumnId();
            columnId1.Text = column.ToString();
            Xdr.ColumnOffset columnOffset1 = new Xdr.ColumnOffset();
            columnOffset1.Text = columnOffset.ToString();

            Xdr.RowId rowId1 = new Xdr.RowId();
            rowId1.Text = row.ToString();
            Xdr.RowOffset rowOffset1 = new Xdr.RowOffset();
            rowOffset1.Text = rowOffset.ToString();

            fromMarker1.Append(columnId1);
            fromMarker1.Append(columnOffset1);
            fromMarker1.Append(rowId1);
            fromMarker1.Append(rowOffset1);

            return (fromMarker1);
        }

        /// <summary>
        /// ToMakerを作成する
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        protected Xdr.ToMarker CreateToMarker(uint row, uint column, uint rowOffset, uint columnOffset)
        {
            Xdr.ToMarker toMarker1 = new Xdr.ToMarker();

            Xdr.ColumnId columnId2 = new Xdr.ColumnId();
            columnId2.Text = column.ToString();
            Xdr.ColumnOffset columnOffset2 = new Xdr.ColumnOffset();
            columnOffset2.Text = columnOffset.ToString();

            Xdr.RowId rowId2 = new Xdr.RowId();
            rowId2.Text = row.ToString();
            Xdr.RowOffset rowOffset2 = new Xdr.RowOffset();
            rowOffset2.Text = rowOffset.ToString();

            toMarker1.Append(columnId2);
            toMarker1.Append(columnOffset2);
            toMarker1.Append(rowId2);
            toMarker1.Append(rowOffset2);

            return (toMarker1);
        }
    }
}
