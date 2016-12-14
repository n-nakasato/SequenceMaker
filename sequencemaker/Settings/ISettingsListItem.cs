using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEQ_GEN.Settings
{
    public interface ISettingsListItem
    {
        string Key
        {
            get;
            set;
        }

        bool Enable
        {
            get;
            set;
        }

        string ToFileRecord();

        bool Parse(string fileRecord);
    }
}
