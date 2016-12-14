namespace SEQ_GEN.Gui
{
    partial class FSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCanc = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uSeqSettings1 = new SEQ_GEN.Gui.USeqSettings();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uSeqRecordType1 = new SEQ_GEN.Gui.USeqRecordType();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uSeqObj1 = new SEQ_GEN.Gui.USeqObj();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uColorOption1 = new SEQ_GEN.Gui.UColorOption();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.uSkipList1 = new SEQ_GEN.Gui.USkipList();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.uAnalysis1 = new SEQ_GEN.Gui.UAnalysis();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCanc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 422);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCanc
            // 
            this.btnCanc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanc.Location = new System.Drawing.Point(606, 396);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(75, 23);
            this.btnCanc.TabIndex = 1;
            this.btnCanc.Text = "キャンセル";
            this.btnCanc.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(3, 396);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl, 2);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(678, 387);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uSeqSettings1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(670, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本設定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uSeqSettings1
            // 
            this.uSeqSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uSeqSettings1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uSeqSettings1.Location = new System.Drawing.Point(3, 3);
            this.uSeqSettings1.Name = "uSeqSettings1";
            this.uSeqSettings1.Size = new System.Drawing.Size(664, 355);
            this.uSeqSettings1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uSeqRecordType1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(670, 361);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "シーケンス種別";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uSeqRecordType1
            // 
            this.uSeqRecordType1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uSeqRecordType1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uSeqRecordType1.Location = new System.Drawing.Point(3, 3);
            this.uSeqRecordType1.Name = "uSeqRecordType1";
            this.uSeqRecordType1.Size = new System.Drawing.Size(664, 355);
            this.uSeqRecordType1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uSeqObj1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(670, 361);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "オブジェクトリスト";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uSeqObj1
            // 
            this.uSeqObj1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uSeqObj1.Location = new System.Drawing.Point(3, 3);
            this.uSeqObj1.Name = "uSeqObj1";
            this.uSeqObj1.Size = new System.Drawing.Size(664, 355);
            this.uSeqObj1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.uColorOption1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(670, 361);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "色オプション";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // uColorOption1
            // 
            this.uColorOption1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uColorOption1.Location = new System.Drawing.Point(3, 3);
            this.uColorOption1.Name = "uColorOption1";
            this.uColorOption1.Size = new System.Drawing.Size(664, 355);
            this.uColorOption1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.uSkipList1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(670, 361);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "除外リスト";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // uSkipList1
            // 
            this.uSkipList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uSkipList1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uSkipList1.Location = new System.Drawing.Point(0, 0);
            this.uSkipList1.Name = "uSkipList1";
            this.uSkipList1.Size = new System.Drawing.Size(670, 361);
            this.uSkipList1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.uAnalysis1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(670, 361);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "解析定義";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // uAnalysis1
            // 
            this.uAnalysis1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uAnalysis1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uAnalysis1.Location = new System.Drawing.Point(3, 3);
            this.uAnalysis1.Name = "uAnalysis1";
            this.uAnalysis1.Size = new System.Drawing.Size(664, 355);
            this.uAnalysis1.TabIndex = 0;
            // 
            // FSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 422);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCanc;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private USeqSettings uSeqSettings1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private USeqObj uSeqObj1;
        private System.Windows.Forms.TabPage tabPage2;
        private USeqRecordType uSeqRecordType1;
        private UColorOption uColorOption1;
        private USkipList uSkipList1;
        private System.Windows.Forms.TabPage tabPage6;
        private UAnalysis uAnalysis1;
    }
}