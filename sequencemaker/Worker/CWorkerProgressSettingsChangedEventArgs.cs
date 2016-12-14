using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEQ_GEN.Worker
{
    public class CWorkerProgressSettingsChangedEventArgs : EventArgs
    {
        public int Max = 100;
        public int Min = 0;
        public int Now = 0;

        public CWorkerProgressSettingsChangedEventArgs(int nowValue, int minValue, int maxValue)
        {
            this.Max = maxValue;
            this.Min = minValue;
            this.Now = nowValue;
        }
    }
}
