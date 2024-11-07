using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice9
{
    public interface IReport
    {
        string Generate();
    }
    public class SalesReport : IReport
    {
        public string Generate()
        {
            return "Sales Report Data";
        }
    }

    public class UserReport : IReport
    {
        public string Generate()
        {
            return "User Report Data";
        }
    }
    public abstract class ReportDecorator : IReport
    {
        protected IReport _report;

        public ReportDecorator(IReport report)
        {
            _report = report;
        }

        public virtual string Generate()
        {
            return _report.Generate();
        }
    }
    public class DateFilterDecorator : ReportDecorator
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public DateFilterDecorator(IReport report, DateTime startDate, DateTime endDate) : base(report)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public override string Generate()
        {
            return $"{base.Generate()} with Date Filtering from {_startDate} to {_endDate}";
        }
    }
    public class SortingDecorator : ReportDecorator
    {
        private string _sortCriteria;

        public SortingDecorator(IReport report, string sortCriteria) : base(report)
        {
            _sortCriteria = sortCriteria;
        }

        public override string Generate()
        {
            return $"{base.Generate()} sorted by {_sortCriteria}";
        }
    }
    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            return $"{base.Generate()} exported to CSV";
        }
    }

    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            return $"{base.Generate()} exported to PDF";
        }
    }
    public class ReportGenerator
    {
        public void GenerateReport()
        {
            IReport report = new SalesReport();
            report = new DateFilterDecorator(report, DateTime.Now.AddDays(-7), DateTime.Now);
            report = new SortingDecorator(report, "Date");
            report = new CsvExportDecorator(report);

            Console.WriteLine(report.Generate());
        }
    }

}
