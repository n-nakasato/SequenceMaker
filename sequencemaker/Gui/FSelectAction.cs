using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEQ_GEN.Gui
{
    public partial class FSelectAction : Form
    {
        public bool IsAnalysis = false;
        public bool IsImport = false;
        public bool IsSeqMake = false;

        public FSelectAction()
        {
            InitializeComponent();
        }

        private void FSelectAction_Load(object sender, EventArgs e)
        {
            this.chkListAction.SetItemChecked(1, true);
        }

        private void chkListAction_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch(e.Index)
            {
                case 0:
                    if (CheckState.Checked == e.NewValue)
                    {
                        this.IsAnalysis = true;
                    }
                    else
                    {
                        this.IsAnalysis = false;
                    }
                    break;
                
                case 1:
                    if (CheckState.Checked == e.NewValue)
                    {
                        this.IsImport = true;
                    }
                    else
                    {
                        this.IsImport = false;
                    }
                    break;

                case 2:
                    if (CheckState.Checked == e.NewValue)
                    {
                        this.IsSeqMake = true;
                    }
                    else
                    {
                        this.IsSeqMake = false;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
