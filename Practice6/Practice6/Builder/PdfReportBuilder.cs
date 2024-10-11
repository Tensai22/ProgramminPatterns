using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Practice6.Builder
{
    public class PdfReportBuilder : IReportBuilder
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

        public void ExportToPdf(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.Add(new Paragraph(_report.title));
                doc.Add(new Paragraph(_report.description));
                foreach (var section in _report.Sections)
                {
                    doc.Add(new Paragraph($"{section.SectionName}: {section.SectionContent}"));
                }
                doc.Add(new Paragraph(_report.chapter));
                doc.Close();
            }
        }
    }
}
