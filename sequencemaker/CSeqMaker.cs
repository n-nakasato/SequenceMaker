using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SEQ_GEN.Settings;
using System.Windows.Forms;
using Excel.Book;
using DocumentFormat.OpenXml.Drawing;
using Excel.StyleSheet;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

namespace SEQ_GEN
{
    public class CSeqMaker
    {
        protected string m_FileName;
        protected string m_OrgSheetName;
        protected string m_SeqSheetName;
        protected uint m_OrgSheetRow;
        protected uint m_OrgSheetColumn;
        protected uint m_SeqSheetRow;
        protected uint m_SeqSheetColumn;
        protected CSettings m_Settings;
        protected Dictionary<string, CSeqRecord> m_ConvergencyCollection;

        protected CWorkbook m_Book;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName"></param>
        public CSeqMaker(string fileName)
        {
            this.m_FileName = fileName;
            this.m_OrgSheetName = "元データ";
            this.m_SeqSheetName = "シーケンス図";
            this.m_ConvergencyCollection = new Dictionary<string, CSeqRecord>();
        }

        /// <summary>
        /// 設定データのプロパティ
        /// </summary>
        public CSettings Settings
        {
            get { return (this.m_Settings); }
            set { this.m_Settings = value; }
        }

        /// <summary>
        /// エクセルオープン
        /// </summary>
        public void Open()
        {
            // ワークブック起動
            this.m_Book = new CWorkbook();
            this.m_Book.FileName = this.m_FileName;

            try
            {
                this.m_Book.Open();

                // シートの作成
                this.m_Book.Worksheets.Add(this.m_SeqSheetName, this.m_Settings.SeqSettings.RowWidth, this.m_Settings.SeqSettings.ColumnWidth);
                this.m_Book.Worksheets.Add(this.m_OrgSheetName);

                this.m_SeqSheetRow = this.m_Settings.SeqSettings.StartRow;
                this.m_SeqSheetColumn = this.m_Settings.SeqSettings.StartColumn;
                this.m_OrgSheetRow = 1;
                this.m_OrgSheetColumn = 1;

                this.DrawHeader();

                this.m_SeqSheetRow += this.AddVerticalLine(this.m_Settings.SeqSettings.SeqRecordSpace, null);
            }
            catch(Exception e)
            {
                this.m_Book = null;
                throw e;
            }
        }

        /// <summary>
        /// エクセルクローズ
        /// </summary>
        public void Close()
        {
            try
            {
                if (null != this.m_Book)
                {
                    this.m_Book.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                this.m_Book = null;
            }
        }

        /// <summary>
        /// シーケンス図のヘッダーを出力
        /// </summary>
        private void DrawHeader()
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CShapeText shape;
            uint startColumn;
            uint startRow;

            startColumn = this.m_SeqSheetColumn;
            startRow = this.m_SeqSheetRow;

            foreach (CSeqObjItem obj in this.m_Settings.SeqObj.Items)
            {
                if (obj.Enable)
                {
                    obj.HeaderPos = startColumn;

                    shape = seqSheet.DrawShape_Text(
                        ShapeTypeValues.FlowChartAlternateProcess,
                        startRow - 1, 
                        startColumn - ((this.m_Settings.SeqSettings.SeqObjInfo.Width / 2) + 1),
                        startRow + (this.m_Settings.SeqSettings.SeqObjInfo.Height - 1),
                        startColumn + ((this.m_Settings.SeqSettings.SeqObjInfo.Width / 2) - 1)
                    );

                    shape.LineColor = this.ToShapeRgb(System.Drawing.Color.Black);
                    shape.FillColor = this.ToShapeRgb(obj.FillColor);
                    shape.LineWidth = double.Parse(obj.LineWeight);
                    shape.Text = obj.Key;
                    shape.FontColor = this.ToShapeRgb(obj.FontColor);
                    shape.TextAlignment = TextAlignmentTypeValues.Center;

                    startColumn += this.m_Settings.SeqSettings.SeqObjSpace;
                }
            }
        }

