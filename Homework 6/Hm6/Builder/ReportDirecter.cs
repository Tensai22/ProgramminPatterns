using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6
{
    public class ReportDirecter
    {
        public void ConstructReport(IReportBuilder builder)
        {
            builder.SetHeader("Отчет о продажах");
            builder.SetContent("Содержимое отчета о продажах.");
            builder.SetFooter("Конец отчета");
        }
    }

}
