using SEQ_GEN.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SEQ_GEN.Settings
{
    public class COtherSettings : ISettings
    {
        /// <summary>
        /// 輻輳シーケンスのオプション
        /// </summary>
        public enum EConvergency
        {
            /// <summary>
            /// 輻輳シーケンス有り
            /// </summary>
            Yes,

            /// <summary>
            /// 輻輳シーケンス無し(送受信)
            /// </summary>
            No_SR,

            /// <summary>
            /// 輻輳シーケンス無し(受信のみ)
            /// </summary>
            No_R,

            /// <summary>
            /// 輻輳シーケンス無し(送信のみ)
            /// </summary>
            No_S
        }

        /// <summary>
        /// 輻輳シーケンスのオプション
        /// </summary>
        public EConvergency Convergency = EConvergency.Yes;

        /// <summary>
        /// 名前とパラメータの両方出力するオプション
        /// </summary>
        public bool IsNameAndParam = false;
        
        /// <summary>
        /// インポート時のセパレータ文字列
        /// </summary>
        public string ImportSeparator = ",";

        /// <summary>
        /// インポート時の識別文字列
        /// </summary>
        public string SeqId = "SEQ";

        /// <summary>
        /// 解析前ファイルの文字コード
        /// </summary>
        public Encoding AnalysisBeforeEncode = Encoding.UTF8;

        /// <summary>
        /// 解析後ファイルの文字コード
        /// </summary>
        public Encoding AnalysisAfterEncode = Encoding.UTF8;

        /// <summary>
        /// インポートファイルの文字コード
        /// </summary>
        public Encoding ImportEncode = Encoding.UTF8;

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        protected string m_FileName = null;

        /// <summary>
        /// 設定ファイルの文字コード
        /// </summary>
        protected Encoding m_Encode = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public COtherSettings()
        {
            this.m_FileName = @"OtherSettings.xml";
            this.m_Encode = Encoding.UTF8;
        }

        /// <summary>
        /// 文字列から文字コードを取得する
        /// </summary>
        /// <param name="enc"></param>
        /// <returns></returns>
        public Encoding GetEncodeing(string enc)
        {
            Encoding ret = null;

            switch (enc)
            {
                case "utf-8":
                    ret = Encoding.UTF8;
                    break;
                default:
                    ret = Encoding.GetEncoding(enc);
                    break;
            }

            return ret;
        }

        /// <summary>
        /// 文字列から輻輳シーケンスのオプションを取得する
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public EConvergency GetConvergency(string data)
        {
            EConvergency ret = EConvergency.Yes;

            switch (data)
            {
                case "Yes":
                    ret = EConvergency.Yes;
                    break;
                case "No_SR":
                    ret = EConvergency.No_SR;
                    break;
                case "No_R":
                    ret = EConvergency.No_R;
                    break;
                case "No_S":
                    ret = EConvergency.No_S;
                    break;
            }

            return ret;
        }

        protected string ToFileRecord()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.AnalysisBeforeEncode.WebName);
            sb.Append("\n");
            sb.Append(this.AnalysisAfterEncode.WebName);
            sb.Append("\n");
            sb.Append(this.ImportEncode.WebName);
            sb.Append("\n");
            sb.Append(this.ImportSeparator);
            sb.Append("\n");
            sb.Append(this.SeqId);
            sb.Append("\n");
            sb.Append(this.Convergency.ToString());
            sb.Append("\n");
            sb.Append(this.IsNameAndParam.ToString());

            return (sb.ToString());
        }

        protected bool Parse(string fileRecord)
        {
            bool ret = false;
            string[] array;

            try
            {
                array = fileRecord.Split(new char[] { '\n' });

                switch (array[0])
                {
                    case "utf-8":
                        this.AnalysisBeforeEncode = Encoding.UTF8;
                        break;
                    default:
                        this.AnalysisBeforeEncode = Encoding.GetEncoding(array[0]);
                        break;
                }

                switch (array[1])
                {
                    case "utf-8":
                        this.AnalysisAfterEncode = Encoding.UTF8;
                        break;
                    default:
                        this.AnalysisAfterEncode = Encoding.GetEncoding(array[1]);
                        break;
                }

                switch (array[2])
                {
                    case "utf-8":
                        this.ImportEncode = Encoding.UTF8;
                        break;
                    default:
                        this.ImportEncode = Encoding.GetEncoding(array[2]);
                        break;
                }

                this.ImportSeparator = array[3];

                this.SeqId = array[4];

                switch (array[5])
                {
                    case "Yes":
                        this.Convergency = EConvergency.Yes;
                        break;
                    case "No_SR":
                        this.Convergency = EConvergency.No_SR;
                        break;
                    case "No_R":
                        this.Convergency = EConvergency.No_R;
                        break;
                    case "No_S":
                        this.Convergency = EConvergency.No_S;
                        break;
                }

                this.IsNameAndParam = bool.Parse(array[6]);

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
                            {
                                case "解析前のファイル文字コード":
                                    this.AnalysisBeforeEncode = GetEncodeing(reader.Value);
                                    break;

                                case "解析後のファイル文字コード":
                                    this.AnalysisAfterEncode = GetEncodeing(reader.Value);
                                    break;

                                case "インポートするファイルの文字コード":
                                    this.ImportEncode = GetEncodeing(reader.Value);
                                    break;

                                case "インポートで使用するセパレート文字":
                                    this.ImportSeparator = reader.Value.Replace("\"", "");
                                    break;

                                case "インポートで使用する識別子":
                                    this.SeqId = reader.Value;
                                    break;

                                case "シーケンス図の種類":
                                    this.Convergency = GetConvergency(reader.Value);
                                    break;

                                case "Param表示":
                                    this.IsNameAndParam = bool.Parse(reader.Value);
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

                writer.WriteStartElement("その他の設定");

                writer.WriteStartElement("解析前のファイル文字コード");
                writer.WriteString(this.AnalysisBeforeEncode.WebName);
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("解析後のファイル文字コード");
                writer.WriteString(this.AnalysisAfterEncode.WebName);
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("インポートするファイルの文字コード");
                writer.WriteString(this.ImportEncode.WebName);
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("インポートで使用するセパレート文字");
                writer.WriteString("\"" + this.ImportSeparator + "\"");
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("インポートで使用する識別子");
                writer.WriteString(this.SeqId);
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("シーケンス図の種類");
                writer.WriteString(this.Convergency.ToString());
                writer.WriteEndElement();				//Elementを閉じます。

                writer.WriteStartElement("Param表示");
                writer.WriteString(this.IsNameAndParam.ToString());
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
    }
}
