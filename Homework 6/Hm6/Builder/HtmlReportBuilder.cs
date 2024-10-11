using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6
{
    public class HtmlReportBuilder : IReportBuilder
    {
        private Report report = new Report();

        public void SetHeader(string header)
        {
            report.Header = $"<h1>{header}</h1>";
        }

        public void SetContent(string content)
        {
            report.Content = $"<p>{content}</p>";
        }

        public void SetFooter(string footer)
        {
            report.Footer = $"<footer>{footer}</footer>";
        }

        public Report GetReport()
        {
            return report;
        }
    }

}
