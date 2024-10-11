using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6.Builder
{
    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        void AddSection(string sectionName, string sectionContent);
        void SetStyle(ReportStyle report);
        Report GetReport();
    }
}