        /// <summary>
        /// 縦線を描画
        /// </summary>
        /// <param name="lineCount"></param>
        /// <returns></returns>
        private uint AddVerticalLine(uint lineCount, CSeqRecord record)
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            string[] styleInfo;
            uint startRow;
            uint endRow;
            uint borderId;
            uint styleId;
            bool flag = true;

            startRow = this.m_SeqSheetRow;
            endRow = startRow + lineCount;

            for (; startRow < endRow; startRow++)
            {
                // 罫線用のスタイルを取得
                borderId = this.m_Book.StyleSheet.Borders.Add(BorderStyleValues.None, BorderStyleValues.Thin, BorderStyleValues.None, BorderStyleValues.None);
                styleId = seqSheet.Cells[startRow, 1].StyleIndex;
                styleInfo = this.m_Book.StyleSheet.CCellFormats.Get(styleId);
                styleId = this.m_Book.StyleSheet.CCellFormats.Add(
                    uint.Parse(styleInfo[0]),
                    uint.Parse(styleInfo[1]),
                    uint.Parse(styleInfo[2]),
                    borderId,
                    uint.Parse(styleInfo[4]),
                    CCellFormats.ToHorizontalAlignmentValues(styleInfo[5]),
                    CCellFormats.ToVerticalAlignmentValues(styleInfo[6])
                );

                foreach (CSeqObjItem obj in this.m_Settings.SeqObj.Items)
                {
                    if (obj.Enable)
                    {
                        if(null != record)
                        {
                            if (flag)
                            {
                                // メッセージ名をセルに出力
                                if(this.SetMessageName(record, startRow, obj))
                                {
                                    flag = false;
                                }
                            }
                        }

                        try
                        {
                            seqSheet.Cells[startRow, obj.HeaderPos].StyleIndex = styleId;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            return (lineCount);
        }

        /// <summary>
        /// Colorオブジェクトをエクセル用のRGBに変換
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private string ToShapeRgb(System.Drawing.Color color)
        {
            string cnvStr = "";

            cnvStr += color.R.ToString("X2");
            cnvStr += color.G.ToString("X2");
            cnvStr += color.B.ToString("X2");

            return (cnvStr);
        }

        /// <summary>
        /// Colorオブジェクトをエクセル用のRGBに変換
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private string ToCellRgb(System.Drawing.Color color)
        {
            string cnvStr = "FF";

            cnvStr += color.R.ToString("X2");
            cnvStr += color.G.ToString("X2");
            cnvStr += color.B.ToString("X2");

            return (cnvStr);
        }

        /// <summary>
        /// 矢印の種別を取得
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        private LineEndValues ToLineEndValues(string style)
        {
            LineEndValues ret;

            switch (style)
            {
                case "矢印なし":
                    ret = LineEndValues.None;
                    break;
                case "矢印":
                    ret = LineEndValues.Triangle;
                    break;
                case "開いた矢印":
                    ret = LineEndValues.Arrow;
                    break;
                case "鋭い矢印":
                    ret = LineEndValues.Stealth;
                    break;
                case "ひし形矢印":
                    ret = LineEndValues.Diamond;
                    break;
                case "円形矢印":
                    ret = LineEndValues.Oval;
                    break;
                default:
                    ret = LineEndValues.None;
                    break;
            }

            return (ret);
        }

        /// <summary>
        /// 線の種類を取得
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        private PresetLineDashValues ToLineDashValues(string style)
        {
            PresetLineDashValues ret;

            switch(style)
            {
                case "実線":
                    ret = PresetLineDashValues.Solid;
                    break;
                case "点線(丸)":
                    ret = PresetLineDashValues.SystemDot;
                    break;
                case "点線(角)":
                    ret = PresetLineDashValues.SystemDash;
                    break;
                case "一点鎖線":
                    ret = PresetLineDashValues.SystemDashDot;
                    break;
                case "二点鎖線":
                    ret = PresetLineDashValues.SystemDashDotDot;
                    break;
                case "長破線":
                    ret = PresetLineDashValues.LargeDash;
                    break;
                case "長一点鎖線":
                    ret = PresetLineDashValues.LargeDashDot;
                    break;
                default:
                    ret = PresetLineDashValues.Solid;
                    break;
            }

            return (ret);
        }

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="record"></param>
        public void AddRow(CSeqRecord record)
        {
            this.AddOrgRow(record);
            this.AddSeqRow(record);
            this.m_Book.Save();
        }

        /// <summary>
        /// 元データに出力
        /// </summary>
        /// <param name="record"></param>
        private void AddOrgRow(CSeqRecord record)
        {
            CStyleSheet styleSheet = this.m_Book.StyleSheet;
            CWorksheet orgSheet = this.m_Book.Worksheets[this.m_OrgSheetName];
            uint column = this.m_OrgSheetColumn;
            uint row = this.m_OrgSheetRow;
            string[] outData = record.ToExcelFormat();

            orgSheet.Cells[row, column].Value = outData[0];

            foreach (string now_data in outData)
            {
                orgSheet.Cells[row, column].Value = now_data;
                column++;
            }

            uint fontId = 0;
            uint fillId = 0;

            if (null != record.ColorOptionItem)
            {
                if (record.ColorOptionItem.Enable)
                {
                    // バックカラー設定
                    fillId = styleSheet.Fills.Add(
                        PatternValues.Solid,
                        this.ToCellRgb(record.ColorOptionItem.BackColor)
                    );

                    // フォントカラー設定
                    fontId = styleSheet.Fonts.Add(
                        fontColor: this.ToCellRgb(record.ColorOptionItem.FontColor)
                    );

                    // セルにスタイルを設定
                    orgSheet.Rows[row].StyleIndex = styleSheet.CCellFormats.Add(
                        fillId: fillId,
                        fontId: fontId
                    );
                }
            }

            record.OrgSheetRow = this.m_OrgSheetRow;
            this.m_OrgSheetRow++;
        }

        /// <summary>
        /// シーケンス図シートに出力
        /// </summary>
        /// <param name="record"></param>
        private void AddSeqRow(CSeqRecord record)
        {
            uint row = 0;
            ISettingsListItem skip;

            if (null == record.SeqRecordTypeItem)
            {
                return;
            }

            if (!record.SeqRecordTypeItem.Enable)
            {
                return;
            }

            skip = this.m_Settings.SkipList.Serch(record.DispName);
            if ((null != skip) && (skip.Enable))
            {
                return;
            }

            switch(record.SeqRecordTypeItem.SeqRecordType)
            {
                case CSeqRecordTypeItem.ESeqRecordType.Message:
                    switch (this.m_Settings.OtherSettings.Convergency)
                    {
                        case COtherSettings.EConvergency.Yes:
                            row = this.DrawConvergencyMessage(record);
                            break;
                        case COtherSettings.EConvergency.No_SR:
                            row = this.DrawMessage(record);
                            break;
                        case COtherSettings.EConvergency.No_R:
                            if (CSeqRecord.EDerection.Rcv == record.Derection)
                            {
                                row = this.DrawMessage(record);
                            }
                            break;
                        case COtherSettings.EConvergency.No_S:
                            if (CSeqRecord.EDerection.Snd == record.Derection)
                            {
                                row = this.DrawMessage(record);
                            }
                            break;
                        default:
                            break;
                    }            
                    break;
                case CSeqRecordTypeItem.ESeqRecordType.Function:
                    row = this.DrawMessage(record);
                    break;
                case CSeqRecordTypeItem.ESeqRecordType.Process:
                    row = this.DrawProc(record);
                    break;
                case CSeqRecordTypeItem.ESeqRecordType.Matrix:
                    row = this.DrawMatrix(record);
                    break;
                default:
                    // なにもしない。
                    break;
            }

            if (0 < row)
            {
                // ハイパーリンク設定
                this.CreateHyperLink(record);
            }

            this.m_SeqSheetRow += row;
        }

        /// <summary>
        /// 矢印を描画する
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        private CShapeLine DrawShapeLine(uint startRow, uint startColumn, uint endRow, uint endColumn, CSeqRecord record)
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CShapeLine line = seqSheet.DrawShape_AllowLine(startRow, startColumn, endRow, endColumn);

            line.LineColor = this.ToShapeRgb(record.SeqRecordTypeItem.LineColor);
            line.LineWidth = double.Parse(record.SeqRecordTypeItem.LineWeight);
            line.PresetDash = this.ToLineDashValues(record.SeqRecordTypeItem.LineStyle);

            return line;
        }

        /// <summary>
        /// 矢印に矢印をつける(頭の方)
        /// </summary>
        /// <param name="line"></param>
        /// <param name="style"></param>
        private void SetHeadLineEnd(CShapeLine line, string style)
        {
            line.HeadEndStyle = this.ToLineEndValues(style);
            line.HeadEndWidth = LineEndWidthValues.Large;
            line.HeadEndLength = LineEndLengthValues.Large;
        }

        /// <summary>
        /// 矢印に矢印をつける(後ろの方)
        /// </summary>
        /// <param name="line"></param>
        /// <param name="style"></param>
        private void SetTailLineEnd(CShapeLine line, string style)
        {
            line.TailEndStyle = this.ToLineEndValues(style);
            line.TailEndWidth = LineEndWidthValues.Large;
            line.TailEndLength = LineEndLengthValues.Large;
        }

        /// <summary>
        /// テキスト有りのシェイプを描画
        /// </summary>
        /// <param name="style"></param>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        private CShapeText DrawShapeText(ShapeTypeValues style, uint startRow, uint startColumn, uint endRow, uint endColumn, CSeqRecord record)
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CShapeText text;

            text = seqSheet.DrawShape_Text(style, startRow - 1, startColumn - 1, endRow, endColumn - 1);

            text.FillColor = this.ToShapeRgb(record.SeqRecordTypeItem.FillColor);
            text.LineColor = this.ToShapeRgb(record.SeqRecordTypeItem.LineColor);
            text.LineWidth = double.Parse(record.SeqRecordTypeItem.LineWeight);
            text.PresetDash = this.ToLineDashValues(record.SeqRecordTypeItem.LineStyle);
            text.Text = record.DispName;
            text.TextAlignment = TextAlignmentTypeValues.Center;
            text.FontColor = this.ToShapeRgb(record.SeqRecordTypeItem.FontColor);

            return text;
        }

        /// <summary>
        /// セルにメッセージを設定
        /// </summary>
        /// <param name="record"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="horizon"></param>
        private bool SetMessageName(CSeqRecord record, uint row, CSeqObjItem seqObj)
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CStyleSheet styleSheet = this.m_Book.StyleSheet;
            string[] styleInfo;
            uint styleId = 0;
            uint column = 0;
            HorizontalAlignmentValues horizon = HorizontalAlignmentValues.Left;

            if (null == record.SrcSeqObjItem)
            {
                return false;
            }

            if (null == record.DstSeqObjItem)
            {
                return false;
            }

            if (null == record.SeqRecordTypeItem)
            {
                return false;
            }

            if (!record.SrcSeqObjItem.Enable)
            {
                return false;
            }

            if (!record.DstSeqObjItem.Enable)
            {
                return false;
            }

            if (!record.SeqRecordTypeItem.Enable)
            {
                return false;
            }

            switch(record.SeqRecordTypeItem.SeqRecordType)
            {
                case CSeqRecordTypeItem.ESeqRecordType.Message:
                    switch(this.m_Settings.OtherSettings.Convergency)
                    {
                        case COtherSettings.EConvergency.Yes:
                            if (CSeqRecord.EDerection.Snd == record.Derection)
                            {
                                if (record.SrcSeqObjItem.HeaderPos <= record.DstSeqObjItem.HeaderPos)
                                {
                                    column = record.SrcSeqObjItem.HeaderPos;
                                    horizon = HorizontalAlignmentValues.Left;
                                }
                                else
                                {
                                    column = record.SrcSeqObjItem.HeaderPos - 1;
                                    horizon = HorizontalAlignmentValues.Right;
                                }
                            }
                            else
                            {
                                if (record.SrcSeqObjItem.HeaderPos < record.DstSeqObjItem.HeaderPos)
                                {
                                    column = record.DstSeqObjItem.HeaderPos - 1;
                                    horizon = HorizontalAlignmentValues.Right;
                                }
                                else
                                {
                                    column = record.DstSeqObjItem.HeaderPos;
                                    horizon = HorizontalAlignmentValues.Left;
                                }
                            }

                            break;

                        case COtherSettings.EConvergency.No_SR:
                        case COtherSettings.EConvergency.No_R:
                        case COtherSettings.EConvergency.No_S:
                            if (record.SrcSeqObjItem.HeaderPos <= record.DstSeqObjItem.HeaderPos)
                            {
                                column = record.SrcSeqObjItem.HeaderPos;
                                horizon = HorizontalAlignmentValues.Left;
                            }
                            else
                            {
                                column = record.SrcSeqObjItem.HeaderPos - 1;
                                horizon = HorizontalAlignmentValues.Right;
                            }
                            break;

                        default:
                            return false;
                    }
                    break;
                
                case CSeqRecordTypeItem.ESeqRecordType.Function:
                    if (record.SrcSeqObjItem.HeaderPos <= record.DstSeqObjItem.HeaderPos)
                    {
                        column = record.SrcSeqObjItem.HeaderPos;
                        horizon = HorizontalAlignmentValues.Left;
                    }
                    else
                    {
                        column = record.SrcSeqObjItem.HeaderPos - 1;
                        horizon = HorizontalAlignmentValues.Right;
                    }
                    break;

                default:
                    return false;
            }

            if(0 == column)
            {
                return false;
            }

            if(seqObj.HeaderPos < column)
            {
                return false;
            }

            if (this.m_Settings.OtherSettings.IsNameAndParam)
            {
                seqSheet.Cells[row, column].Value = record.NameParam.Trim();
            }
            else
            {
                seqSheet.Cells[row, column].Value = record.DispName.Trim();
            }

            styleId = seqSheet.Cells[row, column].StyleIndex;

            styleInfo = this.m_Book.StyleSheet.CCellFormats.Get(styleId);

            styleId = this.m_Book.StyleSheet.CCellFormats.Add(
                uint.Parse(styleInfo[0]),
                uint.Parse(styleInfo[1]),
                uint.Parse(styleInfo[2]),
                uint.Parse(styleInfo[3]),
                uint.Parse(styleInfo[4]),
                horizon,
                CCellFormats.ToVerticalAlignmentValues(styleInfo[6])
            );

            seqSheet.Cells[row, column].StyleIndex = styleId;

            return true;
        }


