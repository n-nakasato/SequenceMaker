using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.StyleSheet
{
    public class CBorder
    {
        private Border m_Border = new Border();

        public CBorder()
        {
            this.m_Border.LeftBorder = new LeftBorder();
            this.m_Border.RightBorder = new RightBorder();
            this.m_Border.TopBorder = new TopBorder();
            this.m_Border.BottomBorder = new BottomBorder();
            this.m_Border.DiagonalBorder = new DiagonalBorder();
        }

        public Border Border
        {
            get { return this.m_Border; }
        }

        public BorderStyleValues Left
        {
            get { return (this.m_Border.LeftBorder.Style); }
            set { this.m_Border.LeftBorder.Style = value; }
        }

        public BorderStyleValues Right
        {
            get { return (this.m_Border.RightBorder.Style); }
            set { this.m_Border.RightBorder.Style = value; }
        }

        public BorderStyleValues Top
        {
            get { return (this.m_Border.TopBorder.Style); }
            set { this.m_Border.TopBorder.Style = value; }
        }

        public BorderStyleValues Bottom
        {
            get { return (this.m_Border.BottomBorder.Style); }
            set { this.m_Border.BottomBorder.Style = value; }
        }

        public BorderStyleValues Diagonal
        {
            get { return (this.m_Border.DiagonalBorder.Style); }
            set { this.m_Border.DiagonalBorder.Style = value; }
        }
    }
}
