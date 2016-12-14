using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEQ_GEN.Settings;

namespace SEQ_GEN.Gui
{
    public partial class USeqRecordViewer : UserControl
    {
        private TreeNode m_CurrentNode = null;
        private Dictionary<string, List<CSeqRecord>> m_SerchData = new Dictionary<string, List<CSeqRecord>>();
        private int m_SerchIndex = 0;
        private CSeqRecord[] m_SerchItems = null;

        public USeqRecordViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コントロール内のデータをクリアする
        /// </summary>
        public void Clear()
        {
            this.m_SerchData.Clear();
            if (null != this.m_SerchItems)
            {
                this.m_SerchItems = null;
            }
            this.m_SerchIndex = 0;

            this.textHit.Text = "Hit：0/0";
            this.btnAfter.Enabled = false;
            this.btnBefore.Enabled = false;

            this.bindingSource1.Clear();

            foreach (TreeNode now in this.treeView1.Nodes)
            {
                this.ClearTreeNode(now);
            }

            this.treeView1.Nodes.Clear();

            this.cmbSerchKey.Items.Clear();

            this.ChangeActiveRecord(null);

            GC.Collect();
        }

        /// <summary>
        /// ツリーノードのリンクを再帰的にクリアする
        /// </summary>
        /// <param name="now"></param>
        private void ClearTreeNode(TreeNode now)
        {
            foreach (TreeNode child in now.Nodes)
            {
                this.ClearTreeNode(child);
            }

            now.Nodes.Clear();
        }

        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get { return this.dataGridView1.AutoSizeColumnsMode; }
            set { this.dataGridView1.AutoSizeColumnsMode = value; }
        }

