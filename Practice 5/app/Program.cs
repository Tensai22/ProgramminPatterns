using System.Reflection.Metadata;

namespace Name
{
    public enum DocType
    {
        Report, Resume, Letter, Invoice
    }
    class Program
    {
        public static void Main(){
           GetDocument(DocType.Report).Open();
            GetDocument(DocType.Resume).Open(); 
            GetDocument(DocType.Letter).Open();
            GetDocument(DocType.Invoice).Open();
            Console.ReadKey();
        }
        public static IDocument GetDocument(DocType docType){
            
            DocumentCreater creater = null;
            IDocument document = null;

            switch (docType)
            {
                case DocType.Report:
                    creater = new ReportCreater();
                    break;
                case DocType.Resume:
                    creater = new ResumeCreater();
                    break;
                case DocType.Letter:
                    creater = new LetterCreater();
                    break;
                case DocType.Invoice:
                    creater = new InvoiceCreater();
                    
                    break;
            }
            document = creater.CreateDocument();
            return document;
        }
    }
    public interface IDocument
    {
        void Open();
    }
    public class Report : IDocument{
        public void Open(){
            Console.WriteLine("Opening report");
        }
    }
        public class Resume : IDocument{
        public void Open(){
            Console.WriteLine("Opening resume");
        }
    }
        public class Letter : IDocument{
        public void Open(){
            Console.WriteLine("Opening letter");
        }
    }
        public class Invoice : IDocument{
        public void Open(){
            Console.WriteLine("Opening Invoice");
        }
    }

    
    public abstract class DocumentCreater{
        public abstract IDocument CreateDocument();
    }
    public class ReportCreater : DocumentCreater{
        public override IDocument CreateDocument(){
            return new Report();
        }
    }
    public class ResumeCreater : DocumentCreater{
        public override IDocument CreateDocument(){
           return new Resume();
        }
    }
    public class LetterCreater : DocumentCreater{
        public override IDocument CreateDocument(){
            return new Letter();
        }
    }
    public class InvoiceCreater : DocumentCreater{
        public override IDocument CreateDocument(){
            return new Invoice();
        }
    }
}