using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CSkipList : CSettingsList
    {
        public CSkipList()
        {
            this.m_FileName = @"SkipList.xml";
            this.m_Encode = Encoding.UTF8;
        }

        public void Load()
        {
            CSkipListItem item = null;

            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(this.m_FileName);

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (reader.Name)
                            {
                                case "項目":
                                    if (0 < reader.AttributeCount)
                                    {
                                        item = new CSkipListItem();
                                        item.Enable = bool.Parse(reader.GetAttribute("Enable"));
                                    }
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case XmlNodeType.Text:
                            if (null != item)
                            {
                                item.Key = reader.Value;
                                this.m_Items.Add(item.Key, item);
                            }
                            break;

                        case XmlNodeType.EndElement:
                            switch (reader.Name)
                            {
                                case "項目":
                                    item = null;
                                    break;
                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                // 何もせず
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (null != reader)
                {
                    reader.Close();					//XmlTextWriterを閉じます。
                    reader.Dispose();
                }
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

                writer.WriteStartElement("除外リスト");

                if (0 < this.m_Items.Count)
                {
                    foreach (CSkipListItem now_item in this.m_Items.Values)
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