        /// <summary>
        /// カラーオプション反映
        /// </summary>
        private void InfluenceColorOption(CSeqRecord record)
        {
            CWorksheet orgSheet = this.m_Book.Worksheets[this.m_OrgSheetName];
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CStyleSheet styleSheet = this.m_Book.StyleSheet;
            uint styleId = 0;
            string[] styleInfo;

            styleId = orgSheet.Rows[this.m_OrgSheetRow - 1].StyleIndex;
            if(0 == styleId)
            {
                return;
            }

            styleInfo = this.m_Book.StyleSheet.CCellFormats.Get(styleId);

            styleId = this.m_Book.StyleSheet.CCellFormats.Add(
                uint.Parse(styleInfo[0]),
                uint.Parse(styleInfo[1]),
                uint.Parse(styleInfo[2]),
                uint.Parse(styleInfo[3]),
                uint.Parse(styleInfo[4]),
                CCellFormats.ToHorizontalAlignmentValues(styleInfo[5]),
                CCellFormats.ToVerticalAlignmentValues(styleInfo[6])
            );

            seqSheet.Rows[this.m_SeqSheetRow].StyleIndex = styleId;
        }

        /// <summary>
        /// 種別＝Messageを描画(輻輳シーケンス)
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private uint DrawConvergencyMessage(CSeqRecord record)
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CStyleSheet styleSheet = this.m_Book.StyleSheet;
            CShapeLine line;
            uint srcColumn;
            uint dstColumn;
            string registKey;
            string connectKey;
            CSeqRecord connectTarget;
            Dictionary<string, CSeqRecord> collection;

