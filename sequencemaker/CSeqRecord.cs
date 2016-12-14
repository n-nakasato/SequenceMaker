using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using SEQ_GEN.Settings;

namespace SEQ_GEN
{
    public class CSeqRecord : TreeNode
    {
        public enum EDerection
        {
            Unknown,
            Rcv,
            Snd
        };

        public CSeqRecord()
        {
            // 処理なし
        }

        public CSeqRecord(string fileName, long lineNum, string orgStr, CSettings settings)
        {
            string[] array;
            string str;
            int index;

            this.m_FileName = fileName;
            this.m_LineNum = lineNum;
            this.m_OrgStr = orgStr;

            // シーケンス図作成対象の識別子か？
            index = orgStr.IndexOf(settings.OtherSettings.SeqId + settings.OtherSettings.ImportSeparator);
            if (0 <= index)
            {
                str = orgStr.Substring(index);
                array = str.Split(settings.OtherSettings.ImportSeparator.ToCharArray());

                try
                {
                    this.m_TypeName = array[1];
                }
                catch (Exception e)
                {
                    // 何もしない
                    Debug.Print(e.Message);
                }

                try
                {
                    this.m_DstName = array[2];
                }
                catch (Exception e)
                {
                    // 何もしない
                    Debug.Print(e.Message);
                }

                try
                {
                    this.m_SrcName = array[3];
                }
                catch (Exception e)
                {
                    // 何もしない
                    Debug.Print(e.Message);
                }

                try
                {
                    this.m_SeqNum = long.Parse(array[4]);
                }
                catch (Exception e)
                {
                    // 何もしない
                    Debug.Print(e.Message);
                }

                try
                {
                    switch(array[5])
                    {
                        case "S":
                            this.m_Derection = EDerection.Snd;
                            break;
                        case "R":
                            this.m_Derection = EDerection.Rcv;
                            break;
                        default:
                            this.m_Derection = EDerection.Unknown;
                            break;
                    }
                }
                catch (Exception e)
                {
                    // 何もしない
                    Debug.Print(e.Message);
                }

                try
                {
                    this.m_DispName = array[6];
                    this.Text = this.m_DispName;
                }
                catch (Exception e)
                {
                    // 何もしない
                    Debug.Print(e.Message);
                }

                try
                {
                    this.m_Param = array[7];
                }
                catch (Exception e)
                {
                    // 何もしない
                    Debug.Print(e.Message);
                }
            }
        }

        private string m_OrgStr = "";
        public string OrgStr
        {
            set { this.m_OrgStr = value; }
            get { return (this.m_OrgStr); }
        }

        private string m_FileName = "";
        private long m_LineNum = 0;

        public string FileInfo
        {
            get { return (string.Format("{0}({1})", Path.GetFileName(this.m_FileName), this.m_LineNum)); }
        }

        private string m_TypeName = "";
        public string TypeName
        {
            get { return (this.m_TypeName); }
        }

        private string m_DstName = "";
        public string DstName
        {
            get { return (this.m_DstName); }
        }

        private string m_SrcName = "";
        public string SrcName
        {
            get { return (this.m_SrcName); }
        }

        private EDerection m_Derection = EDerection.Unknown;
        public EDerection Derection
        {
            get { return (this.m_Derection); }
        }

        private long m_SeqNum = 0;
        public long SeqNum
        {
            get { return (this.m_SeqNum); }
        }

        private string m_DispName = "";
        public string DispName
        {
            get { return (this.m_DispName); }
        }

        private string m_Param = "";
        public string Param
        {
            get { return (this.m_Param); }
        }

        public string NameParam
        {
            get 
            {
                string ret = this.DispName.Trim();

                if("" != this.Param)
                {
                    ret += " : " + this.Param.Trim();
                }

                return (ret); 
            }
        }

        private CSeqRecordTypeItem m_SeqRecordTypeItem = null;
        public CSeqRecordTypeItem SeqRecordTypeItem
        {
            get { return (this.m_SeqRecordTypeItem); }
            set 
            {
                this.m_SeqRecordTypeItem = value;
                this.SetMyColor();
            }
        }

        private CSeqObjItem m_DstSeqObjItem = null;
        public CSeqObjItem DstSeqObjItem
        {
            get { return (this.m_DstSeqObjItem); }
            set { this.m_DstSeqObjItem = value;  }
        }

        private CSeqObjItem m_SrcSeqObjItem = null;
        public CSeqObjItem SrcSeqObjItem
        {
            get { return (this.m_SrcSeqObjItem); }
            set { this.m_SrcSeqObjItem = value;  }
        }

        private CColorOptionItem m_ColorOptionItem = null;
        public CColorOptionItem ColorOptionItem
        {
            set 
            { 
                this.m_ColorOptionItem = value;
                this.SetMyColor();
            }
            get { return (this.m_ColorOptionItem); }
        }

        protected void SetMyColor()
        {
            if (null != this.m_SeqRecordTypeItem)
            {
                if (null != this.m_ColorOptionItem)
                {
                    this.BackColor = this.m_ColorOptionItem.BackColor;
                    this.ForeColor = this.m_ColorOptionItem.FontColor;
                }
                else
                {
                    this.BackColor = this.m_SeqRecordTypeItem.FillColor;
                    this.ForeColor = this.m_SeqRecordTypeItem.FontColor;
                }
            }
        }

        private uint m_OrgSheetRow = 0;
        public uint OrgSheetRow
        {
            set { this.m_OrgSheetRow = value; }
            get { return (this.m_OrgSheetRow); }
        }

        private CSeqDrawPos m_SeqSheetPos = null;
        public CSeqDrawPos SeqSheetPos
        {
            set { this.m_SeqSheetPos = value; }
            get { return (this.m_SeqSheetPos); }
        }

        private int m_DataGridRow;
        public int DataGridRow
        {
            get { return this.m_DataGridRow; }
            set { this.m_DataGridRow = value; }
        }

        public string[] ToExcelFormat()
        {
            List<string> lst = new List<string>();

            lst.Add(this.FileInfo);
            lst.Add(this.TypeName);
            lst.Add(this.DstName);
            lst.Add(this.SrcName);
            lst.Add(this.SeqNum.ToString());
            lst.Add(this.Derection.ToString());
            lst.Add(this.DispName);
            lst.Add(this.Param);
            //lst.Add(this.OrgStr.Replace("\t", "    "));
            lst.Add(this.OrgStr);

            return (lst.ToArray());
        }

        /// <summary>
        /// 接続先のキー文字列取得
        /// </summary>
        /// <returns></returns>
        public string ToConvergencyConnectKey()
        {
            long seqNum;
            EDerection delection;
            string name;

            seqNum = this.SeqNum;
            delection = this.Derection;
            switch (delection)
            {
                case EDerection.Snd:
                    delection = EDerection.Rcv;
                    break;

                case EDerection.Rcv:
                    delection = EDerection.Snd;
                    break;

                default:
                    break;
            }
            name = this.DispName;

            return (string.Format("{0},{1},{2}", seqNum, delection.ToString(), name));
        }

        /// <summary>
        /// コレクションに登録するための文字列取得
        /// </summary>
        /// <returns></returns>
        public string ToConvergencyRegistKey()
        {
            long seqNum;
            EDerection delection;
            string name;

            seqNum = this.SeqNum;
            delection = this.Derection;
            name = this.DispName;

            return (string.Format("{0},{1},{2}", seqNum, delection.ToString(), name));
        }
    }
}
