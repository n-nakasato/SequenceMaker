using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class CSeqSettings : ISettings
    {
        protected string m_FileName = null;
        protected Encoding m_Encode = null;

        public uint StartColumn = 10;   // 開始列
        public uint StartRow = 2;       // 開始行

        public uint ColumnWidth = 2;    // 列幅
        public uint RowWidth = 15;      // 行幅

        public uint SeqRecordSpace = 3; // レコード間の間隔

        public uint SeqObjSpace = 12;   // オブジェクト間の間隔

        public CDiagramInfo SeqObjInfo = new CDiagramInfo();   // オブジェクトの情報 
        public CDiagramInfo PrcInfo = new CDiagramInfo();   // 処理図形の情報 
        public CDiagramInfo MtxInfo = new CDiagramInfo();   // 状態図形の情報

        public CSeqSettings()
        {
            this.m_FileName = @"SeqSettings.xml";
            this.m_Encode = Encoding.UTF8;
        }

        protected string ToFileRecord()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.StartColumn.ToString());
            sb.Append("\n");
            sb.Append(this.StartRow.ToString());
            sb.Append("\n");
            sb.Append(this.ColumnWidth.ToString());
            sb.Append("\n");
            sb.Append(this.RowWidth.ToString());
            sb.Append("\n");
            sb.Append(this.SeqRecordSpace.ToString());
            sb.Append("\n");
            sb.Append(this.SeqObjSpace.ToString());
            sb.Append("\n");
            sb.Append(this.SeqObjInfo.Width.ToString());
            sb.Append("\n");
            sb.Append(this.SeqObjInfo.Height.ToString());
            sb.Append("\n");
            sb.Append(this.PrcInfo.Width.ToString());
            sb.Append("\n");
            sb.Append(this.PrcInfo.Height.ToString());
            sb.Append("\n");
            sb.Append(this.MtxInfo.Width.ToString());
            sb.Append("\n");
            sb.Append(this.MtxInfo.Height.ToString());

            return (sb.ToString());
        }

        protected bool Parse(string fileRecord)
        {
            bool ret = false;
            string[] array;

            try
            {
                array = fileRecord.Split(new char[] { '\n' });
                this.StartColumn = uint.Parse(array[0]);
                this.StartRow = uint.Parse(array[1]);
                this.ColumnWidth = uint.Parse(array[2]);
                this.RowWidth = uint.Parse(array[3]);
                this.SeqRecordSpace = uint.Parse(array[4]);
                this.SeqObjSpace = uint.Parse(array[5]);
                this.SeqObjInfo.Width = uint.Parse(array[6]);
                this.SeqObjInfo.Height = uint.Parse(array[7]);
                this.PrcInfo.Width = uint.Parse(array[8]);
                this.PrcInfo.Height = uint.Parse(array[9]);
                this.MtxInfo.Width = uint.Parse(array[10]);
                this.MtxInfo.Height = uint.Parse(array[11]);
                ret = true;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            return (ret);
        }

        public bool Load(string tmp)
        {
            bool ret = false;

            XmlTextReader reader = null;

            string type = "";

            try
            {
                reader = new XmlTextReader(this.m_FileName);

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            type = reader.Name;
                            break;

                        case XmlNodeType.Text:
                            switch (type)
                            //switch (reader.Name)
                            {
                                case "開始列":
                                    try
                                    {
                                        this.StartColumn = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "開始行":
                                    try
                                    {
                                        this.StartRow = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "列幅":
                                    try
                                    {
                                        this.ColumnWidth = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "行幅":
                                    try
                                    {
                                        this.RowWidth = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "メッセージ間の間隔":
                                    try
                                    {
                                        this.SeqRecordSpace = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "オブジェクト間の間隔":
                                    try
                                    {
                                        this.SeqObjSpace = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "オブジェクトのサイズ_幅":
                                    try
                                    {
                                        this.SeqObjInfo.Width = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "オブジェクトのサイズ_縦":
                                    try
                                    {
                                        this.SeqObjInfo.Height = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "処理図形のサイズ_幅":
                                    try
                                    {
                                        this.PrcInfo.Width = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "処理図形のサイズ_縦":
                                    try
                                    {
                                        this.PrcInfo.Height = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "状態図形のサイズ_幅":
                                    try
                                    {
                                        this.MtxInfo.Width = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                case "状態図形のサイズ_縦":
                                    try
                                    {
                                        this.MtxInfo.Height = uint.Parse(reader.Value);
                                    }
                                    catch
                                    {
                                        // 何もせず
                                    }
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            type = "";
                            break;

                        default:
                            break;
                    }
                }

                ret = true;
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

            return ret;
        }

        public void Save(string tmp)
        {
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter(this.m_FileName, null);
                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();

                writer.WriteStartElement("シーケンス図作成情報");

                writer.WriteStartElement("開始列");
                writer.WriteString(this.StartColumn.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("開始行");
                writer.WriteString(this.StartRow.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("列幅");
                writer.WriteString(this.ColumnWidth.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("行幅");
                writer.WriteString(this.RowWidth.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("メッセージ間の間隔");
                writer.WriteString(this.SeqRecordSpace.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("オブジェクト間の間隔");
                writer.WriteString(this.SeqObjSpace.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("オブジェクトのサイズ_幅");
                writer.WriteString(this.SeqObjInfo.Width.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("オブジェクトのサイズ_縦");
                writer.WriteString(this.SeqObjInfo.Height.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("処理図形のサイズ_幅");
                writer.WriteString(this.PrcInfo.Width.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("処理図形のサイズ_縦");
                writer.WriteString(this.PrcInfo.Height.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("状態図形のサイズ_幅");
                writer.WriteString(this.MtxInfo.Width.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("状態図形のサイズ_縦");
                writer.WriteString(this.MtxInfo.Height.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

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

        #region ISettings メンバ

        public void Save()
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(this.m_FileName, false, this.m_Encode);
                sw.WriteLine(this.ToFileRecord());
            }
            catch
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                if(null != sw)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        public bool Load()
        {
            bool ret = false;
            StreamReader sr = null;
            string work;

            try
            {
                sr = new StreamReader(this.m_FileName, this.m_Encode);
                work = sr.ReadToEnd();
                this.Parse(work);

                ret = true;
            }
            catch
            {
            }
            finally
            {
                if(null != sr)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }

            return ret;
        }

        #endregion
    }
}