            if (null == record.SrcSeqObjItem)
            {
                return 0;
            }

            if (null == record.DstSeqObjItem)
            {
                return 0;
            }

            if (null == record.SeqRecordTypeItem)
            {
                return 0;
            }

            if (!record.SrcSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.DstSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.SeqRecordTypeItem.Enable)
            {
                return 0;
            }

            srcColumn = 0;
            dstColumn = 0;

            switch (record.Derection)
            {
                case CSeqRecord.EDerection.Snd:
                    if (record.SrcSeqObjItem.HeaderPos <= record.DstSeqObjItem.HeaderPos)
                    {
                        srcColumn = record.SrcSeqObjItem.HeaderPos - 1;
                        dstColumn = srcColumn + 3;
                    }
                    else
                    {
                        srcColumn = record.SrcSeqObjItem.HeaderPos - 1;
                        dstColumn = srcColumn - 3;
                    }
                    break;

                case CSeqRecord.EDerection.Rcv:
                    if (record.SrcSeqObjItem.HeaderPos < record.DstSeqObjItem.HeaderPos)
                    {
                        srcColumn = record.DstSeqObjItem.HeaderPos - 1;
                        dstColumn = srcColumn - 3;
                    }
                    else
                    {
                        srcColumn = record.DstSeqObjItem.HeaderPos - 1;
                        dstColumn = srcColumn + 3;
                    }
                    break;

                default:
                    break;
            }

