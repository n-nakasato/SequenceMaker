using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CSeqObjItem : CSettingsListItem
    {
        public CSeqObjItem()
        {
            this.m_Key = "xxxタスク";
        }

        private string m_LineStyle = "実線";
        public string LineStyle
        {
            set { this.m_LineStyle = value; }
            get { return (this.m_LineStyle); }
        }

        private Color m_FontColor = Color.Red;
        public Color FontColor
        {
            set { this.m_FontColor = value; }
            get { return (this.m_FontColor); }
        }

        private Color m_FillColor = Color.SkyBlue;
        public Color FillColor
        {
            set { this.m_FillColor = value; }
            get { return (this.m_FillColor); }
        }

        private string m_LineWeight = "1";
        public string LineWeight
        {
            set { this.m_LineWeight = value; }
            get { return (this.m_LineWeight); }
        }

        private uint m_HeaderPos = 0;
        public uint HeaderPos
        {
            get { return (this.m_HeaderPos); }
            set { this.m_HeaderPos = value; }
        }

        public override string ToFileRecord()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.m_Enable.ToString());
            sb.Append("\t");
            sb.Append(this.m_Key);
            sb.Append("\t");
            sb.Append(this.m_FontColor.R);
            sb.Append(",");
            sb.Append(this.m_FontColor.G);
            sb.Append(",");
            sb.Append(this.m_FontColor.B);
            sb.Append("\t");
            sb.Append(this.m_FillColor.R);
            sb.Append(",");
            sb.Append(this.m_FillColor.G);
            sb.Append(",");
            sb.Append(this.m_FillColor.B);
            sb.Append("\t");
            sb.Append(this.m_LineWeight);

            return (sb.ToString());
        }

        public override bool Parse(string fileRecord)
        {
            string[] array;
            bool ret = false;

            try
            {
                array = fileRecord.Split(new char[] { '\t' });
                this.m_Enable = bool.Parse(array[0]);
                this.m_Key = array[1];
                this.m_FontColor = this.GetColor(array[2]);
                this.m_FillColor = this.GetColor(array[3]);
                this.m_LineWeight = array[4];
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
                writer.WriteAttributeString("線のスタイル", this.LineStyle.ToString());
                writer.WriteAttributeString("線の太さ", this.LineWeight.ToString());
                writer.WriteAttributeString("文字色", this.FontColor.ToArgb().ToString());
                writer.WriteAttributeString("背景色", this.FillColor.ToArgb().ToString());
                
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
