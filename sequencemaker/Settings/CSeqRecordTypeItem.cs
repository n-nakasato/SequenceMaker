using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CSeqRecordTypeItem : CSettingsListItem
    {
        public enum ESeqRecordType
        {
            Unknown,
            Message,
            Function,
            Process,
            Matrix
        }

        public CSeqRecordTypeItem()
        {
            this.m_Key = "MSG";
        }

        private string m_TypeName = "Message";
        public string TypeName
        {
            set 
            {
                this.m_TypeName = value;
                switch (this.m_TypeName)
                {
                    case "Message":
                        this.m_SeqRecordType = ESeqRecordType.Message;
                        break;
                    case "Function":
                        this.m_SeqRecordType = ESeqRecordType.Function;
                        break;
                    case "Process":
                        this.m_SeqRecordType = ESeqRecordType.Process;
                        break;
                    case "Matrix":
                        this.m_SeqRecordType = ESeqRecordType.Matrix;
                        break;
                    default:
                        this.m_SeqRecordType = ESeqRecordType.Unknown;
                        break;
                }
            }
            get { return (this.m_TypeName); }
        }

        private ESeqRecordType m_SeqRecordType = ESeqRecordType.Unknown;
        public ESeqRecordType SeqRecordType
        {
            set { this.m_SeqRecordType = value; }
            get { return (this.m_SeqRecordType); }
        }

        private string m_LineStyle = "実線";
        public string LineStyle
        {
            set { this.m_LineStyle = value; }
            get { return (this.m_LineStyle); }
        }

        private string m_ArrowStyle = "矢印";
        public string ArrowStyle
        {
            set { this.m_ArrowStyle = value; }
            get { return (this.m_ArrowStyle); }
        }

        private Color m_LineColor = Color.Black;
        public Color LineColor
        {
            set { this.m_LineColor = value; }
            get { return (this.m_LineColor); }
        }

        private string m_LineWeight = "1";
        public string LineWeight
        {
            set { this.m_LineWeight = value; }
            get { return (this.m_LineWeight); }
        }

        private Color m_FillColor = Color.White;
        public Color FillColor
        {
            set { this.m_FillColor = value; }
            get { return (this.m_FillColor); }
        }

        private Color m_FontColor = Color.Black;
        public Color FontColor
        {
            set { this.m_FontColor = value; }
            get { return (this.m_FontColor); }
        }

        public override string ToFileRecord()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Enable.ToString());
            sb.Append("\t");
            sb.Append(this.Key);
            sb.Append("\t");
            sb.Append(this.TypeName);
            sb.Append("\t");
            sb.Append(this.LineStyle);
            sb.Append("\t");
            sb.Append(this.ArrowStyle);
            sb.Append("\t");
            sb.Append(this.LineColor.R);
            sb.Append(",");
            sb.Append(this.LineColor.G);
            sb.Append(",");
            sb.Append(this.LineColor.B);
            sb.Append("\t");
            sb.Append(this.LineWeight);
            sb.Append("\t");
            sb.Append(this.FillColor.R);
            sb.Append(",");
            sb.Append(this.FillColor.G);
            sb.Append(",");
            sb.Append(this.FillColor.B);
            sb.Append("\t");
            sb.Append(this.FontColor.R);
            sb.Append(",");
            sb.Append(this.FontColor.G);
            sb.Append(",");
            sb.Append(this.FontColor.B);

            return (sb.ToString());
        }

        public override bool Parse(string fileRecord)
        {
            string[] array;
            bool ret = false;

            try
            {
                array = fileRecord.Split(new char[] { '\t' });
                this.Enable = bool.Parse(array[0]);
                this.Key = array[1];
                this.TypeName = array[2];
                this.LineStyle = array[3];
                this.ArrowStyle = array[4];
                this.LineColor = this.GetColor(array[5]);
                this.LineWeight = array[6];
                this.FillColor = this.GetColor(array[7]);
                this.FontColor = this.GetColor(array[8]);
                ret = true;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            return (ret);
        }

        public void Save(XmlTextWriter writer)
        {
            try
            {
                writer.WriteStartElement("項目");

                writer.WriteAttributeString("Enable", this.Enable.ToString());
                writer.WriteAttributeString("種別", this.TypeName);
                writer.WriteAttributeString("矢印のスタイル", this.ArrowStyle);
                writer.WriteAttributeString("線のスタイル", this.LineStyle.ToString());
                writer.WriteAttributeString("線の色", this.LineColor.ToArgb().ToString());
                writer.WriteAttributeString("線の太さ", this.LineWeight.ToString());
                writer.WriteAttributeString("図形の色", this.FillColor.ToArgb().ToString());
                writer.WriteAttributeString("文字色", this.FontColor.ToArgb().ToString());

                writer.WriteString(this.Key);

                writer.WriteEndElement();				//Elementを閉じます。
            }
            catch
            {
                // なにもしない
            }
        }

    }
}
