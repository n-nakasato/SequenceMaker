using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SEQ_GEN.Worker;

namespace SEQ_GEN.Gui
{
    public partial class FProcessing : Form
    {
        protected CWorker m_Woker = null;

        public FProcessing()
        {
            InitializeComponent();
        }

        public CWorker Woker
        {
            get { return (this.m_Woker); }
            set
            {
                this.m_Woker = value;
                this.m_Woker.ProgressSettingsChanged += new EventHandler<CWorkerProgressSettingsChangedEventArgs>(this.ProgressSettingsChange);
                this.m_Woker.ProgressChanged += new EventHandler<ProgressChangedEventArgs>(this.ReportProgress);
                this.m_Woker.WorkerStopped += new EventHandler<CWorkerStoppedEventArgs>(this.WorkerStopped);
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FProcessing_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) { return; }

            this.label1.Text = "";

            if (null != this.m_Woker)
            {
                this.m_Woker.Start();
            }
        }

        /// <summary>
        /// 最小値・最大値変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="min"></param>
        protected virtual void ProgressSettingsChange(object sender, CWorkerProgressSettingsChangedEventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.progressBar1.Invoke(
                    new EventHandler<CWorkerProgressSettingsChangedEventArgs>(
                        this.ProgressSettingsChange),
                        new object[]{sender,e}
                );
                return;
            }

            this.progressBar1.Value = e.Now;
            this.progressBar1.Minimum = e.Min;
            this.progressBar1.Maximum = e.Max;
        }

        /// <summary>
        /// 進捗状況更新処理
        /// </summary>
        /// <param name="e"></param>
        protected virtual void ReportProgress(object sender, ProgressChangedEventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.progressBar1.Invoke(
                    new EventHandler<ProgressChangedEventArgs>(
                        this.ReportProgress),
                        new object[] { sender, e }
                );
                return;
            }
            else if (this.label1.InvokeRequired)
            {
                this.label1.Invoke(
                    new EventHandler<ProgressChangedEventArgs>(
                        this.ReportProgress),
                        new object[] { sender, e }
                );
                return;
            }

            this.progressBar1.Value = e.ProgressPercentage;
            this.label1.Text = (string)e.UserState;
        }

        /// <summary>
        /// ワーカーストップイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void WorkerStopped(object sender, CWorkerStoppedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new EventHandler<CWorkerStoppedEventArgs>(
                        this.WorkerStopped),
                        new object[] { sender, e }
                );
                return;
            }

            if (e.IsCancel)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (null != e.ErrInfo)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnCanc_Click(object sender, EventArgs e)
        {
            this.m_Woker.Cancel();

            if (this.m_Woker.IsCancel)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (null != this.m_Woker.ErrInfo)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
