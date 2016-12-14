using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml;
using A = DocumentFormat.OpenXml.Drawing;
using Xdr = DocumentFormat.OpenXml.Drawing.Spreadsheet;

namespace Excel.Book
{
    public class CShapeText : CShape
    {
        protected A.Text m_Text = null;
        protected A.ParagraphProperties m_ParagraphProperties = null;
        protected A.RgbColorModelHex m_FillColor = null;
        protected A.RgbColorModelHex m_FontColor = null;
        
        public string Text
        {
            get { return (this.m_Text.Text); }
            set { this.m_Text.Text = value; }
        }

        public A.TextAlignmentTypeValues TextAlignment
        {
            get { return (this.m_ParagraphProperties.Alignment); }
            set { this.m_ParagraphProperties.Alignment = value; }
        }

        public string FillColor
        {
            get { return this.m_FillColor.Val; }
            set { this.m_FillColor.Val = value; }
        }

        public string FontColor
        {
            get { return this.m_FontColor.Val; }
            set { this.m_FontColor.Val = value; }
        }

        public CShapeText(uint id, A.ShapeTypeValues shapeType, uint startRow, uint startColumn, uint endRow, uint endColumn)
        {
            this.Id = id;

            this.m_TwoCellAnchor = new Xdr.TwoCellAnchor();

            Xdr.FromMarker fromMarker1 = this.CreateFromMarker(startRow, startColumn, 0, 0);
            Xdr.ToMarker toMarker1 = this.CreateToMarker(endRow, endColumn, 0, 0);

            Shape shape1 = new Shape() { Macro = "", TextLink = "" };

            NonVisualShapeProperties nonVisualShapeProperties1 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties1 = new NonVisualDrawingProperties() { Id = (UInt32Value)this.Id, Name = "フローチャート: 代替処理 1" };
            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties1 = new NonVisualShapeDrawingProperties();

            nonVisualShapeProperties1.Append(nonVisualDrawingProperties1);
            nonVisualShapeProperties1.Append(nonVisualShapeDrawingProperties1);

            ShapeProperties shapeProperties1 = new ShapeProperties();

            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset1 = new A.Offset() { X = 1057275L, Y = 1714500L };
            A.Extents extents1 = new A.Extents() { Cx = 914400L, Cy = 612648L };

            transform2D1.Append(offset1);
            transform2D1.Append(extents1);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = shapeType };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);

            A.SolidFill solidFill1 = new A.SolidFill();

            // 線の色
            this.m_FillColor = new A.RgbColorModelHex();
            solidFill1.Append(this.m_FillColor);

            this.m_Outline = new A.Outline() { CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            // 塗りつぶし
            A.SolidFill solidFill2 = new A.SolidFill();
            this.m_LineColor = new A.RgbColorModelHex();
            solidFill2.Append(this.m_LineColor);

            this.m_PresetDash = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter1 = new A.Miter() { Limit = 800000 };

            this.m_Outline.Append(solidFill2);
            this.m_Outline.Append(this.m_PresetDash);
            this.m_Outline.Append(miter1);
            
            A.EffectList effectList1 = new A.EffectList();

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);
            shapeProperties1.Append(solidFill1);
            shapeProperties1.Append(this.m_Outline);
            shapeProperties1.Append(effectList1);

            ShapeStyle shapeStyle1 = new ShapeStyle();

            A.LineReference lineReference1 = new A.LineReference() { Index = (UInt32Value)2U };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };
            A.Shade shade1 = new A.Shade() { Val = 50000 };

            schemeColor2.Append(shade1);

            lineReference1.Append(schemeColor2);

            A.FillReference fillReference1 = new A.FillReference() { Index = (UInt32Value)1U };
            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            fillReference1.Append(schemeColor3);

            A.EffectReference effectReference1 = new A.EffectReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            effectReference1.Append(schemeColor4);

            A.FontReference fontReference1 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.Light1 };

            fontReference1.Append(schemeColor5);

            shapeStyle1.Append(lineReference1);
            shapeStyle1.Append(fillReference1);
            shapeStyle1.Append(effectReference1);
            shapeStyle1.Append(fontReference1);

            // テキスト関連の設定
            TextBody textBody1 = new TextBody();
            A.BodyProperties bodyProperties1 = new A.BodyProperties() { VerticalOverflow = A.TextVerticalOverflowValues.Clip, HorizontalOverflow = A.TextHorizontalOverflowValues.Clip, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Top };
            A.ListStyle listStyle1 = new A.ListStyle();

            A.Paragraph paragraph1 = new A.Paragraph();
            this.m_ParagraphProperties = new A.ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left };

            A.Run run1 = new A.Run();

            A.RunProperties runProperties1 = new A.RunProperties() { Kumimoji = true, Language = "ja-JP", AlternativeLanguage = "en-US", FontSize = 1100 };

            // フォントカラー
            A.SolidFill solidFill3 = new A.SolidFill();
            this.m_FontColor = new A.RgbColorModelHex(); 
            solidFill3.Append(this.m_FontColor);

            runProperties1.Append(solidFill3);
            this.m_Text = new A.Text();
            this.m_Text.Text = "";

            run1.Append(runProperties1);
            run1.Append(this.m_Text);

            paragraph1.Append(this.m_ParagraphProperties);
            paragraph1.Append(run1);

            textBody1.Append(bodyProperties1);
            textBody1.Append(listStyle1);
            textBody1.Append(paragraph1);

            shape1.Append(nonVisualShapeProperties1);
            shape1.Append(shapeProperties1);
            shape1.Append(shapeStyle1);
            shape1.Append(textBody1);
            ClientData clientData1 = new ClientData();

            this.m_TwoCellAnchor.Append(fromMarker1);
            this.m_TwoCellAnchor.Append(toMarker1);
            this.m_TwoCellAnchor.Append(shape1);
            this.m_TwoCellAnchor.Append(clientData1);
        }
    }
}
