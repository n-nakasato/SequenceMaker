using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEQ_GEN.Settings
{
    public interface ISettings
    {
        void Save();

        bool Load();
    }
}
