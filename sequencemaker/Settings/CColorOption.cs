using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing;

namespace SEQ_GEN.Settings
{
    public class CColorOption : CSettingsList
    {
        public CColorOption()
        {
            this.m_FileName = @"ColorOption.xml";
            this.m_Encode = Encoding.UTF8;
        }

        public void Load()
        {
            CColorOptionItem item = null;

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
                                        item = new CColorOptionItem();
                                        item.Enable = bool.Parse(reader.GetAttribute("Enable"));
                                        item.FontColor = Color.FromArgb(int.Parse(reader.GetAttribute("文字色")));
                                        item.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("背景色")));
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

                writer.WriteStartElement("色オプション");

                if (0 < this.m_Items.Count)
                {
                    foreach (CColorOptionItem now_item in this.m_Items.Values)
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
