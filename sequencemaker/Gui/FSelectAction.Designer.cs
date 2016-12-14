namespace SEQ_GEN.Gui
{
    partial class FSelectAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSelectAction));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCanc = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkListAction = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCanc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkListAction, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 120);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCanc
            // 
            this.btnCanc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanc.Location = new System.Drawing.Point(189, 94);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(75, 23);
            this.btnCanc.TabIndex = 2;
            this.btnCanc.Text = "キャンセル";
            this.btnCanc.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(3, 94);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // chkListAction
            // 
            this.chkListAction.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkListAction, 2);
            this.chkListAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListAction.FormattingEnabled = true;
            this.chkListAction.Items.AddRange(new object[] {
            "解析",
            "インポート",
            "シーケンス図作成"});
            this.chkListAction.Location = new System.Drawing.Point(3, 3);
            this.chkListAction.Name = "chkListAction";
            this.chkListAction.Size = new System.Drawing.Size(261, 85);
            this.chkListAction.TabIndex = 3;
            this.chkListAction.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListAction_ItemCheck);
            // 
            // FSelectAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 120);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FSelectAction";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "動作の選択";
            this.Load += new System.EventHandler(this.FSelectAction_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCanc;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckedListBox chkListAction;
    }
}