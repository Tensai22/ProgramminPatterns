using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6.Builder
{
    public class TextReportBuilder : IReportBuilder
    {
        private Report _report = new Report();

        public void SetHeader(string header)
        {
            _report.title = header;
        }

        public void SetContent(string description)
        {
            _report.description = description;
        }

        public void SetFooter(string chapter)
        {
            _report.chapter = chapter;
        }

        public void AddSection(string sectionName, string sectionContent)
        {
            _report.AddSection(sectionName, sectionContent);
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
