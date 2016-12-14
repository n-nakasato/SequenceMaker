using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SEQ_GEN.Settings;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace SEQ_GEN.Worker
{
    public class CWorkerAnalysis : CWorker
    {
        private string m_SrcFileName = "";
        private string m_DstFileName = "";
        private CSettings m_Settings;

        public CSettings Settings
        {
            get { return (this.m_Settings); }
            set { this.m_Settings = value; }
        }

        public string SrcFileName
        {
            get { return (this.m_SrcFileName); }
            set { this.m_SrcFileName = value; }
        }

        public string DstFileName
        {
            get { return (this.m_DstFileName); }
            set { this.m_DstFileName = value; }
        }

        protected override void DoWork()
        {
            StringBuilder builder = null;
            string tmpStr;
            int process = 0;

            this.DoProgressSettingsChanged(
                new CWorkerProgressSettingsChangedEventArgs(0, 0, this.m_Settings.Analysis.Count)
            );

            try
            {
                this.ReportProgress(new ProgressChangedEventArgs(process, "ファイル読み込み中！"));
                builder = this.ReadTarget(this.m_SrcFileName);

                if (this.CancelReq) { return; }

                process = 0;
                this.ReportProgress(new ProgressChangedEventArgs(process, process + "個の解析完了！"));

                // 解析処理
                foreach (CAnalysisItem now_item in this.m_Settings.Analysis.Items)
                {
                    if (this.CancelReq)
                    {
                        this.m_IsCancel = true;
                        break;
                    }

                    // 正規表現による置換
                    try
                    {
                        if (now_item.Enable)
                        {
                            tmpStr = Regex.Replace(builder.ToString(), now_item.Key, now_item.AfterReplace);
                            builder.Length = 0;
                            builder.Append(tmpStr);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    process++;
                    this.ReportProgress(new ProgressChangedEventArgs(process, process + "個の解析完了！"));
                    Application.DoEvents();
                }

                if (this.CancelReq) { return; }

                this.ReportProgress(new ProgressChangedEventArgs(process, "ファイル書き込み中！"));
                this.WriteTarget(this.m_DstFileName, builder);

                this.ReportProgress(new ProgressChangedEventArgs(process, "解析完了！"));
                Application.DoEvents();
            }
            catch (Exception e)
            {
                this.m_ErrInfo = e;
            }
            finally
            {
                this.DoWorkerStopped(new CWorkerStoppedEventArgs(this.IsCancel, this.ErrInfo));
                this.m_IsEnd = true;
            }
        }

        private StringBuilder ReadTarget(string filaName)
        {
            StreamReader reader = null;
            StringBuilder builder = new StringBuilder();

            try
            {
                reader = new StreamReader(this.m_SrcFileName, this.m_Settings.OtherSettings.AnalysisBeforeEncode);

                while (!reader.EndOfStream)
                {
                    if (this.CancelReq)
                    {
                        this.m_IsCancel = true;
                        break;
                    }

                    builder.AppendLine(reader.ReadLine());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (null != reader)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
            }

            return (builder);
        }

        private void WriteTarget(string filaName, StringBuilder builder)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(this.m_DstFileName, false, this.m_Settings.OtherSettings.AnalysisAfterEncode);

                writer.Write(builder.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (null != writer)
                {
                    writer.Close();
                    writer.Dispose();
                    writer = null;
                }
            }
        }
    }
}
