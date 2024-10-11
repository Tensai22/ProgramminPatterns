using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6.Builder
{
    public class HtmlReportBuilder : IReportBuilder
    {
        private Report _report = new Report();

        public void SetHeader(string title)
        {
            _report.title = $"<h1>{title}</h1>";
        }

        public void SetContent(string description)
        {
            _report.description = $"<p>{description}</p>";
        }

        public void SetFooter(string chapter)
        {
            _report.chapter = $"<footer>{chapter}</footer>";
        }

        public void AddSection(string sectionName, string sectionContent)
        {
            _report.AddSection(sectionName, $"<section><h2>{sectionName}</h2><p>{sectionContent}</p></section>");
        }

        public void SetStyle(ReportStyle style)
        {
            _report.Style = style;
        }

        public Report GetReport()
        {
            return _report;
        }
    }


}
