using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SEQ_GEN.Settings
{
    abstract public class CSettingsListItem : ISettingsListItem
    {
        protected string m_Key = "hogehoge";
        protected bool m_Enable = true;

        protected Color GetColor(string argb)
        {
            string[] array;
            int r;
            int g;
            int b;

            array = argb.Split(new char[] { ',' });
            r = int.Parse(array[0]);
            g = int.Parse(array[1]);
            b = int.Parse(array[2]);

            return (Color.FromArgb(r, g, b));
        }

        #region ISettingsListItem メンバ

        public string Key
        {
            set { this.m_Key = value.Trim(); }
            get { return (this.m_Key); }
        }

        public bool Enable
        {
            set { this.m_Enable = value; }
            get { return (this.m_Enable); }
        }

        abstract public string ToFileRecord();

        abstract public bool Parse(string fileRecord);

        #endregion
    }
}
