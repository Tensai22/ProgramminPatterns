using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6.Builder
{
    public class ReportStyle
    {
        public string backgroundColor { get; set; }
        public string fontColor { get; set; }
        public int fontSize { get; set; }

        public ReportStyle(string backgroundColor, string fontColor, int fontSize)
        {
            this.backgroundColor = backgroundColor;
            this.fontColor = fontColor;
            this.fontSize = fontSize;
        }

    }
}
