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
    public class CShapeLine : CShape
    {
        protected A.HeadEnd m_HeadEnd = null;
        protected A.TailEnd m_TailEnd = null;

        public A.LineEndValues HeadEndStyle
        {
            get { return (this.m_HeadEnd.Type); }
            set { this.m_HeadEnd.Type = value; }
        }

        public A.LineEndWidthValues HeadEndWidth
        {
            get { return (this.m_HeadEnd.Width); }
            set { this.m_HeadEnd.Width = value; }
        }

        public A.LineEndLengthValues HeadEndLength
        {
            get { return (this.m_HeadEnd.Length);}
            set { this.m_HeadEnd.Length = value; }
        }

        public A.LineEndValues TailEndStyle
        {
            get { return (this.m_TailEnd.Type); }
            set { this.m_TailEnd.Type = value; }
        }

        public A.LineEndWidthValues TailEndWidth
        {
            get { return (this.m_TailEnd.Width); }
            set { this.m_TailEnd.Width = value; }
        }

        public A.LineEndLengthValues TailEndLength
        {
            get {  return (this.m_TailEnd.Length); }
            set { this.m_TailEnd.Length = value; }
        }

        public CShapeLine(uint id, uint startRow, uint startColumn, uint endRow, uint endColumn, double rowHeight, double columnWidth)
        {
            this.Id = id;

            this.m_TwoCellAnchor = new Xdr.TwoCellAnchor();

            uint sRow = 0;
            uint sColumn = 0;
            uint sRowOffset = 0;
            uint sColumnOffset = 0;

            uint eRow = 0;
            uint eColumn = 0;
            uint eRowOffset = 0;
            uint eColumnOffset = 0;

            int rot = 0;

            if(startRow > endRow)
            {
                sRow = endRow;
                eRow = startRow;
                rot = 90;
            }
            else
            {
                sRow = startRow;
                eRow = endRow;
            }

            if(startColumn > endColumn)
            {
                sColumn = endColumn;
                eColumn = startColumn;
                rot = 90;
            }
            else
            {
                sColumn = startColumn;
                eColumn = endColumn;
            }

            Xdr.FromMarker fromMarker1 = this.CreateFromMarker(sRow, sColumn, sRowOffset, sColumnOffset);
            Xdr.ToMarker toMarker1 = this.CreateToMarker(eRow, eColumn, eRowOffset, eColumnOffset);

            Xdr.ConnectionShape connectionShape1 = new Xdr.ConnectionShape() { Macro = "" };

            Xdr.NonVisualConnectionShapeProperties nonVisualConnectionShapeProperties1 = new Xdr.NonVisualConnectionShapeProperties();
            Xdr.NonVisualDrawingProperties nonVisualDrawingProperties1 = new Xdr.NonVisualDrawingProperties() { Id = (UInt32Value)this.Id, Name = "直線矢印コネクタ 2" };
            Xdr.NonVisualConnectorShapeDrawingProperties nonVisualConnectorShapeDrawingProperties1 = new Xdr.NonVisualConnectorShapeDrawingProperties();

            nonVisualConnectionShapeProperties1.Append(nonVisualDrawingProperties1);
            nonVisualConnectionShapeProperties1.Append(nonVisualConnectorShapeDrawingProperties1);

            Xdr.ShapeProperties shapeProperties1 = new Xdr.ShapeProperties();

            A.Transform2D transform2D1 = new A.Transform2D() { Rotation = rot * (60 * 1000) };
            A.Offset offset1 = new A.Offset() { X = 1362075L, Y = 685800L };
            A.Extents extents1 = new A.Extents() { Cx = 2076450L, Cy = 0L };

            transform2D1.Append(offset1);
            transform2D1.Append(extents1);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.StraightConnector1 };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);

            this.m_Outline = new A.Outline();

            A.SolidFill solidFill6 = new A.SolidFill();
            this.m_LineColor = new A.RgbColorModelHex() { Val = "FF0000" };

            solidFill6.Append(this.m_LineColor);
            this.m_PresetDash = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            this.m_HeadEnd = new A.HeadEnd() { Type = A.LineEndValues.None, Width = A.LineEndWidthValues.Medium, Length = A.LineEndLengthValues.Medium };
            this.m_TailEnd = new A.TailEnd() { Type = A.LineEndValues.None, Width = A.LineEndWidthValues.Medium, Length = A.LineEndLengthValues.Medium };

            this.m_Outline.Append(solidFill6);
            this.m_Outline.Append(this.m_PresetDash);
            this.m_Outline.Append(this.m_HeadEnd);
            this.m_Outline.Append(this.m_TailEnd);

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);
            shapeProperties1.Append(this.m_Outline);

            Xdr.ShapeStyle shapeStyle1 = new Xdr.ShapeStyle();

            A.LineReference lineReference1 = new A.LineReference() { Index = (UInt32Value)1U };
            A.SchemeColor schemeColor17 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            lineReference1.Append(schemeColor17);

            A.FillReference fillReference1 = new A.FillReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor18 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            fillReference1.Append(schemeColor18);

            A.EffectReference effectReference1 = new A.EffectReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor19 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            effectReference1.Append(schemeColor19);

            A.FontReference fontReference1 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.SchemeColor schemeColor20 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            fontReference1.Append(schemeColor20);

            shapeStyle1.Append(lineReference1);
            shapeStyle1.Append(fillReference1);
            shapeStyle1.Append(effectReference1);
            shapeStyle1.Append(fontReference1);

            connectionShape1.Append(nonVisualConnectionShapeProperties1);
            connectionShape1.Append(shapeProperties1);
            connectionShape1.Append(shapeStyle1);
            Xdr.ClientData clientData1 = new Xdr.ClientData();

            this.m_TwoCellAnchor.Append(fromMarker1);
            this.m_TwoCellAnchor.Append(toMarker1);
            this.m_TwoCellAnchor.Append(connectionShape1);
            this.m_TwoCellAnchor.Append(clientData1);
        }
    }
}
