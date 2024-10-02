using System;

namespace Name
{
    class Program
    {
        public static void Main(string[] args)
        {
            Order order = new("Egg", 10, 800);
            Order order1 = new("Milk", 1, 500);
            Order order2 = new("Bread", 3, 750);

            PaymentProcessor paymentProcessor = new();
            paymentProcessor.ProcessPayment(order, "Kaspi qr");
            paymentProcessor.ProcessPayment(order1, "Halyq Card");
            paymentProcessor.ProcessPayment(order2, "Cash");

            EmailService emailService = new();
            emailService.SendConfirmationEmail("ordered_dude_email@gmail.com");
            emailService.SendConfirmationEmail("ordered_dude2_email@gmail.com");
            emailService.SendConfirmationEmail("ordered_dude3_email@gmail.com");
        }
    }

    public class Order(string ProductName, int Quantity, double Price)
    {
        public string ProductName { get; set; } = ProductName;
        public int Quantity { get; set; } = Quantity;
        public double Price { get; set; } = Price;

        public double CalculateTotalPrice()
        {
            return Quantity * Price * 0.9;
        }
    }

    public class PaymentProcessor
    {
        public void ProcessPayment(Order order, string paymentDetails)
        {
        Console.WriteLine($"{order.ProductName} price:  + {order.CalculateTotalPrice()} +  paid with  + {paymentDetails}");
        }
    }

    public class EmailService
    {
        public void SendConfirmationEmail(string email)
        {
            Console.WriteLine($"confirmation code send to: {email}");
        }
    }
}
