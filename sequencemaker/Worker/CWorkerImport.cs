using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEQ_GEN.Settings;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace SEQ_GEN.Worker
{
    public class CWorkerImport : CWorker
    {
        private string m_FileName = "";
        private CSeqRecord[] m_SeqReocrd = null;
        private CSettings m_Settings;

        public CSettings Settings
        {
            get { return (this.m_Settings); }
            set { this.m_Settings = value; }
        }

        public string FileName
        {
            get { return (this.m_FileName); }
            set { this.m_FileName = value; }
        }

        public CSeqRecord[] SeqReocrd
        {
            get { return (this.m_SeqReocrd); }
        }

        protected override void DoWork()
        {
            StringBuilder builder = null;
            List<CSeqRecord> lst = null;
            string[] strArray = null;
            int process = 0;
            long line_num;

            try
            {
                this.ReportProgress(new ProgressChangedEventArgs(process, "ファイル読み込み中！"));
                builder = this.ReadTarget(this.m_FileName);

                if (this.CancelReq) { return; }

                process = 0;
                this.ReportProgress(new ProgressChangedEventArgs(process, process + "行のインポート完了！"));

                // 解析処理
                lst = new List<CSeqRecord>();
                strArray = builder.ToString().Split(new char[] { '\n' });

                this.DoProgressSettingsChanged(
                    new CWorkerProgressSettingsChangedEventArgs(0, 0, strArray.Length)
                );

                line_num = 0;
                process = 0;
                foreach (string now_record in strArray)
                {
                    if (this.CancelReq)
                    {
                        this.m_IsCancel = true;
                        break;
                    }

                    line_num++;
                    lst.Add(new CSeqRecord(this.m_FileName, line_num, now_record, this.m_Settings));

                    process++;
                    this.ReportProgress(new ProgressChangedEventArgs(process, process + "行のインポート完了！"));
                    Application.DoEvents();
                }

                this.m_SeqReocrd = lst.ToArray();

                if (this.CancelReq) { return; }

                this.ReportProgress(new ProgressChangedEventArgs(process, "インポート完了！"));
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
                reader = new StreamReader(this.m_FileName, this.m_Settings.OtherSettings.ImportEncode);

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
    }
}
