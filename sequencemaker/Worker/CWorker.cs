using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace SEQ_GEN.Worker
{
    public abstract class CWorker
    {
        public event EventHandler<CWorkerStoppedEventArgs> WorkerStopped = null;
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged = null;
        public event EventHandler<CWorkerProgressSettingsChangedEventArgs> ProgressSettingsChanged = null;

        protected Thread m_Worker = null;
        protected bool m_IsCancel = false;
        protected bool m_CancelReq = false;
        protected bool m_IsEnd = false;
        protected object m_SyncLock = new object();
        protected Exception m_ErrInfo = null;

        /// <summary>
        /// WorkerStoppedのラッパー
        /// </summary>
        /// <param name="e"></param>
        protected void DoWorkerStopped(CWorkerStoppedEventArgs e)
        {
            if (null != this.WorkerStopped)
            {
                this.WorkerStopped(this, e);
            }
        }

        /// <summary>
        /// ProgressSettingsChangedのラッパー
        /// </summary>
        /// <param name="e"></param>
        protected void DoProgressSettingsChanged(CWorkerProgressSettingsChangedEventArgs e)
        {
            if (null != this.ProgressSettingsChanged)
            {
                this.ProgressSettingsChanged(this, e);
            }
        }

        /// <summary>
        /// ProgressChangedのラッパー
        /// </summary>
        /// <param name="e"></param>
        protected void ReportProgress(ProgressChangedEventArgs e)
        {
            if (null != this.ProgressChanged)
            {
                this.ProgressChanged(this, e);
            }
        }

        /// <summary>
        /// スレッドを開始する
        /// </summary>
        public void Start()
        {
            this.m_Worker = new Thread(new ThreadStart(this.DoWork));
            this.m_Worker.Start();
        }

        /// <summary>
        /// スレッドを停止する
        /// </summary>
        public void Cancel()
        {
            this.CancelReq = true;

            while (!this.IsEnd)
            {
                Application.DoEvents();
            }

            this.m_Worker.Join();
        }

        /// <summary>
        /// エラー情報
        /// </summary>
        public Exception ErrInfo
        {
            get { return this.m_ErrInfo; }
        }

        /// <summary>
        /// キャンセル状態
        /// </summary>
        public bool IsCancel
        {
            get { return this.m_IsCancel; }
        }

        /// <summary>
        /// 処理終了状態
        /// </summary>
        public bool IsEnd
        {
            get { return this.m_IsEnd; }
        }

        /// <summary>
        /// キャンセルフラグ
        /// </summary>
        protected bool CancelReq
        {
            get
            {
                return this.m_CancelReq;
            }
            set
            {
                this.m_CancelReq = value;
            }
        }

        /// <summary>
        /// ワーカー本体
        /// </summary>
        protected abstract void DoWork();
    }
}
