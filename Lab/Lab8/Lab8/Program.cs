using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Decorator
            IBeverage beverage = new Coffee();
            Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

            beverage = new MilkDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

            beverage = new SugarDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

            beverage = new ChocolateDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

            //Adapter
            IPaymentProcessor internalProcessor = new InternalPaymentProcessor();
            internalProcessor.ProcessPayment(100.0);
            internalProcessor.RefundPayment(50.0);

            ExternalPaymentSystemA externalSystemA = new ExternalPaymentSystemA();
            IPaymentProcessor adapterA = new PaymentAdapterA(externalSystemA);
            adapterA.ProcessPayment(200.0);
            adapterA.RefundPayment(100.0);

            ExternalPaymentSystemB externalSystemB = new ExternalPaymentSystemB();
            IPaymentProcessor adapterB = new PaymentAdapterB(externalSystemB);
            adapterB.ProcessPayment(300.0);
            adapterB.RefundPayment(150.0);
        }
    }
}
