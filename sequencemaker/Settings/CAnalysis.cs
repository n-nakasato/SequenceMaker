using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CAnalysis : CSettingsList
    {
        public CAnalysis()
        {
            this.m_FileName = @"Analysis.xml";
            this.m_Encode = Encoding.UTF8;
        }

        public void Load()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNodeList nodeList = null;
            XmlElement element = null;
            CAnalysisItem item = null;
            string key;
            string after;

            try
            {
                xmlDocument.Load(this.m_FileName);

                nodeList = xmlDocument.SelectNodes("/解析定義/項目");
                if (null != nodeList)
                {
                    foreach(XmlElement now in nodeList)
                    {
                        element = (XmlElement)now.SelectSingleNode("./Key");
                        key = element.InnerText;

                        element = (XmlElement)now.SelectSingleNode("./After");
                        after = element.InnerText;

                        item = new CAnalysisItem(key, after);
                        item.Enable = bool.Parse(now.GetAttribute("Enable"));

                        this.m_Items.Add(item.Key, item);
                    }
                }
            }
            catch (Exception e)
            {
                // 何もせず
                MessageBox.Show(e.Message);
            }
        }

        public void Save(string tmp)
        {
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter(this.m_FileName, null);
                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();

                writer.WriteStartElement("解析定義");

                if (0 < this.m_Items.Count)
                {
                    foreach (CAnalysisItem now_item in this.m_Items.Values)
                    {
                        now_item.Save(writer);
                    }
                }

                writer.WriteEndElement();				//Elementを閉じます。
                writer.WriteEndDocument();				//Documentを閉じます。
            }
            catch
            {
                // 何もせず
            }
            finally
            {
                if (null != writer)
                {
                    writer.Flush();
                    writer.Close();					//XmlTextWriterを閉じます。

                }
            }
        }

    }
}