            //////////////////////////////////////////////////////
            // 横線を描画
            //////////////////////////////////////////////////////
            if (srcColumn <= dstColumn)
            {
                line = this.DrawShapeLine(
                    this.m_SeqSheetRow,
                    srcColumn,
                    this.m_SeqSheetRow,
                    dstColumn,
                    record
                );
            }
            else
            {
                line = this.DrawShapeLine(
                    this.m_SeqSheetRow,
                    dstColumn,
                    this.m_SeqSheetRow,
                    srcColumn,
                    record
                );
            }

            //////////////////////////////////////////////////////
            // 細々した設定
            //////////////////////////////////////////////////////
            record.SeqSheetPos = new CSeqDrawPos();
            switch (record.Derection)
            {
                case CSeqRecord.EDerection.Snd:
                    if (record.SrcSeqObjItem.HeaderPos <= record.DstSeqObjItem.HeaderPos)
                    {
                        this.SetTailLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
                    }
                    else
                    {
                        this.SetHeadLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
                    }
                    break;

                case CSeqRecord.EDerection.Rcv:
                    if (record.SrcSeqObjItem.HeaderPos < record.DstSeqObjItem.HeaderPos)
                    {
                        this.SetTailLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
                    }
                    else
                    {
                        this.SetHeadLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
                    }
                    break;

                default:
                    break;
            }

