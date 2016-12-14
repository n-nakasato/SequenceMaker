namespace SEQ_GEN.Gui
{
    partial class USeqRecordViewer
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSeqRecord_FileInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_Dst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_Src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_SeqNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_Derection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_Param = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqRecord_OrgStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textOrgData = new System.Windows.Forms.TextBox();
            this.textFileInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSerchKey = new System.Windows.Forms.ComboBox();
            this.textHit = new System.Windows.Forms.Label();
            this.btnBefore = new System.Windows.Forms.Button();
            this.btnAfter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 58);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(629, 341);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(167, 337);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeqRecord_FileInfo,
            this.colSeqRecord_Type,
            this.colSeqRecord_Dst,
            this.colSeqRecord_Src,
            this.colSeqRecord_SeqNum,
            this.colSeqRecord_Derection,
            this.colSeqRecord_Name,
            this.colSeqRecord_Param,
            this.colSeqRecord_OrgStr});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(450, 337);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // colSeqRecord_FileInfo
            // 
            this.colSeqRecord_FileInfo.DataPropertyName = "FileInfo";
            this.colSeqRecord_FileInfo.HeaderText = "File";
            this.colSeqRecord_FileInfo.Name = "colSeqRecord_FileInfo";
            this.colSeqRecord_FileInfo.ReadOnly = true;
            this.colSeqRecord_FileInfo.Width = 54;
            // 
            // colSeqRecord_Type
            // 
            this.colSeqRecord_Type.DataPropertyName = "TypeName";
            this.colSeqRecord_Type.HeaderText = "Type";
            this.colSeqRecord_Type.Name = "colSeqRecord_Type";
            this.colSeqRecord_Type.Width = 54;
            // 
            // colSeqRecord_Dst
            // 
            this.colSeqRecord_Dst.DataPropertyName = "DstName";
            this.colSeqRecord_Dst.HeaderText = "Dst";
            this.colSeqRecord_Dst.Name = "colSeqRecord_Dst";
            this.colSeqRecord_Dst.Width = 48;
            // 
            // colSeqRecord_Src
            // 
            this.colSeqRecord_Src.DataPropertyName = "SrcName";
            this.colSeqRecord_Src.HeaderText = "Src";
            this.colSeqRecord_Src.Name = "colSeqRecord_Src";
            this.colSeqRecord_Src.Width = 48;
            // 
            // colSeqRecord_SeqNum
            // 
            this.colSeqRecord_SeqNum.DataPropertyName = "SeqNum";
            this.colSeqRecord_SeqNum.HeaderText = "SeqNum";
            this.colSeqRecord_SeqNum.Name = "colSeqRecord_SeqNum";
            this.colSeqRecord_SeqNum.Width = 66;
            // 
            // colSeqRecord_Derection
            // 
            this.colSeqRecord_Derection.DataPropertyName = "Derection";
            this.colSeqRecord_Derection.HeaderText = "Derection";
            this.colSeqRecord_Derection.Name = "colSeqRecord_Derection";
            this.colSeqRecord_Derection.Width = 84;
            // 
            // colSeqRecord_Name
            // 
            this.colSeqRecord_Name.DataPropertyName = "DispName";
            this.colSeqRecord_Name.HeaderText = "Name";
            this.colSeqRecord_Name.Name = "colSeqRecord_Name";
            this.colSeqRecord_Name.Width = 54;
            // 
            // colSeqRecord_Param
            // 
            this.colSeqRecord_Param.DataPropertyName = "Param";
            this.colSeqRecord_Param.HeaderText = "Param";
            this.colSeqRecord_Param.Name = "colSeqRecord_Param";
            this.colSeqRecord_Param.Width = 60;
            // 
            // colSeqRecord_OrgStr
            // 
            this.colSeqRecord_OrgStr.DataPropertyName = "OrgStr";
            this.colSeqRecord_OrgStr.HeaderText = "OrgStr";
            this.colSeqRecord_OrgStr.Name = "colSeqRecord_OrgStr";
            this.colSeqRecord_OrgStr.ReadOnly = true;
            this.colSeqRecord_OrgStr.Width = 66;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textOrgData, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textFileInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 430);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // textOrgData
            // 
            this.textOrgData.BackColor = System.Drawing.Color.Black;
            this.textOrgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOrgData.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textOrgData.ForeColor = System.Drawing.Color.White;
            this.textOrgData.Location = new System.Drawing.Point(64, 405);
            this.textOrgData.Name = "textOrgData";
            this.textOrgData.ReadOnly = true;
            this.textOrgData.Size = new System.Drawing.Size(568, 22);
            this.textOrgData.TabIndex = 5;
            // 
            // textFileInfo
            // 
            this.textFileInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textFileInfo.AutoSize = true;
            this.textFileInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textFileInfo.Location = new System.Drawing.Point(3, 408);
            this.textFileInfo.Name = "textFileInfo";
            this.textFileInfo.Size = new System.Drawing.Size(55, 15);
            this.textFileInfo.TabIndex = 5;
            this.textFileInfo.Text = "未選択";
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 49);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索ボックス";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbSerchKey, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textHit, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBefore, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAfter, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(623, 31);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "検索ワード(Nameのみ)：";
            // 
            // cmbSerchKey
            // 
            this.cmbSerchKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSerchKey.FormattingEnabled = true;
            this.cmbSerchKey.Location = new System.Drawing.Point(146, 5);
            this.cmbSerchKey.Name = "cmbSerchKey";
            this.cmbSerchKey.Size = new System.Drawing.Size(235, 20);
            this.cmbSerchKey.TabIndex = 0;
            this.cmbSerchKey.SelectedIndexChanged += new System.EventHandler(this.cmbSerchKey_SelectedIndexChanged);
            this.cmbSerchKey.TextUpdate += new System.EventHandler(this.cmbSerchKey_TextUpdate);
            // 
            // textHit
            // 
            this.textHit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textHit.AutoSize = true;
            this.textHit.Location = new System.Drawing.Point(387, 9);
            this.textHit.Name = "textHit";
            this.textHit.Size = new System.Drawing.Size(71, 12);
            this.textHit.TabIndex = 4;
            this.textHit.Text = "ヒット：0/0";
            // 
            // btnBefore
            // 
            this.btnBefore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBefore.Location = new System.Drawing.Point(464, 4);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(75, 23);
            this.btnBefore.TabIndex = 2;
            this.btnBefore.Text = "前へ";
            this.btnBefore.UseVisualStyleBackColor = true;
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // btnAfter
            // 
            this.btnAfter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAfter.Location = new System.Drawing.Point(545, 4);
            this.btnAfter.Name = "btnAfter";
            this.btnAfter.Size = new System.Drawing.Size(75, 23);
            this.btnAfter.TabIndex = 3;
            this.btnAfter.Text = "次へ";
            this.btnAfter.UseVisualStyleBackColor = true;
            this.btnAfter.Click += new System.EventHandler(this.btnAfter_Click);
            // 
            // USeqRecordViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "USeqRecordViewer";
            this.Size = new System.Drawing.Size(635, 430);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_FileInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_Dst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_Src;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_SeqNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_Derection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_Param;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqRecord_OrgStr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textOrgData;
        private System.Windows.Forms.Label textFileInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSerchKey;
        private System.Windows.Forms.Button btnBefore;
        private System.Windows.Forms.Button btnAfter;
        private System.Windows.Forms.Label textHit;
        private System.Windows.Forms.TreeView treeView1;
    }
}
