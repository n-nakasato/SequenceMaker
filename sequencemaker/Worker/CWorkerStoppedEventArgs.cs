using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEQ_GEN.Worker
{
    public class CWorkerStoppedEventArgs : EventArgs
    {
        public bool IsCancel = false;
        public Exception ErrInfo = null;

        public CWorkerStoppedEventArgs(bool cancel, Exception info)
        {
            this.IsCancel = cancel;
            this.ErrInfo = info;
        }
    }
}