            record.SeqSheetPos.X = dstColumn;
            record.SeqSheetPos.Y = this.m_SeqSheetRow;

            collection = this.m_ConvergencyCollection;

            //////////////////////////////////////////////////////
            // 斜めの線を描画
            //////////////////////////////////////////////////////
            connectKey = record.ToConvergencyConnectKey();
            if (collection.ContainsKey(connectKey))
            {
                connectTarget = collection[connectKey];

                uint sY;
                uint sX;
                uint eY;
                uint eX;

                sY = connectTarget.SeqSheetPos.Y;
                sX = connectTarget.SeqSheetPos.X;
                eY = record.SeqSheetPos.Y;
                eX = record.SeqSheetPos.X;

                line = this.DrawShapeLine(sY, sX, eY, eX, record);

                //switch (record.Derection)
                //{
                //    case CSeqRecord.EDerection.Snd:
                //        this.SetHeadLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
                //        break;

                //    case CSeqRecord.EDerection.Rcv:
                //        this.SetTailLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
                //        break;

                //    default:
                //        break;
                //}

                collection.Remove(connectKey);
            }
            else
            {
                //////////////////////////////////////////////////////
                // ディクショナリーに登録
                //////////////////////////////////////////////////////
                registKey = record.ToConvergencyRegistKey();
                if (collection.ContainsKey(registKey))
                {
                    collection.Remove(registKey);
                }
                collection.Add(registKey, record);
            }

