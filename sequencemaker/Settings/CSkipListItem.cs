using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CSkipListItem : CSettingsListItem
    {
        public CSkipListItem()
        {
            this.m_Key = "hogehoge";
        }

        public override string ToFileRecord()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.m_Enable.ToString());
            sb.Append('\t');
            sb.Append(this.m_Key);

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
