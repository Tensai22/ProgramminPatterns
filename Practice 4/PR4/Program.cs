using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.AddItem("Ноутбук", 1500);
            order.AddItem("Мышь", 50);

            order.paymentMethod = new CreditCardPayment();
            order.deliveryMethod = new CourierDelivery();
            order.notification = new EmailNotification();

            var discountCalculator = new DiscountCalculator();
            double discount = discountCalculator.CalculateDiscount(order);
            order.CalculateTotalWithDiscount(discount);
            order.ProcessOrder();
        }
        public interface IPayment
        {
            void ProcessPayment(double amount);
        }
        public interface IDelivery
        {
            void DeliverOrder(Order order);
        }
        public interface INotification
        {
            void SendNotification(string message);
        }
        public class CreditCardPayment : IPayment
        {
            public void ProcessPayment(double amount)
            {
                Console.WriteLine($"Сrefit card payment: {amount}");
            }
        }

        public class PayPalPayment : IPayment
        {
            public void ProcessPayment(double amount)
            {
                Console.WriteLine($"Paypal payment: {amount}");
            }
        }

        public class BankTransferPayment : IPayment
        {
            public void ProcessPayment(double amount)
            {
                Console.WriteLine($"Bank transfer payment: {amount}");
            }
        }
        public class CourierDelivery : IDelivery
        {
            public void DeliverOrder(Order order)
            {
                Console.WriteLine("Courier delivery");
            }
        }

        public class PostDelivery : IDelivery
        {
            public void DeliverOrder(Order order)
            {
                Console.WriteLine("Mail delivery");
            }
        }

        public class PickUpPointDelivery : IDelivery
        {
            public void DeliverOrder(Order order)
            {
                Console.WriteLine("Delivery is ready to pickup");
            }
        }
        public class EmailNotification : INotification
        {
            public void SendNotification(string message)
            {
                Console.WriteLine($"Email: {message}");
            }
        }

        public class SmsNotification : INotification
        {
            public void SendNotification(string message)
            {
                Console.WriteLine($"SMS: {message}");
            }
        }
        public class Order
        {
            public List<string> Items { get; set; } = new List<string>();
            public double totalAmount { get; private set; }
            public IPayment paymentMethod { get; set; }
            public IDelivery deliveryMethod { get; set; }
            public INotification notification { get; set; }

            public void AddItem(string item, double price)
            {
                Items.Add(item);
                totalAmount += price;
            }

            public void CalculateTotalWithDiscount(double discount)
            {
                totalAmount -= discount;
                Console.WriteLine($"With discount: {totalAmount}");
            }

            public void ProcessOrder()
            {
                paymentMethod.ProcessPayment(totalAmount);

                deliveryMethod.DeliverOrder(this);

                notification.SendNotification("Delivery process succeed");
            }
        }
        public class DiscountCalculator
        {
            public double CalculateDiscount(Order order)
            {
                return order.totalAmount * 0.1;
            }
        }


    }
}