            this.InfluenceColorOption(record);

            return (this.AddVerticalLine(this.m_Settings.SeqSettings.SeqRecordSpace, record));
        }

        /// <summary>
        /// 種別＝Messageを描画
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private uint DrawMessage(CSeqRecord record)
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CShapeLine line;
            uint srcColumn;
            uint dstColumn;

            if (null == record.SrcSeqObjItem)
            {
                return 0;
            }

            if (null == record.DstSeqObjItem)
            {
                return 0;
            }

            if (null == record.SeqRecordTypeItem)
            {
                return 0;
            }

            if (!record.SrcSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.DstSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.SeqRecordTypeItem.Enable)
            {
                return 0;
            }


            if (record.SrcSeqObjItem.HeaderPos < record.DstSeqObjItem.HeaderPos)
            {
                srcColumn = record.SrcSeqObjItem.HeaderPos - 1;
                dstColumn = record.DstSeqObjItem.HeaderPos - 1;
            }
            else if (record.SrcSeqObjItem.HeaderPos > record.DstSeqObjItem.HeaderPos)
            {
                srcColumn = record.DstSeqObjItem.HeaderPos - 1;
                dstColumn = record.SrcSeqObjItem.HeaderPos - 1;
            }
            else
            {
                return (this.DrawMessageForMe(record));
            }

            //////////////////////////////////////////////////////
            // 横線を描画
            //////////////////////////////////////////////////////
            line = this.DrawShapeLine(
                this.m_SeqSheetRow, 
                srcColumn,
                this.m_SeqSheetRow, 
                dstColumn,
                record
            );

