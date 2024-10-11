using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6
{
    public class TextReportBuilder : IReportBuilder
    {
        private Report report = new Report();

        public void SetHeader(string header)
        {
            report.Header = header;
        }

        public void SetContent(string content)
        {
            report.Content = content;
        }

        public void SetFooter(string footer)
        {
            report.Footer = footer;
        }

        public Report GetReport()
        {
            return report;
        }
    }

}
