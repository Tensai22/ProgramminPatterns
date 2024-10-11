using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6.Builder
{
    public class Report
    {
        string report;
        public string title { get; set; }
        public string description { get; set; }
        public string chapter { get; set; }
        public List<(string SectionName, string SectionContent)> Sections { get; set; } = new List<(string, string)>();
        public ReportStyle Style { get; set; }
        public void AddSection(string name, string content)
        {
            Sections.Add((name, content));
        }

        public string Export()
        {
            foreach (var section in Sections)
            {
                report = $"{title} \n--------------------------------------\n {description} \n--------------------------------------\n {chapter}";
            }
            return report;        
        }
    }
}