            //////////////////////////////////////////////////////
            // 細々した設定
            //////////////////////////////////////////////////////
            if (record.SrcSeqObjItem.HeaderPos < record.DstSeqObjItem.HeaderPos)
            {
                this.SetTailLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
            }
            else
            {
                this.SetHeadLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);
            }

            this.InfluenceColorOption(record);

            return (this.AddVerticalLine(this.m_Settings.SeqSettings.SeqRecordSpace, record));
        }

        /// <summary>
        /// 種別＝Message(自分宛て)を描画
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private uint DrawMessageForMe(CSeqRecord record)
        {
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            CShapeLine line;
            uint srcColumn;
            uint dstColumn;

            if (null == record.SrcSeqObjItem)
            {
                return 0;
            }

            if (null == record.DstSeqObjItem)
            {
                return 0;
            }

            if (null == record.SeqRecordTypeItem)
            {
                return 0;
            }

            if (!record.SrcSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.DstSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.SeqRecordTypeItem.Enable)
            {
                return 0;
            }

            srcColumn = record.SrcSeqObjItem.HeaderPos - 1;
            dstColumn = record.DstSeqObjItem.HeaderPos - 1;
            dstColumn += 3;

            //////////////////////////////////////////////////////
            // 横線を描画
            //////////////////////////////////////////////////////
            line = this.DrawShapeLine(
                this.m_SeqSheetRow,
                srcColumn,
                this.m_SeqSheetRow,
                dstColumn,
                record
            );

            //////////////////////////////////////////////////////
            // 縦線を描画
            //////////////////////////////////////////////////////
            line = this.DrawShapeLine(
                this.m_SeqSheetRow,
                dstColumn,
                this.m_SeqSheetRow + 1,
                dstColumn,
                record
            );

            //////////////////////////////////////////////////////
            // 横線を描画
            //////////////////////////////////////////////////////
            line = this.DrawShapeLine(
                this.m_SeqSheetRow + 1,
                srcColumn,
                this.m_SeqSheetRow + 1,
                dstColumn,
                record
            );

            this.SetHeadLineEnd(line, record.SeqRecordTypeItem.ArrowStyle);

            this.InfluenceColorOption(record);

            return (this.AddVerticalLine(this.m_Settings.SeqSettings.SeqRecordSpace, record));
        }

        /// <summary>
        /// 種別＝Processを描画
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private uint DrawProc(CSeqRecord record)
        {
            CShapeText text;
            uint startRow;
            uint endRow;
            uint startColumn;
            uint endColumn;
            uint lineCount;

            if (null == record.SrcSeqObjItem)
            {
                return 0;
            }

            if (null == record.DstSeqObjItem)
            {
                return 0;
            }

            if (null == record.SeqRecordTypeItem)
            {
                return 0;
            }

            if (!record.SrcSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.DstSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.SeqRecordTypeItem.Enable)
            {
                return 0;
            }

            startRow = this.m_SeqSheetRow;
            endRow = startRow + (this.m_Settings.SeqSettings.PrcInfo.Height - 1);

            startColumn = record.SrcSeqObjItem.HeaderPos;
            startColumn -= (this.m_Settings.SeqSettings.PrcInfo.Width / 2 - 1);

            endColumn = record.SrcSeqObjItem.HeaderPos;
            endColumn += (this.m_Settings.SeqSettings.PrcInfo.Width / 2 - 1);

            text = this.DrawShapeText(ShapeTypeValues.FlowChartProcess, startRow, startColumn, endRow, endColumn, record);

            this.InfluenceColorOption(record);

            lineCount = this.m_Settings.SeqSettings.PrcInfo.Height + this.m_Settings.SeqSettings.SeqRecordSpace;

            return (this.AddVerticalLine(lineCount, record));
        }

        /// <summary>
        /// 種別＝Matrixを描画
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private uint DrawMatrix(CSeqRecord record)
        {
            CShapeText text;
            uint startRow;
            uint endRow;
            uint startColumn;
            uint endColumn;
            uint lineCount;

            if (null == record.SrcSeqObjItem)
            {
                return 0;
            }

            if (null == record.DstSeqObjItem)
            {
                return 0;
            }

            if (null == record.SeqRecordTypeItem)
            {
                return 0;
            }

            if (!record.SrcSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.DstSeqObjItem.Enable)
            {
                return 0;
            }

            if (!record.SeqRecordTypeItem.Enable)
            {
                return 0;
            }

            startRow = this.m_SeqSheetRow;
            endRow = startRow + (this.m_Settings.SeqSettings.PrcInfo.Height - 1);

            startColumn = record.SrcSeqObjItem.HeaderPos;
            startColumn -= (this.m_Settings.SeqSettings.PrcInfo.Width / 2 - 1);

            endColumn = record.SrcSeqObjItem.HeaderPos;
            endColumn += (this.m_Settings.SeqSettings.PrcInfo.Width / 2 - 1);

            text = this.DrawShapeText(ShapeTypeValues.FlowChartPreparation, startRow, startColumn, endRow, endColumn, record);

            this.InfluenceColorOption(record);

            lineCount = this.m_Settings.SeqSettings.MtxInfo.Height + this.m_Settings.SeqSettings.SeqRecordSpace;

            return (this.AddVerticalLine(lineCount,record));
        }

        /// <summary>
        /// ハイパーリンク作成
        /// </summary>
        /// <param name="record"></param>
        private void CreateHyperLink(CSeqRecord record)
        {
            CWorksheet orgSheet = this.m_Book.Worksheets[this.m_OrgSheetName];
            CWorksheet seqSheet = this.m_Book.Worksheets[this.m_SeqSheetName];
            StringBuilder address = new StringBuilder();
            StringBuilder link = new StringBuilder();

            address.Append(this.m_OrgSheetName);
            address.Append("!");
            address.Append(orgSheet.Cells[record.OrgSheetRow, 1].ColumnName);
            address.Append(record.OrgSheetRow.ToString());

            link.Append("=HYPERLINK(\"[");
            link.Append(this.m_Book.FileName);
            link.Append("]");
            link.Append(address.ToString());
            link.Append("\",");
            link.Append(address.ToString());
            link.Append(")");

            seqSheet.Cells[this.m_SeqSheetRow, 1].Formula = link.ToString();
        }
    }
}
