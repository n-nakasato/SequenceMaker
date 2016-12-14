using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace SEQ_GEN.Settings
{
    public class CSettingsList : ISettingsList
    {
        protected string m_FileName = null;
        protected Encoding m_Encode = null;
        protected Dictionary<string, ISettingsListItem> m_Items = new Dictionary<string, ISettingsListItem>();

        #region ISettingsList メンバ

        public void Add(ISettingsListItem item)
        {
            if (!this.m_Items.ContainsKey(item.Key))
            {
                this.m_Items.Add(item.Key, item);
            }
        }

        public int Count
        {
            get { return (this.m_Items.Count); }
        }

        public ICollection Items
        {
            get { return (this.m_Items.Values); }
        }

        public void Save()
        {
            StreamWriter sw = null;

            try
            {
                if (0 < this.m_Items.Count)
                {
                    sw = new StreamWriter(this.m_FileName, false, this.m_Encode);
                    foreach (ISettingsListItem item in this.m_Items.Values) 
                    {
                        sw.WriteLine(item.ToFileRecord());
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if(null != sw)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        public bool Load<T>()
            where T : ISettingsListItem, new()
        {
            bool ret = false;
            StreamReader sr = null;
            ISettingsListItem item;
            string work;

            try
            {
                sr = new StreamReader(this.m_FileName, this.m_Encode);
                while (!sr.EndOfStream)
                {
                    work = sr.ReadLine();
                    if ("" == work)
                    {
                        // 何もしない。
                    }
                    else if(0 == work.IndexOf("//"))
                    {
                        // コメント行のためなにもしない。
                    }
                    else
                    {
                        item = (ISettingsListItem)new T();
                        if (item.Parse(work))
                        {
                            this.m_Items.Add(item.Key, item);
                        }
                    }
                }

                ret = true;
            }
            catch
            {
            }
            finally
            {
                if(null != sr)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }

            return (ret);
        }

        public ISettingsListItem Serch(string key)
        {
            ISettingsListItem ret = null;
            string trimKey = key.Trim();

            if (this.m_Items.ContainsKey(trimKey))
            {
                ret = (ISettingsListItem)this.m_Items[trimKey];
            }

            return (ret);
        }

        #endregion
    }
}
