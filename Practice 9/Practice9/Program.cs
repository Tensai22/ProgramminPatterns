using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating Report with Decorators:");
            var reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport();

            Console.WriteLine("\nProcessing Delivery with Adapter:");
            var deliveryManager = new DeliveryManager();
            deliveryManager.ProcessOrder("12345", "ExternalA");
            deliveryManager.ProcessOrder("67890", "Internal");
        }
    }
}
