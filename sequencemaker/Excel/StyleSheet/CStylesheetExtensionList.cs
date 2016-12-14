using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;
using X15 = DocumentFormat.OpenXml.Office2013.Excel;
using A = DocumentFormat.OpenXml.Drawing;

namespace Excel.StyleSheet
{
    public class CStylesheetExtensionList
    {
        protected StylesheetExtensionList m_StylesheetExtensionList = null;

        protected uint m_ItemNum = 0;
        protected Dictionary<string, uint> m_Items = null;

        public StylesheetExtensionList StylesheetExtensionList
        {
            get { return this.m_StylesheetExtensionList; }
        }

        public CStylesheetExtensionList()
        {
            this.m_StylesheetExtensionList = new StylesheetExtensionList();
            this.m_Items = new Dictionary<string, uint>();

            this.AddSlicerStyles("x14", "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main", "SlicerStyleLight1");
            this.AddSlicerStyles("x15", "{9260A510-F301-46a8-8635-F512D64BE5F5}", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main", "TimeSlicerStyleLight1");
        }

        public uint AddSlicerStyles(string name, string uri, string url, string style)
        {
            string contents = "";

            contents = string.Format("{0},{1},{2},{3}", name, uri, url, style);

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            StylesheetExtension stylesheetExtension = new StylesheetExtension() { Uri = uri };
            stylesheetExtension.AddNamespaceDeclaration(name, url);
            X14.SlicerStyles slicerStyles = new X14.SlicerStyles() { DefaultSlicerStyle = style };

            stylesheetExtension.Append(slicerStyles);

            this.m_StylesheetExtensionList.Append(stylesheetExtension);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }

        public uint AddTimelineStyles(string name, string uri, string url, string style)
        {
            string contents = "";

            contents = string.Format("{0},{1},{2},{3}", name, uri, url, style);

            // 既に登録されているか？
            if (this.m_Items.ContainsKey(contents))
            {
                // 既に登録されていればその番号を返す。
                return this.m_Items[contents];
            }

            StylesheetExtension stylesheetExtension = new StylesheetExtension() { Uri = uri };
            stylesheetExtension.AddNamespaceDeclaration(name, url);
            X15.TimelineStyles timelineStyles = new X15.TimelineStyles() { DefaultTimelineStyle = style };

            stylesheetExtension.Append(timelineStyles);

            this.m_StylesheetExtensionList.Append(stylesheetExtension);

            this.m_Items.Add(contents, this.m_ItemNum);
            this.m_ItemNum++;

            return this.m_Items[contents];

        }
    }
}
