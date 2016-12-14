using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SEQ_GEN.Settings
{
    public interface ISettingsList
    {
        void Add(ISettingsListItem item);
        
        int Count
        {
            get;    
        }

        ICollection Items
        {
            get;
        }

        void Save();

        bool Load<T>() where T : ISettingsListItem, new();

        ISettingsListItem Serch(string key);
    }
}
