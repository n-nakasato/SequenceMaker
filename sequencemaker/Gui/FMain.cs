using SEQ_GEN.Settings;
using SEQ_GEN.Worker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEQ_GEN.Gui
{
    public partial class FMain : Form
    {
        private CSettings m_Settings;

        public FMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// レコードに新しい設定を反映する
        /// </summary>
        /// <param name="items"></param>
        /// <param name="settings"></param>
        private void ReSettings(CSeqRecord[] items, CSettings settings)
        {
            int cnt = 0;

            this.toolProgress.Maximum = items.Length;
            this.toolProgress.Minimum = 0;
            this.toolProgress.Value = cnt;

            this.toolProgressStatus.Text = "設定中";

            foreach (CSeqRecord now_record in items)
            {
                now_record.SeqRecordTypeItem = (CSeqRecordTypeItem)settings.SeqRecordType.Serch(now_record.TypeName);
                now_record.DstSeqObjItem = (CSeqObjItem)settings.SeqObj.Serch(now_record.DstName);
                now_record.SrcSeqObjItem = (CSeqObjItem)settings.SeqObj.Serch(now_record.SrcName);
                now_record.ColorOptionItem = (CColorOptionItem)settings.ColorOption.Serch(now_record.DispName);

                cnt++;
                this.toolProgress.Value = cnt;
            }

            this.toolProgressStatus.Text = "待機中";
        }

        /// <summary>
        /// DataGridViewを再ペイントする
        /// </summary>
        private void RePaint()
        {
            int max;
            int cnt;
            max = this.uSeqRecordViewer1.RowCount;

            this.toolProgress.Maximum = max;
            this.toolProgress.Minimum = 0;
            this.toolProgress.Value = 0;

            this.toolProgressStatus.Text = "カラー設定中";

            try
            {
                cnt = 0;
                while (cnt < max)
                {
                    this.uSeqRecordViewer1.PaintColor(cnt);

                    cnt++;
                    this.toolProgress.Value = cnt;

                    Application.DoEvents();
                }
            }
            finally
            {
                this.toolProgressStatus.Text = "待機中";
            }
        }

        /// <summary>
        /// 設定処理
        /// </summary>
        private void Settings()
        {
            FSettings dialog = new FSettings();
            DialogResult ret;
            CSeqRecord[] array;

            dialog.SetSettings(this.m_Settings);

            ret = dialog.ShowDialog();
            if (DialogResult.OK == ret)
            {
                this.m_Settings.Save();

                if (0 < this.uSeqRecordViewer1.RowCount)
                {
                    array = this.uSeqRecordViewer1.Items;

                    this.uSeqRecordViewer1.Clear();

                    this.ReSettings(array, this.m_Settings);

                    this.uSeqRecordViewer1.Visible = false;

                    this.uSeqRecordViewer1.SetItems(array);

                    this.uSeqRecordViewer1.Visible = true;
                }
            }
        }

        /// <summary>
        /// インポート
        /// </summary>
        /// <param name="fileName"></param>
        private void Import(string fileName)
        {
            CSeqRecord[] array;
            FProcessing processing;
            CWorkerImport worker;

            this.Visible = false;

            worker = new CWorkerImport();
            worker.FileName = fileName;
            worker.Settings = this.m_Settings;

            processing = new FProcessing();
            processing.Text = Path.GetFileName(fileName) + "をインポート中";
            processing.Woker = worker;
            processing.ShowDialog();
            processing.Dispose();

            array = worker.SeqReocrd;

            this.Visible = true;

            if (null != worker.ErrInfo)
            {
                MessageBox.Show(worker.ErrInfo.Message);
                return;
            }

            if (null == array)
            {
                return;
            }

            if (0 < array.Length)
            {
                this.ReSettings(array, this.m_Settings);

                this.uSeqRecordViewer1.Visible = false;

                this.uSeqRecordViewer1.SetItems(array);

                this.uSeqRecordViewer1.Visible = true;
            }
        }

        /// <summary>
        /// シーケンス図作成処理
        /// </summary>
        private void SeqMake(string fileName)
        {
            FProcessing processing;
            CWorkerSeqMakeOpenXml worker;
            CSeqRecord[] array;

            if (0 == this.uSeqRecordViewer1.RowCount)
            {
                MessageBox.Show("シーケンス情報がひとつもありません！インポートしてください！");
                return;
            }

            array = this.uSeqRecordViewer1.Items;

            this.Visible = false;

            worker = new CWorkerSeqMakeOpenXml();
            worker.FileName = fileName;
            worker.SeqReocrd = array;
            worker.Settings = this.m_Settings;

            processing = new FProcessing();
            processing.Text = "シーケンス図作成中";
            processing.Woker = worker;
            processing.ShowDialog();
            processing.Dispose();

            if (null != worker.ErrInfo)
            {
                MessageBox.Show(worker.ErrInfo.Message);
            }
            else
            {
                try
                {
                    Process.Start(fileName);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            this.Visible = true;
        }

        /// <summary>
        /// 解析処理
        /// </summary>
        private void Analysis(string srcFileName, string dstFileName)
        {
            FProcessing processing;
            CWorkerAnalysis worker;

            this.Visible = false;

            worker = new CWorkerAnalysis();
            worker.SrcFileName = srcFileName;
            worker.DstFileName = dstFileName;
            worker.Settings = this.m_Settings;

            processing = new FProcessing();
            processing.Text = "解析中";
            processing.Woker = worker;
            processing.ShowDialog();
            processing.Dispose();

            this.Visible = true;

            if (null != worker.ErrInfo)
            {
                MessageBox.Show(worker.ErrInfo.Message);
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FMain_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.m_Settings = new CSettings();
            this.m_Settings.Load();

            this.uSeqRecordViewer1.Clear();

            if (Encoding.UTF8 == this.m_Settings.OtherSettings.AnalysisBeforeEncode)
            {
                this.toolCmbAnalysisBeforeEncode.SelectedIndex = 0;
            }
            else
            {
                this.toolCmbAnalysisBeforeEncode.SelectedIndex = 1;
            }

            if (Encoding.UTF8 == this.m_Settings.OtherSettings.AnalysisAfterEncode)
            {
                this.toolCmbAnalysisAfterEncode.SelectedIndex = 0;
            }
            else
            {
                this.toolCmbAnalysisAfterEncode.SelectedIndex = 1;
            }

            if (Encoding.UTF8 == this.m_Settings.OtherSettings.ImportEncode)
            {
                this.toolCmbImportEncode.SelectedIndex = 0;
            }
            else
            {
                this.toolCmbImportEncode.SelectedIndex = 1;
            }

            if ("," == this.m_Settings.OtherSettings.ImportSeparator)
            {
                this.toolCmbSeparator.SelectedIndex = 0;
            }
            else
            {
                this.toolCmbSeparator.SelectedIndex = 1;
            }

            this.toolTextSeqId.Text = this.m_Settings.OtherSettings.SeqId;

            switch (this.m_Settings.OtherSettings.Convergency)
            {
                case COtherSettings.EConvergency.Yes:
                    this.toolCmbSeqType.SelectedIndex = 0;
                    break;
                case COtherSettings.EConvergency.No_SR:
                    this.toolCmbSeqType.SelectedIndex = 1;
                    break;
                case COtherSettings.EConvergency.No_R:
                    this.toolCmbSeqType.SelectedIndex = 2;
                    break;
                case COtherSettings.EConvergency.No_S:
                    this.toolCmbSeqType.SelectedIndex = 3;
                    break;
                default:
                    break;
            }

            if (this.m_Settings.OtherSettings.IsNameAndParam)
            {
                this.toolMenuItemParamDIsp.Checked = true;
            }
            else
            {
                this.toolMenuItemParamDIsp.Checked = false;
            }
        }

        /// <summary>
        /// 終了メニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.uSeqRecordViewer1.Clear();

            Application.Exit();
        }

        /// <summary>
        /// 解析メニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 解析AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret;

            ret = this.openFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.saveFileDialog1.Filter = "すべてのファイル|*.*";
            ret = this.saveFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.Analysis(this.openFileDialog1.FileName, this.saveFileDialog1.FileName);
        }

        /// <summary>
        /// インポートメニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void インポートIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret;

            ret = this.openFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.Import(this.openFileDialog1.FileName);
        }

        /// <summary>
        /// シーケンス図作成メニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void シーケンス図作成MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret;

            this.saveFileDialog1.Filter = "エクセル|*.xlsx";
            ret = this.saveFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.SeqMake(this.saveFileDialog1.FileName);
        }

        /// <summary>
        /// クリアメニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void クリアCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.uSeqRecordViewer1.Clear();
        }

        /// <summary>
        /// 設定メニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 設定SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Settings();
        }

        /// <summary>
        /// 解析前のファイルの文字コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolCmbAnalysisBeforeEncode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cmb = (ToolStripComboBox)sender;
            switch (cmb.SelectedIndex)
            {
                case 0:
                    this.m_Settings.OtherSettings.AnalysisBeforeEncode = Encoding.UTF8;
                    break;
                case 1:
                    this.m_Settings.OtherSettings.AnalysisBeforeEncode = Encoding.GetEncoding(cmb.Text);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 解析後のファイルの文字コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolCmbAnalysisAfterEncode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cmb = (ToolStripComboBox)sender;
            switch (cmb.SelectedIndex)
            {
                case 0:
                    this.m_Settings.OtherSettings.AnalysisAfterEncode = Encoding.UTF8;
                    break;
                case 1:
                    this.m_Settings.OtherSettings.AnalysisAfterEncode = Encoding.GetEncoding(cmb.Text);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// インポートするファイルの文字コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolCmbImportEncode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cmb = (ToolStripComboBox)sender;
            switch (cmb.SelectedIndex)
            {
                case 0:
                    this.m_Settings.OtherSettings.ImportEncode = Encoding.UTF8;
                    break;
                case 1:
                    this.m_Settings.OtherSettings.ImportEncode = Encoding.GetEncoding(cmb.Text);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// インポートで使用するセパレート文字の値変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolCmbSeparator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cmb = (ToolStripComboBox)sender;
            switch (cmb.SelectedIndex)
            {
                case 0:
                    this.m_Settings.OtherSettings.ImportSeparator = ",";
                    break;
                case 1:
                    this.m_Settings.OtherSettings.ImportSeparator = "\t";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 識別子の文字列が変わった時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolTextSeqId_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox text = (ToolStripTextBox)sender;
            this.m_Settings.OtherSettings.SeqId = text.Text;
        }

        /// <summary>
        /// シーケンス図の種別コンボボックスの値変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolCmbSeqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cmb = (ToolStripComboBox)sender;
            switch(cmb.SelectedIndex)
            {
                case 0:
                    this.m_Settings.OtherSettings.Convergency = COtherSettings.EConvergency.Yes;
                    break;
                case 1:
                    this.m_Settings.OtherSettings.Convergency = COtherSettings.EConvergency.No_SR;
                    break;
                case 2:
                    this.m_Settings.OtherSettings.Convergency = COtherSettings.EConvergency.No_R;
                    break;
                case 3:
                    this.m_Settings.OtherSettings.Convergency = COtherSettings.EConvergency.No_S;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Param表示の値変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuItemParamDIsp_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Checked)
            {
                this.m_Settings.OtherSettings.IsNameAndParam = true;
            }
            else
            {
                this.m_Settings.OtherSettings.IsNameAndParam = false;
            }
        }

        /// <summary>
        /// 列の自動調整の値変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 列の自動調整ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Checked)
            {
                this.uSeqRecordViewer1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                this.uSeqRecordViewer1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        /// <summary>
        /// ヘルプファイルメニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ヘルプファイルHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"Readme.html");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// バージョンメニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void バージョン情報VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FVersion dialog = new FVersion();

            dialog.ShowDialog();
        }

        /// <summary>
        /// ドラッグでマウスポインタがフォームに入った時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ドラッグ中のファイルやディレクトリの取得
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string d in drags)
                {
                    if (!System.IO.File.Exists(d))
                    {
                        // ファイル以外であればイベント・ハンドラを抜ける
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// ドロップされた時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FMain_DragDrop(object sender, DragEventArgs e)
        {
            // ドラッグ＆ドロップされたファイル
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string seqPath;
            string anaPath;
            string dir;

            FSelectAction dialog = new FSelectAction();

            if (DialogResult.OK != dialog.ShowDialog())
            {
                return;
            }

            foreach (string now_file in files)
            {
                dir = Path.GetDirectoryName(now_file);

                anaPath = now_file;
                seqPath = string.Format(@"{0}\{1}.xlsx", dir, Path.GetFileNameWithoutExtension(now_file));

                if (dialog.IsAnalysis)
                {
                    anaPath = string.Format(@"{0}\{1}_Analysis.txt", dir, Path.GetFileNameWithoutExtension(anaPath));
                    seqPath = string.Format(@"{0}\{1}.xlsx", dir, Path.GetFileNameWithoutExtension(anaPath));

                    this.Analysis(now_file, anaPath);
                }

                if (dialog.IsImport)
                {
                    this.Import(anaPath);
                }

                if (dialog.IsSeqMake)
                {
                    this.SeqMake(seqPath);
                }
            }
        }

        /// <summary>
        /// 解析メニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnAnalysis_Click(object sender, EventArgs e)
        {
            DialogResult ret;

            ret = this.openFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.saveFileDialog1.Filter = "すべてのファイル|*.*";
            ret = this.saveFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.Analysis(this.openFileDialog1.FileName, this.saveFileDialog1.FileName);
        }

        /// <summary>
        /// インポートメニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnImport_Click(object sender, EventArgs e)
        {
            DialogResult ret;

            ret = this.openFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.Import(this.openFileDialog1.FileName);
        }

        /// <summary>
        /// シーケンス図作成メニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnSeqMake_Click(object sender, EventArgs e)
        {
            DialogResult ret;

            this.saveFileDialog1.Filter = "エクセル|*.xlsx";
            ret = this.saveFileDialog1.ShowDialog();
            if (DialogResult.OK != ret)
            {
                return;
            }

            this.SeqMake(this.saveFileDialog1.FileName);
        }

        /// <summary>
        /// クリアメニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnClear_Click(object sender, EventArgs e)
        {
            this.uSeqRecordViewer1.Clear();
        }

        /// <summary>
        /// 設定メニュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnSettings_Click(object sender, EventArgs e)
        {
            this.Settings();
        }

        /// <summary>
        /// フォームクローズ中処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.m_Settings.OtherSettings.Save("");
        }

    }
}
