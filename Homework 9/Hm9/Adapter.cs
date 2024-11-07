using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm9
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of ${amount} through PayPal.");
        }
    }
    public class StripePaymentService
    {
        public void MakeTransaction(double totalAmount)
        {
            Console.WriteLine($"Processing payment of ${totalAmount} through Stripe.");
        }
    }
    public class SquarePaymentService
    {
        public void ExecutePayment(double amount)
        {
            Console.WriteLine($"Processing payment of ${amount} through Square.");
        }
    }
    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentService _stripePaymentService;

        public StripePaymentAdapter(StripePaymentService stripePaymentService)
        {
            _stripePaymentService = stripePaymentService;
        }

        public void ProcessPayment(double amount)
        {
            _stripePaymentService.MakeTransaction(amount);
        }
    }
    public class SquarePaymentAdapter : IPaymentProcessor
    {
        private readonly SquarePaymentService _squarePaymentService;

        public SquarePaymentAdapter(SquarePaymentService squarePaymentService)
        {
            _squarePaymentService = squarePaymentService;
        }

        public void ProcessPayment(double amount)
        {
            _squarePaymentService.ExecutePayment(amount);
        }
    }
}
