using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;

namespace SEQ_GEN.Settings
{
    public class CSeqRecordType : CSettingsList
    {
        public CSeqRecordType()
        {
            this.m_FileName = @"SeqRecordType.xml";
            this.m_Encode = Encoding.UTF8;
        }

        public void Load()
        {
            CSeqRecordTypeItem item = null;

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
                                        item = new CSeqRecordTypeItem();
                                        item.Enable = bool.Parse(reader.GetAttribute("Enable"));
                                        item.TypeName = reader.GetAttribute("種別");
                                        item.ArrowStyle = reader.GetAttribute("矢印のスタイル");
                                        item.LineStyle = reader.GetAttribute("線のスタイル");
                                        item.LineColor = Color.FromArgb(int.Parse(reader.GetAttribute("線の色")));
                                        item.LineWeight = reader.GetAttribute("線の太さ");
                                        item.FillColor = Color.FromArgb(int.Parse(reader.GetAttribute("図形の色")));
                                        item.FontColor = Color.FromArgb(int.Parse(reader.GetAttribute("文字色")));
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

                writer.WriteStartElement("シーケンス種別");

                if (0 < this.m_Items.Count)
                {
                    foreach (CSeqRecordTypeItem now_item in this.m_Items.Values)
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
