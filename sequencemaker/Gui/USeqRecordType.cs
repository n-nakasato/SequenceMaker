using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEQ_GEN.Settings;

namespace SEQ_GEN.Gui
{
    public partial class USeqRecordType : UserControl
    {
        public USeqRecordType()
        {
            InitializeComponent();
        }

        public void SetSeqRecordType(CSeqRecordType option)
        {
            if (0 < option.Count)
            {
                foreach (CSeqRecordTypeItem item in option.Items)
                {
                    this.bindingSource1.Add(item);

                }
            }
        }

        public CSeqRecordType GetSeqRecordType()
        {
            CSeqRecordType ret = new CSeqRecordType();
            int max;
            int cnt;

            max = this.bindingSource1.Count;
            for (cnt = 0; cnt < max; cnt++)
            {
                ret.Add((CSeqRecordTypeItem)this.bindingSource1[cnt]);
            }

            return (ret);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CSeqRecordTypeItem item = new CSeqRecordTypeItem();

            this.bindingSource1.Add(item);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index;

            if (0 < this.dataGridView1.Rows.Count)
            {
                index = this.dataGridView1.CurrentCell.RowIndex;
                if (0 <= index)
                {
                    this.bindingSource1.RemoveAt(index);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int rowIndex;
            int columnIndex;
            object tmp;

            if (0 < this.dataGridView1.Rows.Count)
            {
                rowIndex = this.dataGridView1.CurrentCell.RowIndex;
                if (0 < rowIndex)
                {
                    tmp = this.bindingSource1[rowIndex];
                    this.bindingSource1[rowIndex] = this.bindingSource1[rowIndex - 1];
                    this.bindingSource1[rowIndex - 1] = tmp;

                    this.PaintColor(rowIndex);
                    this.PaintColor(rowIndex - 1);

                    columnIndex = this.dataGridView1.CurrentCell.ColumnIndex;
                    this.dataGridView1.CurrentCell = this.dataGridView1[columnIndex, rowIndex - 1];
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int rowIndex;
            int columnIndex;
            object tmp;

            if (0 < this.dataGridView1.Rows.Count)
            {
                rowIndex = this.dataGridView1.CurrentCell.RowIndex;
                if (this.dataGridView1.Rows.Count > (rowIndex + 1))
                {
                    tmp = this.bindingSource1[rowIndex];
                    this.bindingSource1[rowIndex] = this.bindingSource1[rowIndex + 1];
                    this.bindingSource1[rowIndex + 1] = tmp;

                    this.PaintColor(rowIndex);
                    this.PaintColor(rowIndex + 1);

                    columnIndex = this.dataGridView1.CurrentCell.ColumnIndex;
                    this.dataGridView1.CurrentCell = this.dataGridView1[columnIndex, rowIndex + 1];
                }
            }
        }


        private void PaintColor(int rowIndex)
        {
            this.dataGridView1["colSeqRecordType_Key", rowIndex].Style.BackColor = (Color)this.dataGridView1["colSeqRecordType_FillColor", rowIndex].Value;
            this.dataGridView1["colSeqRecordType_Key", rowIndex].Style.ForeColor = (Color)this.dataGridView1["colSeqRecordType_FontColor", rowIndex].Value;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int max;

            max = dgv.Rows.Count;

            for (int cnt = 0; cnt < max; cnt++)
            {
                this.PaintColor(cnt);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DialogResult ret = DialogResult.None;

            if (0 > e.RowIndex)
            {
                return;
            }

            switch(dgv.Columns[e.ColumnIndex].Name)
            {
                case "colSeqRecordType_LineColor":
                    ret = this.colorDialog1.ShowDialog();
                    if (DialogResult.OK == ret)
                    {
                        dgv["colSeqRecordType_LineColor", e.RowIndex].Value = this.colorDialog1.Color;

                        this.PaintColor(e.RowIndex);
                    }
                    else
                    {
                        // 処理なし
                    }
                    break;

                case "colSeqRecordType_FillColor":
                    ret = this.colorDialog1.ShowDialog();
                    if (DialogResult.OK == ret)
                    {
                        dgv["colSeqRecordType_FillColor", e.RowIndex].Value = this.colorDialog1.Color;

                        this.PaintColor(e.RowIndex);
                    }
                    else
                    {
                        // 処理なし
                    }
                    break;

                case "colSeqRecordType_FontColor":
                    ret = this.colorDialog1.ShowDialog();
                    if (DialogResult.OK == ret)
                    {
                        dgv["colSeqRecordType_FontColor", e.RowIndex].Value = this.colorDialog1.Color;

                        this.PaintColor(e.RowIndex);
                    }
                    else
                    {
                        // 処理なし
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
