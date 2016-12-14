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
    public partial class USeqSettings : UserControl
    {
        public USeqSettings()
        {
            InitializeComponent();
        }

        public void SetSeqSettings(CSeqSettings option)
        {
            this.numStartColumn.Value = decimal.Parse(option.StartColumn.ToString());
            this.numStartRow.Value = decimal.Parse(option.StartRow.ToString());
            this.numColumnWidth.Value = decimal.Parse(option.ColumnWidth.ToString());
            this.numRowWidth.Value = decimal.Parse(option.RowWidth.ToString());
            this.numSeqRecordSpace.Value = decimal.Parse(option.SeqRecordSpace.ToString());
            this.numSeqObjSpace.Value = decimal.Parse(option.SeqObjSpace.ToString());
            this.numSeqObjInfoWidth.Value = decimal.Parse(option.SeqObjInfo.Width.ToString());
            this.numSeqObjInfoHeight.Value = decimal.Parse(option.SeqObjInfo.Height.ToString());
            this.numPrcInfoWidth.Value = decimal.Parse(option.PrcInfo.Width.ToString());
            this.numPrcInfoHeight.Value = decimal.Parse(option.PrcInfo.Height.ToString());
            this.numMtxInfoWidth.Value = decimal.Parse(option.MtxInfo.Width.ToString());
            this.numMtxInfoHeight.Value = decimal.Parse(option.MtxInfo.Height.ToString());
        }

        public CSeqSettings GetSeqSettings()
        {
            CSeqSettings ret = new CSeqSettings();

            ret.StartColumn = uint.Parse(this.numStartColumn.Value.ToString());
            ret.StartRow = uint.Parse(this.numStartRow.Value.ToString());
            ret.ColumnWidth = uint.Parse(this.numColumnWidth.Value.ToString());
            ret.RowWidth = uint.Parse(this.numRowWidth.Value.ToString());
            ret.SeqRecordSpace = uint.Parse(this.numSeqRecordSpace.Value.ToString());
            ret.SeqObjSpace = uint.Parse(this.numSeqObjSpace.Value.ToString());
            ret.SeqObjInfo.Width = uint.Parse(this.numSeqObjInfoWidth.Value.ToString());
            ret.SeqObjInfo.Height = uint.Parse(this.numSeqObjInfoHeight.Value.ToString());
            ret.PrcInfo.Width = uint.Parse(this.numPrcInfoWidth.Value.ToString());
            ret.PrcInfo.Height = uint.Parse(this.numPrcInfoHeight.Value.ToString());
            ret.MtxInfo.Width = uint.Parse(this.numMtxInfoWidth.Value.ToString());
            ret.MtxInfo.Height = uint.Parse(this.numMtxInfoHeight.Value.ToString());

            return (ret);
        }
    }
}
