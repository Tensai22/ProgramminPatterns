using Hm6.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton
            



            //Builder:
            ReportDirecter directer = new ReportDirecter();

            IReportBuilder textBuilder = new TextReportBuilder();
            directer.ConstructReport(textBuilder);
            Report textReport = textBuilder.GetReport();
            Console.WriteLine("Текстовый отчет:");
            textReport.Display();

            Console.WriteLine();

            IReportBuilder htmlBuilder = new HtmlReportBuilder();
            directer.ConstructReport(htmlBuilder);
            Report htmlReport = htmlBuilder.GetReport();
            Console.WriteLine("HTML отчет:");
            htmlReport.Display();


            //Prototype:
            Order originalOrder = new Order
            {
                DeliveryCost = 10.0m,
                PaymentMethod = "Credit Card"
            };
            originalOrder.Products.Add(new Product("Laptop", 1200.0m, 1));
            originalOrder.Discounts.Add(new Discount("Black Friday", 100.0m));

            Order clonedOrder = (Order)originalOrder.Clone();
            clonedOrder.PaymentMethod = "PayPal"; 

            PrintOrder(originalOrder);
            PrintOrder(clonedOrder);
        }
        public static void PrintOrder(Order order)
        {
            Console.WriteLine($"Payment Method: {order.PaymentMethod}");
            Console.WriteLine($"Delivery Cost: {order.DeliveryCost}");
            Console.WriteLine("Products:");
            foreach (var product in order.Products)
            {
                Console.WriteLine($" - {product.Name}: {product.Price} x {product.Quantity}");
            }
            Console.WriteLine("Discounts:");
            foreach (var discount in order.Discounts)
            {
                Console.WriteLine($" - {discount.Description}: {discount.Amount}");
            }
            Console.WriteLine();
        }
    }

}
