using System;

namespace Name
{
    class Program
    {
        public static void Main(){
            AllInOnePrinter someDoc = new();
            someDoc.Print("Birth Certificate");
            someDoc.Fax("Diploma");
            someDoc.Scan("A4 photo");

            BasicPrinter someDoc2 = new();
            someDoc2.Print("Divorce papers");
        }
    }
    public interface Print
    {
    void Print(string content);
    }   
    public interface Scan{
        void Scan(string content);
    }
    public interface Fax{
        void Fax(string content);
    }

public class AllInOnePrinter : Print, Scan, Fax{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }

    public void Fax(string content)
    {
        Console.WriteLine("Faxing: " + content);
    }
}

public class BasicPrinter : Print
{
    public void Print(string content){
        Console.WriteLine("Pritting: " + content);
    }
}

    
}