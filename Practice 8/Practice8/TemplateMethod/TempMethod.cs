using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8.TemplateMethod
{
    public abstract class ReportGenerator
    {
        public void GenerateReport()
        {
            CreateHeader();
            FormatData();
            SaveToFile();
            Hook();
        }

        protected abstract void CreateHeader();
        protected abstract void FormatData();
        protected virtual void Hook() { }

        protected virtual void SaveToFile()
        {
            Console.WriteLine("Report saved to file.");
        }
    }

    public class PdfReport : ReportGenerator
    {
        protected override void CreateHeader() => Console.WriteLine("Creating PDF Header...");
        protected override void FormatData() => Console.WriteLine("Formatting PDF Data...");
    }

    public class ExcelReport : ReportGenerator
    {
        protected override void CreateHeader() => Console.WriteLine("Creating Excel Header...");
        protected override void FormatData() => Console.WriteLine("Formatting Excel Data...");
    }

    public class HtmlReport : ReportGenerator
    {
        protected override void CreateHeader() => Console.WriteLine("Creating HTML Header...");
        protected override void FormatData() => Console.WriteLine("Formatting HTML Data...");
    }

}
