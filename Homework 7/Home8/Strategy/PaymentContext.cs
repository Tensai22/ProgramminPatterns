using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home8.Strategy
{
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
        public void ProcessPayment(double amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }

}
