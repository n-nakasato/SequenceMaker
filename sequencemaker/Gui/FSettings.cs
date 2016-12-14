using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEQ_GEN.Settings;

namespace SEQ_GEN.Gui
{
    public partial class FSettings : Form
    {
        private CSettings m_Settings = null;

        public FSettings()
        {
            InitializeComponent();
        }

        public void SetSettings(CSettings settings)
        {
            this.m_Settings = settings;
            this.uSeqSettings1.SetSeqSettings(this.m_Settings.SeqSettings);
            this.uSeqObj1.SetSeqObj(this.m_Settings.SeqObj);
            this.uSeqRecordType1.SetSeqRecordType(this.m_Settings.SeqRecordType);
            this.uColorOption1.SetColorOption(this.m_Settings.ColorOption);
            this.uSkipList1.SetSkipList(this.m_Settings.SkipList);
            this.uAnalysis1.SetAnalysis(this.m_Settings.Analysis);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.m_Settings.SeqSettings = this.uSeqSettings1.GetSeqSettings();
            this.m_Settings.SeqObj = this.uSeqObj1.GetSeqObj();
            this.m_Settings.SeqRecordType = this.uSeqRecordType1.GetSeqRecordType();
            this.m_Settings.ColorOption = this.uColorOption1.GetColorOption();
            this.m_Settings.SkipList = this.uSkipList1.GetSkipList();
            this.m_Settings.Analysis = this.uAnalysis1.GetAnalysis();
        }
    }
}
