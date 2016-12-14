namespace SEQ_GEN.Gui
{
    partial class USeqObj
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colSeqObj_Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSeqObj_Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqObj_LineStyle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSeqObj_LineWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeqObj_FontColor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colSeqObj_FillColor = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeqObj_Enable,
            this.colSeqObj_Key,
            this.colSeqObj_LineStyle,
            this.colSeqObj_LineWidth,
            this.colSeqObj_FontColor,
            this.colSeqObj_FillColor});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 4);
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(504, 351);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(513, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(513, 32);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDown, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnRemove, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(562, 386);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(513, 61);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(90, 360);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "インポート";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExport.Location = new System.Drawing.Point(339, 360);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "エクスポート";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(513, 90);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(45, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "削除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // colSeqObj_Enable
            // 
            this.colSeqObj_Enable.DataPropertyName = "Enable";
            this.colSeqObj_Enable.HeaderText = "有効/無効";
            this.colSeqObj_Enable.Name = "colSeqObj_Enable";
            this.colSeqObj_Enable.Width = 65;
            // 
            // colSeqObj_Key
            // 
            this.colSeqObj_Key.DataPropertyName = "Key";
            this.colSeqObj_Key.HeaderText = "検索キー";
            this.colSeqObj_Key.Name = "colSeqObj_Key";
            this.colSeqObj_Key.Width = 78;
            // 
            // colSeqObj_LineStyle
            // 
            this.colSeqObj_LineStyle.DataPropertyName = "LineStyle";
            this.colSeqObj_LineStyle.HeaderText = "線のスタイル";
            this.colSeqObj_LineStyle.Items.AddRange(new object[] {
            "実線",
            "点線(丸)",
            "点線(角)",
            "一点鎖線",
            "二点鎖線",
            "長破線",
            "長一点鎖線"});
            this.colSeqObj_LineStyle.Name = "colSeqObj_LineStyle";
            this.colSeqObj_LineStyle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSeqObj_LineStyle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSeqObj_LineStyle.Width = 72;
            // 
            // colSeqObj_LineWidth
            // 
            this.colSeqObj_LineWidth.DataPropertyName = "LineWeight";
            this.colSeqObj_LineWidth.HeaderText = "線の太さ";
            this.colSeqObj_LineWidth.Name = "colSeqObj_LineWidth";
            this.colSeqObj_LineWidth.Width = 61;
            // 
            // colSeqObj_FontColor
            // 
            this.colSeqObj_FontColor.DataPropertyName = "FontColor";
            this.colSeqObj_FontColor.HeaderText = "文字色";
            this.colSeqObj_FontColor.Name = "colSeqObj_FontColor";
            this.colSeqObj_FontColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSeqObj_FontColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSeqObj_FontColor.Width = 61;
            // 
            // colSeqObj_FillColor
            // 
            this.colSeqObj_FillColor.DataPropertyName = "FillColor";
            this.colSeqObj_FillColor.HeaderText = "塗りつぶし色";
            this.colSeqObj_FillColor.Name = "colSeqObj_FillColor";
            this.colSeqObj_FillColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSeqObj_FillColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSeqObj_FillColor.Width = 72;
            // 
            // USeqObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "USeqObj";
            this.Size = new System.Drawing.Size(562, 386);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeqObj_Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqObj_Key;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSeqObj_LineStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqObj_LineWidth;
        private System.Windows.Forms.DataGridViewButtonColumn colSeqObj_FontColor;
        private System.Windows.Forms.DataGridViewButtonColumn colSeqObj_FillColor;
    }
}
