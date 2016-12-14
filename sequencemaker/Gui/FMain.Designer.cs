namespace SEQ_GEN.Gui
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.インポートIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.シーケンス図作成MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.クリアCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ツールTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCmbAnalysisBeforeEncode = new System.Windows.Forms.ToolStripComboBox();
            this.toolCmbAnalysisAfterEncode = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCmbImportEncode = new System.Windows.Forms.ToolStripComboBox();
            this.toolCmbSeparator = new System.Windows.Forms.ToolStripComboBox();
            this.toolTextSeqId = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCmbSeqType = new System.Windows.Forms.ToolStripComboBox();
            this.toolMenuItemParamDIsp = new System.Windows.Forms.ToolStripMenuItem();
            this.表示DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列の自動調整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプファイルHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolProgressStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolCmd = new System.Windows.Forms.ToolStrip();
            this.toolBtnAnalysis = new System.Windows.Forms.ToolStripButton();
            this.toolBtnImport = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSeqMake = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnSettings = new System.Windows.Forms.ToolStripButton();
            this.uSeqRecordViewer1 = new SEQ_GEN.Gui.USeqRecordViewer();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.ツールTToolStripMenuItem,
            this.表示DToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了XToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 終了XToolStripMenuItem
            // 
            this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
            this.終了XToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.終了XToolStripMenuItem.Text = "終了(&X)";
            this.終了XToolStripMenuItem.Click += new System.EventHandler(this.終了XToolStripMenuItem_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.解析AToolStripMenuItem,
            this.インポートIToolStripMenuItem,
            this.シーケンス図作成MToolStripMenuItem,
            this.toolStripSeparator1,
            this.クリアCToolStripMenuItem});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.編集EToolStripMenuItem.Text = "編集(&E)";
            // 
            // 解析AToolStripMenuItem
            // 
            this.解析AToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("解析AToolStripMenuItem.Image")));
            this.解析AToolStripMenuItem.Name = "解析AToolStripMenuItem";
            this.解析AToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.解析AToolStripMenuItem.Text = "解析(&A)";
            this.解析AToolStripMenuItem.Click += new System.EventHandler(this.解析AToolStripMenuItem_Click);
            // 
            // インポートIToolStripMenuItem
            // 
            this.インポートIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("インポートIToolStripMenuItem.Image")));
            this.インポートIToolStripMenuItem.Name = "インポートIToolStripMenuItem";
            this.インポートIToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.インポートIToolStripMenuItem.Text = "インポート(&I)";
            this.インポートIToolStripMenuItem.Click += new System.EventHandler(this.インポートIToolStripMenuItem_Click);
            // 
            // シーケンス図作成MToolStripMenuItem
            // 
            this.シーケンス図作成MToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("シーケンス図作成MToolStripMenuItem.Image")));
            this.シーケンス図作成MToolStripMenuItem.Name = "シーケンス図作成MToolStripMenuItem";
            this.シーケンス図作成MToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.シーケンス図作成MToolStripMenuItem.Text = "シーケンス図作成(&M)";
            this.シーケンス図作成MToolStripMenuItem.Click += new System.EventHandler(this.シーケンス図作成MToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // クリアCToolStripMenuItem
            // 
            this.クリアCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("クリアCToolStripMenuItem.Image")));
            this.クリアCToolStripMenuItem.Name = "クリアCToolStripMenuItem";
            this.クリアCToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.クリアCToolStripMenuItem.Text = "クリア(&C)";
            this.クリアCToolStripMenuItem.Click += new System.EventHandler(this.クリアCToolStripMenuItem_Click);
            // 
            // ツールTToolStripMenuItem
            // 
            this.ツールTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定SToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolCmbAnalysisBeforeEncode,
            this.toolCmbAnalysisAfterEncode,
            this.toolStripSeparator3,
            this.toolCmbImportEncode,
            this.toolCmbSeparator,
            this.toolTextSeqId,
            this.toolStripSeparator4,
            this.toolCmbSeqType,
            this.toolMenuItemParamDIsp});
            this.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem";
            this.ツールTToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ツールTToolStripMenuItem.Text = "ツール(&T)";
            this.ツールTToolStripMenuItem.ToolTipText = "解析後のファイル文字コード";
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("設定SToolStripMenuItem.Image")));
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.設定SToolStripMenuItem.Text = "設定(&S)";
            this.設定SToolStripMenuItem.Click += new System.EventHandler(this.設定SToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // toolCmbAnalysisBeforeEncode
            // 
            this.toolCmbAnalysisBeforeEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCmbAnalysisBeforeEncode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolCmbAnalysisBeforeEncode.Items.AddRange(new object[] {
            "UTF-8",
            "shift-jis"});
            this.toolCmbAnalysisBeforeEncode.Name = "toolCmbAnalysisBeforeEncode";
            this.toolCmbAnalysisBeforeEncode.Size = new System.Drawing.Size(121, 20);
            this.toolCmbAnalysisBeforeEncode.ToolTipText = "解析前のファイル文字コード";
            this.toolCmbAnalysisBeforeEncode.SelectedIndexChanged += new System.EventHandler(this.toolCmbAnalysisBeforeEncode_SelectedIndexChanged);
            // 
            // toolCmbAnalysisAfterEncode
            // 
            this.toolCmbAnalysisAfterEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCmbAnalysisAfterEncode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolCmbAnalysisAfterEncode.Items.AddRange(new object[] {
            "UTF-8",
            "shift-jis"});
            this.toolCmbAnalysisAfterEncode.Name = "toolCmbAnalysisAfterEncode";
            this.toolCmbAnalysisAfterEncode.Size = new System.Drawing.Size(121, 20);
            this.toolCmbAnalysisAfterEncode.ToolTipText = "解析後のファイル文字コード";
            this.toolCmbAnalysisAfterEncode.SelectedIndexChanged += new System.EventHandler(this.toolCmbAnalysisAfterEncode_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // toolCmbImportEncode
            // 
            this.toolCmbImportEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCmbImportEncode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolCmbImportEncode.Items.AddRange(new object[] {
            "UTF-8",
            "shift-jis"});
            this.toolCmbImportEncode.Name = "toolCmbImportEncode";
            this.toolCmbImportEncode.Size = new System.Drawing.Size(121, 20);
            this.toolCmbImportEncode.ToolTipText = "インポートするファイルの文字コード";
            this.toolCmbImportEncode.SelectedIndexChanged += new System.EventHandler(this.toolCmbImportEncode_SelectedIndexChanged);
            // 
            // toolCmbSeparator
            // 
            this.toolCmbSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCmbSeparator.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolCmbSeparator.Items.AddRange(new object[] {
            "半角カンマ(\',\')",
            "TAB(\'\\t\')"});
            this.toolCmbSeparator.Name = "toolCmbSeparator";
            this.toolCmbSeparator.Size = new System.Drawing.Size(121, 20);
            this.toolCmbSeparator.ToolTipText = "インポートで使用するセパレート文字";
            this.toolCmbSeparator.SelectedIndexChanged += new System.EventHandler(this.toolCmbSeparator_SelectedIndexChanged);
            // 
            // toolTextSeqId
            // 
            this.toolTextSeqId.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolTextSeqId.Name = "toolTextSeqId";
            this.toolTextSeqId.Size = new System.Drawing.Size(100, 19);
            this.toolTextSeqId.ToolTipText = "インポートで使用する識別子";
            this.toolTextSeqId.TextChanged += new System.EventHandler(this.toolTextSeqId_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // toolCmbSeqType
            // 
            this.toolCmbSeqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolCmbSeqType.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolCmbSeqType.Items.AddRange(new object[] {
            "厳密な送受信",
            "送受信",
            "受信のみ",
            "送信のみ"});
            this.toolCmbSeqType.Name = "toolCmbSeqType";
            this.toolCmbSeqType.Size = new System.Drawing.Size(121, 20);
            this.toolCmbSeqType.ToolTipText = "シーケンス図の種類";
            this.toolCmbSeqType.SelectedIndexChanged += new System.EventHandler(this.toolCmbSeqType_SelectedIndexChanged);
            // 
            // toolMenuItemParamDIsp
            // 
            this.toolMenuItemParamDIsp.CheckOnClick = true;
            this.toolMenuItemParamDIsp.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolMenuItemParamDIsp.Name = "toolMenuItemParamDIsp";
            this.toolMenuItemParamDIsp.Size = new System.Drawing.Size(181, 22);
            this.toolMenuItemParamDIsp.Text = "Param表示";
            this.toolMenuItemParamDIsp.CheckedChanged += new System.EventHandler(this.toolMenuItemParamDIsp_CheckedChanged);
            // 
            // 表示DToolStripMenuItem
            // 
            this.表示DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.列の自動調整ToolStripMenuItem});
            this.表示DToolStripMenuItem.Name = "表示DToolStripMenuItem";
            this.表示DToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.表示DToolStripMenuItem.Text = "表示(&D)";
            // 
            // 列の自動調整ToolStripMenuItem
            // 
            this.列の自動調整ToolStripMenuItem.Checked = true;
            this.列の自動調整ToolStripMenuItem.CheckOnClick = true;
            this.列の自動調整ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.列の自動調整ToolStripMenuItem.Name = "列の自動調整ToolStripMenuItem";
            this.列の自動調整ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.列の自動調整ToolStripMenuItem.Text = "列の自動調整(&C)";
            this.列の自動調整ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.列の自動調整ToolStripMenuItem_CheckedChanged);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ヘルプファイルHToolStripMenuItem,
            this.バージョン情報VToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // ヘルプファイルHToolStripMenuItem
            // 
            this.ヘルプファイルHToolStripMenuItem.Name = "ヘルプファイルHToolStripMenuItem";
            this.ヘルプファイルHToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ヘルプファイルHToolStripMenuItem.Text = "ヘルプファイル(H)";
            this.ヘルプファイルHToolStripMenuItem.Click += new System.EventHandler(this.ヘルプファイルHToolStripMenuItem_Click);
            // 
            // バージョン情報VToolStripMenuItem
            // 
            this.バージョン情報VToolStripMenuItem.Name = "バージョン情報VToolStripMenuItem";
            this.バージョン情報VToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.バージョン情報VToolStripMenuItem.Text = "バージョン情報(&V)";
            this.バージョン情報VToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報VToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProgress,
            this.toolProgressStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(814, 23);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolProgress
            // 
            this.toolProgress.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolProgress.Name = "toolProgress";
            this.toolProgress.Size = new System.Drawing.Size(100, 17);
            // 
            // toolProgressStatus
            // 
            this.toolProgressStatus.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolProgressStatus.Name = "toolProgressStatus";
            this.toolProgressStatus.Size = new System.Drawing.Size(41, 18);
            this.toolProgressStatus.Text = "待機中";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "ファイルを選択してください。";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ファイルを選択してください。";
            // 
            // toolCmd
            // 
            this.toolCmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnAnalysis,
            this.toolBtnImport,
            this.toolBtnSeqMake,
            this.toolStripSeparator5,
            this.toolBtnClear,
            this.toolStripSeparator6,
            this.toolBtnSettings});
            this.toolCmd.Location = new System.Drawing.Point(0, 24);
            this.toolCmd.Name = "toolCmd";
            this.toolCmd.Size = new System.Drawing.Size(814, 51);
            this.toolCmd.Stretch = true;
            this.toolCmd.TabIndex = 6;
            this.toolCmd.Text = "toolCmd";
            // 
            // toolBtnAnalysis
            // 
            this.toolBtnAnalysis.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolBtnAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnAnalysis.Image")));
            this.toolBtnAnalysis.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAnalysis.Name = "toolBtnAnalysis";
            this.toolBtnAnalysis.Size = new System.Drawing.Size(36, 48);
            this.toolBtnAnalysis.Text = "解析";
            this.toolBtnAnalysis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolBtnAnalysis.Click += new System.EventHandler(this.toolBtnAnalysis_Click);
            // 
            // toolBtnImport
            // 
            this.toolBtnImport.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnImport.Image")));
            this.toolBtnImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnImport.Name = "toolBtnImport";
            this.toolBtnImport.Size = new System.Drawing.Size(69, 48);
            this.toolBtnImport.Text = "インポート";
            this.toolBtnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolBtnImport.Click += new System.EventHandler(this.toolBtnImport_Click);
            // 
            // toolBtnSeqMake
            // 
            this.toolBtnSeqMake.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSeqMake.Image")));
            this.toolBtnSeqMake.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnSeqMake.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSeqMake.Name = "toolBtnSeqMake";
            this.toolBtnSeqMake.Size = new System.Drawing.Size(105, 48);
            this.toolBtnSeqMake.Text = "シーケンス図作成";
            this.toolBtnSeqMake.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolBtnSeqMake.Click += new System.EventHandler(this.toolBtnSeqMake_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 51);
            // 
            // toolBtnClear
            // 
            this.toolBtnClear.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnClear.Image")));
            this.toolBtnClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnClear.Name = "toolBtnClear";
            this.toolBtnClear.Size = new System.Drawing.Size(45, 48);
            this.toolBtnClear.Text = "クリア";
            this.toolBtnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolBtnClear.Click += new System.EventHandler(this.toolBtnClear_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 51);
            // 
            // toolBtnSettings
            // 
            this.toolBtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSettings.Image")));
            this.toolBtnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSettings.Name = "toolBtnSettings";
            this.toolBtnSettings.Size = new System.Drawing.Size(36, 48);
            this.toolBtnSettings.Text = "設定";
            this.toolBtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolBtnSettings.Click += new System.EventHandler(this.toolBtnSettings_Click);
            // 
            // uSeqRecordViewer1
            // 
            this.uSeqRecordViewer1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.uSeqRecordViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uSeqRecordViewer1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uSeqRecordViewer1.Location = new System.Drawing.Point(0, 75);
            this.uSeqRecordViewer1.Name = "uSeqRecordViewer1";
            this.uSeqRecordViewer1.Size = new System.Drawing.Size(814, 351);
            this.uSeqRecordViewer1.TabIndex = 7;
            // 
            // FMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 449);
            this.Controls.Add(this.uSeqRecordViewer1);
            this.Controls.Add(this.toolCmd);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "シーケンスめ～か～";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FMain_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolCmd.ResumeLayout(false);
            this.toolCmd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解析AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem インポートIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem シーケンス図作成MToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem クリアCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ツールTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolCmbAnalysisBeforeEncode;
        private System.Windows.Forms.ToolStripComboBox toolCmbAnalysisAfterEncode;
        private System.Windows.Forms.ToolStripMenuItem 表示DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列の自動調整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox toolCmbImportEncode;
        private System.Windows.Forms.ToolStripComboBox toolCmbSeparator;
        private System.Windows.Forms.ToolStripTextBox toolTextSeqId;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox toolCmbSeqType;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItemParamDIsp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolProgressStatus;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolCmd;
        private System.Windows.Forms.ToolStripButton toolBtnAnalysis;
        private System.Windows.Forms.ToolStripButton toolBtnImport;
        private System.Windows.Forms.ToolStripButton toolBtnSeqMake;
        private System.Windows.Forms.ToolStripButton toolBtnClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolBtnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private USeqRecordViewer uSeqRecordViewer1;
        private System.Windows.Forms.ToolStripMenuItem ヘルプファイルHToolStripMenuItem;

    }
}