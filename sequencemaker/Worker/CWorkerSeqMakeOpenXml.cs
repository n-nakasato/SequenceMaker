using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEQ_GEN.Settings;
using System.ComponentModel;
using System.Windows.Forms;

namespace SEQ_GEN.Worker
{
    public class CWorkerSeqMakeOpenXml : CWorker
    {
        private string m_FileName = "";
        private CSeqRecord[] m_SeqReocrd = null;
        private CSeqMaker m_SeqMaker;
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
            set { this.m_SeqReocrd = value; }
        }

        protected override void DoWork()
        {
            int process = 0;

            this.DoProgressSettingsChanged(
                new CWorkerProgressSettingsChangedEventArgs(0, 0, this.m_SeqReocrd.Length)
            );

            try
            {
                this.ReportProgress(new ProgressChangedEventArgs(process, "ブックオープン中！"));

                this.m_SeqMaker = new CSeqMaker(this.FileName);
                this.m_SeqMaker.Settings = this.m_Settings;
                this.m_SeqMaker.Open();

                foreach (CSeqRecord now_record in this.m_SeqReocrd)
                {
                    if (this.CancelReq)
                    {
                        this.m_IsCancel = true;
                        break;
                    }

                    this.m_SeqMaker.AddRow(now_record);

                    process++;
                    this.ReportProgress(new ProgressChangedEventArgs(process, process + "行の作成完了！"));
                    Application.DoEvents();
                }

                Application.DoEvents();
            }
            catch (Exception e)
            {
                this.m_ErrInfo = e;
            }
            finally
            {
                if (null != this.m_SeqMaker)
                {
                    this.m_SeqMaker.Close();
                    this.m_SeqMaker = null;
                }

                this.DoWorkerStopped(new CWorkerStoppedEventArgs(this.IsCancel, this.ErrInfo));
                this.m_IsEnd = true;
            }
        }
    }
}
