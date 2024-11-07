using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm9
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            IBeverage myDrink = new Mocha();
            myDrink = new Caramel(myDrink);
            myDrink = new Vanilla(myDrink);
            myDrink = new WhippedCream(myDrink);

            Console.WriteLine($"Description: {myDrink.GetDescription()}");
            Console.WriteLine($"Cost: ${myDrink.Cost():0.00}");
            IBeverage anotherDrink = new Cappuccino();
            anotherDrink = new Milk(anotherDrink);
            anotherDrink = new Sugar(anotherDrink);

            Console.WriteLine($"\nDescription: {anotherDrink.GetDescription()}");
            Console.WriteLine($"Cost: ${anotherDrink.Cost():0.00}");

            IPaymentProcessor paypal = new PayPalPaymentProcessor();
            IPaymentProcessor stripe = new StripePaymentAdapter(new StripePaymentService());
            IPaymentProcessor square = new SquarePaymentAdapter(new SquarePaymentService());

            paypal.ProcessPayment(100.00);
            stripe.ProcessPayment(150.00);
            square.ProcessPayment(200.00);
        }
    }
}
