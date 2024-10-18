using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Practice6.Builder
{
    public class JsonReportBuilder : IReportBuilder
    {
        private Report _report = new Report();

        public void SetHeader(string title)
        {
            _report.title = title;
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

        public void ExportToJson(string filePath)
        {
            string jsonReport = JsonConvert.SerializeObject(_report, Formatting.Indented);
            File.WriteAllText(filePath, jsonReport);
        }
    }
}
