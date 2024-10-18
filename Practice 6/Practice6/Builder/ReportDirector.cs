using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6.Builder
{
    public class ReportDirector
    {
        public void ConstructReport(IReportBuilder builder, ReportStyle style)
        {
            builder.SetStyle(style);
            builder.SetHeader("Sample Report");
            builder.SetContent("This is the main content of the report.");
            builder.AddSection("Introduction", "This is the introduction section.");
            builder.AddSection("Details", "This section contains detailed information.");
            builder.SetFooter("Report Footer");
        }
    }

}