        /// <summary>
        /// コントロールにアイテムを設定する
        /// </summary>
        /// <param name="items"></param>
        public void SetItems(CSeqRecord[] items)
        {
            this.m_CurrentNode = new TreeNode("解析開始位置");
            this.m_CurrentNode.BackColor = Color.Black;
            this.m_CurrentNode.ForeColor = Color.White;
            this.treeView1.Nodes.Add(this.m_CurrentNode);

            foreach (CSeqRecord now_record in items)
            {
                ////////////////////////////////////////////
                // データグリッドビューに登録
                ////////////////////////////////////////////
                this.bindingSource1.Add(now_record);
                now_record.DataGridRow = this.bindingSource1.Count - 1;

                ////////////////////////////////////////////
                // ツリービューに登録
                ////////////////////////////////////////////
                if (null == now_record.SeqRecordTypeItem)
                {
                    // 何もしない
                }
                else if (!now_record.SeqRecordTypeItem.Enable)
                {
                    // 何もしない
                }
                else
                {
                    switch (now_record.SeqRecordTypeItem.SeqRecordType)
                    {
                        case CSeqRecordTypeItem.ESeqRecordType.Matrix:
                            this.m_CurrentNode = now_record;
                            this.treeView1.Nodes.Add(this.m_CurrentNode);
                            this.AddSerchData(now_record);
                            break;

                        case CSeqRecordTypeItem.ESeqRecordType.Message:
                        case CSeqRecordTypeItem.ESeqRecordType.Function:
                            this.m_CurrentNode.Nodes.Add(now_record);
                            this.AddSerchData(now_record);
                            break;
                        case CSeqRecordTypeItem.ESeqRecordType.Process:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 検索用オブジェクトに登録する
        /// </summary>
        /// <param name="record"></param>
        private void AddSerchData(CSeqRecord record)
        {
            ////////////////////////////////////////////
            // 検索用のオブジェクトに設定
            ////////////////////////////////////////////
            string tmp = record.DispName.Trim();
            if (!this.m_SerchData.ContainsKey(tmp))
            {
                this.m_SerchData.Add(tmp, new List<CSeqRecord>());
                this.cmbSerchKey.Items.Add(tmp);
            }
            this.m_SerchData[tmp].Add(record);
        }

        /// <summary>
        /// コントロール内のデータを取得する
        /// </summary>
        public CSeqRecord[] Items
        {
            get
            {
                CSeqRecord[] array;
                array = new CSeqRecord[this.dataGridView1.RowCount];
                this.bindingSource1.CopyTo(array, 0);
                return array;
            }
        }

        /// <summary>
        /// 行数を返す
        /// </summary>
        public int RowCount
        {
            get { return this.dataGridView1.RowCount; }
        }

        /// <summary>
        /// DataGridViewをペイントする(1レコード単位)
        /// </summary>
        /// <param name="rowIndex"></param>
        public void PaintColor(int rowIndex)
        {
            CSeqRecord record;

            record = (CSeqRecord)this.bindingSource1[rowIndex];

            if (null != record.SeqRecordTypeItem)
            {
                if (record.SeqRecordTypeItem.Enable)
                {
                    this.dataGridView1["colSeqRecord_Type", rowIndex].Style.ForeColor = record.SeqRecordTypeItem.FontColor;
                    this.dataGridView1["colSeqRecord_Type", rowIndex].Style.BackColor = record.SeqRecordTypeItem.FillColor;
                }
                else
                {
                    this.dataGridView1["colSeqRecord_Type", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_Type", rowIndex].Style.BackColor = Color.White;
                }
            }
            else
            {
                this.dataGridView1["colSeqRecord_Type", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_Type", rowIndex].Style.BackColor = Color.White;
            }

            if (null != record.DstSeqObjItem)
            {
                if (record.DstSeqObjItem.Enable)
                {
                    this.dataGridView1["colSeqRecord_Dst", rowIndex].Style.ForeColor = record.DstSeqObjItem.FontColor;
                    this.dataGridView1["colSeqRecord_Dst", rowIndex].Style.BackColor = record.DstSeqObjItem.FillColor;
                }
                else
                {
                    this.dataGridView1["colSeqRecord_Dst", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_Dst", rowIndex].Style.BackColor = Color.White;
                }
            }
            else
            {
                this.dataGridView1["colSeqRecord_Dst", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_Dst", rowIndex].Style.BackColor = Color.White;
            }

            if (null != record.SrcSeqObjItem)
            {
                if (record.SrcSeqObjItem.Enable)
                {
                    this.dataGridView1["colSeqRecord_Src", rowIndex].Style.ForeColor = record.SrcSeqObjItem.FontColor;
                    this.dataGridView1["colSeqRecord_Src", rowIndex].Style.BackColor = record.SrcSeqObjItem.FillColor;
                }
                else
                {
                    this.dataGridView1["colSeqRecord_Src", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_Src", rowIndex].Style.BackColor = Color.White;
                }
            }
            else
            {
                this.dataGridView1["colSeqRecord_Src", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_Src", rowIndex].Style.BackColor = Color.White;
            }

            if (null != record.ColorOptionItem)
            {
                if (record.ColorOptionItem.Enable)
                {
                    this.dataGridView1["colSeqRecord_FileInfo", rowIndex].Style.ForeColor = record.ColorOptionItem.FontColor;
                    this.dataGridView1["colSeqRecord_FileInfo", rowIndex].Style.BackColor = record.ColorOptionItem.BackColor;
                    this.dataGridView1["colSeqRecord_SeqNum", rowIndex].Style.ForeColor = record.ColorOptionItem.FontColor;
                    this.dataGridView1["colSeqRecord_SeqNum", rowIndex].Style.BackColor = record.ColorOptionItem.BackColor;
                    this.dataGridView1["colSeqRecord_Derection", rowIndex].Style.ForeColor = record.ColorOptionItem.FontColor;
                    this.dataGridView1["colSeqRecord_Derection", rowIndex].Style.BackColor = record.ColorOptionItem.BackColor;
                    this.dataGridView1["colSeqRecord_Name", rowIndex].Style.ForeColor = record.ColorOptionItem.FontColor;
                    this.dataGridView1["colSeqRecord_Name", rowIndex].Style.BackColor = record.ColorOptionItem.BackColor;
                    this.dataGridView1["colSeqRecord_Param", rowIndex].Style.ForeColor = record.ColorOptionItem.FontColor;
                    this.dataGridView1["colSeqRecord_Param", rowIndex].Style.BackColor = record.ColorOptionItem.BackColor;
                    this.dataGridView1["colSeqRecord_OrgStr", rowIndex].Style.ForeColor = record.ColorOptionItem.FontColor;
                    this.dataGridView1["colSeqRecord_OrgStr", rowIndex].Style.BackColor = record.ColorOptionItem.BackColor;
                }
                else
                {
                    this.dataGridView1["colSeqRecord_FileInfo", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_FileInfo", rowIndex].Style.BackColor = Color.White;
                    this.dataGridView1["colSeqRecord_SeqNum", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_SeqNum", rowIndex].Style.BackColor = Color.White;
                    this.dataGridView1["colSeqRecord_Derection", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_Derection", rowIndex].Style.BackColor = Color.White;
                    this.dataGridView1["colSeqRecord_Name", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_Name", rowIndex].Style.BackColor = Color.White;
                    this.dataGridView1["colSeqRecord_Param", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_Param", rowIndex].Style.BackColor = Color.White;
                    this.dataGridView1["colSeqRecord_OrgStr", rowIndex].Style.ForeColor = Color.Black;
                    this.dataGridView1["colSeqRecord_OrgStr", rowIndex].Style.BackColor = Color.White;
                }
            }
            else
            {
                this.dataGridView1["colSeqRecord_FileInfo", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_FileInfo", rowIndex].Style.BackColor = Color.White;
                this.dataGridView1["colSeqRecord_SeqNum", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_SeqNum", rowIndex].Style.BackColor = Color.White;
                this.dataGridView1["colSeqRecord_Derection", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_Derection", rowIndex].Style.BackColor = Color.White;
                this.dataGridView1["colSeqRecord_Name", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_Name", rowIndex].Style.BackColor = Color.White;
                this.dataGridView1["colSeqRecord_Param", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_Param", rowIndex].Style.BackColor = Color.White;
                this.dataGridView1["colSeqRecord_OrgStr", rowIndex].Style.ForeColor = Color.Black;
                this.dataGridView1["colSeqRecord_OrgStr", rowIndex].Style.BackColor = Color.White;
            }
        }

        /// <summary>
        /// DataGridViewへの行追加イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = e.RowIndex;

            for (int loop = e.RowCount; 0 < loop; loop--)
            {
                this.PaintColor(index);
                index++;

                Application.DoEvents();
            }
        }

        /// <summary>
        /// ツリービューの選択アイテムが変わった時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CSeqRecord node = null;
            int column;
            int row;
            try
            {
                node = (CSeqRecord)e.Node;
                column = this.dataGridView1.CurrentCell.ColumnIndex;
                row = node.DataGridRow;
                this.dataGridView1.CurrentCell = this.dataGridView1[column, row];
            }
            catch
            {
                // なにもしない
            }
        }

        /// <summary>
        /// アクティブレコードの変更処理
        /// </summary>
        /// <param name="record"></param>
        private void ChangeActiveRecord(CSeqRecord record)
        {
            if (null != record)
            {
                this.textFileInfo.Text = record.FileInfo;
                this.textOrgData.Text = record.OrgStr;
                if(null != record.ColorOptionItem)
                {
                    this.textOrgData.ForeColor = record.ColorOptionItem.FontColor;
                    this.textOrgData.BackColor = record.ColorOptionItem.BackColor;
                }
                else
                {
                    this.textOrgData.ForeColor = Color.Black;
                    this.textOrgData.BackColor = Color.White;
                }

                if(this.treeView1.SelectedNode != record)
                {
                    this.treeView1.SelectedNode = record;
                }
            }
            else
            {
                this.textFileInfo.Text = "未選択";
                this.textOrgData.Text = "";
                this.textOrgData.ForeColor = Color.Black;
                this.textOrgData.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 検索文字に変更があった時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSerchKey_TextUpdate(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            if (this.m_SerchData.ContainsKey(cmb.Text.Trim()))
            {
                this.m_SerchIndex = 0;

                this.m_SerchItems = this.m_SerchData[cmb.Text.Trim()].ToArray();
                this.SerchValueChange();

                if (0 > cmb.Items.IndexOf(cmb.Text))
                {
                    cmb.Items.Add(cmb.Text);
                }

                this.btnAfter.Enabled = true;
                this.btnBefore.Enabled = true;
            }
            else
            {
                this.m_SerchIndex = 0;
                this.m_SerchItems = null;
                this.textHit.Text = "Hit：0/0";

                this.btnAfter.Enabled = false;
                this.btnBefore.Enabled = false;
            }
        }

        /// <summary>
        /// 次へボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAfter_Click(object sender, EventArgs e)
        {
            if (null == this.m_SerchItems)
            {
                // 何もしない
            }
            else if ((this.m_SerchItems.Length - 1) == this.m_SerchIndex)
            {
                // 何もしない
            }
            else
            {
                this.m_SerchIndex++;
                this.SerchValueChange();
            }
        }

        /// <summary>
        /// 前へボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBefore_Click(object sender, EventArgs e)
        {
            if (null == this.m_SerchItems)
            {
                // 何もしない
            }
            else if (0 == this.m_SerchIndex)
            {
                // 何もしない
            }
            else
            {
                this.m_SerchIndex--;
                this.SerchValueChange();
            }
        }

        /// <summary>
        /// 検索文字列変更イベント処理
        /// </summary>
        private void SerchValueChange()
        {
            int row;
            int column;

            row = this.m_SerchItems[this.m_SerchIndex].DataGridRow;
            column = this.dataGridView1.CurrentCell.ColumnIndex;

            this.dataGridView1.CurrentCell = this.dataGridView1[column, row];
            this.ChangeActiveRecord(this.m_SerchItems[this.m_SerchIndex]);
            this.treeView1.SelectedNode = this.m_SerchItems[this.m_SerchIndex];
            this.treeView1.SelectedNode.Expand();

            this.textHit.Text = string.Format("Hit：{0}/{1}", this.m_SerchIndex + 1, this.m_SerchItems.Length);
        }

        /// <summary>
        /// キーイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control)
            {
                if(e.KeyCode == Keys.F)
                {
                    if(null != this.treeView1.SelectedNode)
                    {
                        this.cmbSerchKey.Text = this.treeView1.SelectedNode.Text;
                        this.cmbSerchKey_TextUpdate(this.cmbSerchKey, null);
                    }
                }
            }
        }

        /// <summary>
        /// 行が変更する直前のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CSeqRecord record;
            int index;

            index = e.RowIndex;
            if (0 <= index)
            {
                record = (CSeqRecord)this.bindingSource1[index];
            }
            else
            {
                record = null;
            }

            this.ChangeActiveRecord(record);
        }

        /// <summary>
        /// 検索コンボボックスが変更されたイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSerchKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            if (this.m_SerchData.ContainsKey(cmb.Text.Trim()))
            {
                this.m_SerchIndex = 0;

                this.m_SerchItems = this.m_SerchData[cmb.Text.Trim()].ToArray();
                this.SerchValueChange();

                if (0 > cmb.Items.IndexOf(cmb.Text))
                {
                    cmb.Items.Add(cmb.Text);
                }

                this.btnAfter.Enabled = true;
                this.btnBefore.Enabled = true;
            }
            else
            {
                this.m_SerchIndex = 0;
                this.m_SerchItems = null;
                this.textHit.Text = "Hit：0/0";

                this.btnAfter.Enabled = false;
                this.btnBefore.Enabled = false;
            }
        }
    }
}
