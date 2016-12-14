using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CColorOptionItem : CSettingsListItem
    {
        public CColorOptionItem()
        {
            this.m_Key = "hogehoge";
        }
    
        private Color m_BackColor = Color.SkyBlue;
        public Color BackColor
        {
            set { this.m_BackColor = value; }
            get { return (this.m_BackColor); }
        }

        private Color m_FontColor = Color.Red;
        public Color FontColor
        {
            set { this.m_FontColor = value; }
            get { return (this.m_FontColor); }
        }

        public override string ToFileRecord()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.m_Enable.ToString());
            sb.Append('\t');
            sb.Append(this.m_Key);
            sb.Append("\t");
            sb.Append(this.m_BackColor.R);
            sb.Append(",");
            sb.Append(this.m_BackColor.G);
            sb.Append(",");
            sb.Append(this.m_BackColor.B);
            sb.Append("\t");
            sb.Append(this.m_FontColor.R);
            sb.Append(",");
            sb.Append(this.m_FontColor.G);
            sb.Append(",");
            sb.Append(this.m_FontColor.B);

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
                this.m_BackColor = this.GetColor(array[2]);
                this.m_FontColor = this.GetColor(array[3]);
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
                writer.WriteAttributeString("文字色", this.FontColor.ToArgb().ToString());
                writer.WriteAttributeString("背景色", this.BackColor.ToArgb().ToString());

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
