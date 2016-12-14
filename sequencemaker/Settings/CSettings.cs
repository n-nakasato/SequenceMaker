using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEQ_GEN.Settings
{
    public class CSettings
    {
        public COtherSettings OtherSettings = new COtherSettings();
        public CSeqSettings SeqSettings = new CSeqSettings();
        public CSeqObj SeqObj = new CSeqObj();
        public CSeqRecordType SeqRecordType = new CSeqRecordType();
        public CColorOption ColorOption = new CColorOption();
        public CSkipList SkipList = new CSkipList();
        public CAnalysis Analysis = new CAnalysis();

        public void Save()
        {
            this.OtherSettings.Save("");
            this.SeqSettings.Save("");
            this.SeqObj.Save("");
            this.SeqRecordType.Save("");
            this.ColorOption.Save("");
            this.SkipList.Save("");
            this.Analysis.Save("");
        }

        public void Load()
        {
            if(!this.OtherSettings.Load(""))
            {
                this.OtherSettings.Save("");
            }

            if(!this.SeqSettings.Load(""))
            {
                this.SeqSettings.Save("");
            }

            this.SeqObj.Load();
            this.SeqRecordType.Load();
            this.ColorOption.Load();
            this.SkipList.Load();
            this.Analysis.Load();
        }
    }
}
