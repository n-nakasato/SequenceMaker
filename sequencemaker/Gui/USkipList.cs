﻿using System;
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
    public partial class USkipList : UserControl
    {
        public USkipList()
        {
            InitializeComponent();
        }

        public void SetSkipList(CSkipList option)
        {
            if (0 < option.Count)
            {
                foreach (CSkipListItem item in option.Items)
                {
                    this.bindingSource1.Add(item);

                }
            }
        }

        public CSkipList GetSkipList()
        {
            CSkipList ret = new CSkipList();
            int max;
            int cnt;

            max = this.bindingSource1.Count;
            for (cnt = 0; cnt < max; cnt++)
            {
                ret.Add((CSkipListItem)this.bindingSource1[cnt]);
            }

            return (ret);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CSkipListItem item = new CSkipListItem();
            int index;

            index = this.bindingSource1.Add(item);
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

                    columnIndex = this.dataGridView1.CurrentCell.ColumnIndex;
                    this.dataGridView1.CurrentCell = this.dataGridView1[columnIndex, rowIndex + 1];
                }
            }
        }
    }
}
