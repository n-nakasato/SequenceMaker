using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CAnalysisItem : CSettingsListItem
    {
        public CAnalysisItem() : this("hogehoge", "HOGEHOGE")
        {
        }

        public CAnalysisItem(string key, string after)
        {
            this.m_Key = key;
            this.m_AfterReplace = after;
        }

        private string m_AfterReplace;
        public string AfterReplace
        {
            get { return (this.m_AfterReplace); }
            set { this.m_AfterReplace = value; }
        }

        public override string ToFileRecord()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.m_Enable.ToString());
            sb.Append('\t');
            sb.Append(this.m_Key);
            sb.Append('\t');
            sb.Append(this.m_AfterReplace);

            return (sb.ToString());
        }

        public override bool Parse(string fileRecord)
        {
            string[] array;
            bool ret = false;
            int ctrl_code_pos1;
            int ctrl_code_pos2;

            try
            {
                array = fileRecord.Split(new char[] { '\t' });
                this.m_Enable = bool.Parse(array[0]);
                this.m_Key = array[1];
                this.m_AfterReplace = array[2];

                ctrl_code_pos1 = this.m_AfterReplace.IndexOf("\\t");
                if(0 <= ctrl_code_pos1)
                {
                    ctrl_code_pos2 = this.m_AfterReplace.IndexOf("\\");
                    if(ctrl_code_pos1 == ctrl_code_pos2)
                    {
                        this.m_AfterReplace = this.m_AfterReplace.Replace("\\t", "\t");
                    }
                }
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

                writer.WriteAttributeString("xml:space", "preserve");
                writer.WriteAttributeString("Enable", this.Enable.ToString());

                writer.WriteStartElement("Key");
                writer.WriteString(this.Key);
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("After");
                writer.WriteString(this.AfterReplace);
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteEndElement();				//Elementを閉じます。
            }
            catch
            {
                // なにもしない
            }
        }

    }
}
