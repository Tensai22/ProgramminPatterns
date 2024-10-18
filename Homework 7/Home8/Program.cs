using Home8.Observer;
using Home8.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home8
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentContext context = new PaymentContext();

            context.SetPaymentStrategy(new CardPayment());

            context.ProcessPayment(250);

            context.SetPaymentStrategy(new PaypalPayment());

            context.ProcessPayment(500);

            context.SetPaymentStrategy(new CryptoPayment());

            context.ProcessPayment(1000);



            CurrencyExchange currencyExchange = new CurrencyExchange();

            var app = new AppObserver();
            var desktopApp = new DesktopObserver();
            var email = new EmailObserver();

            currencyExchange.Attach(app);
            currencyExchange.ExchangeRate = 130;

            currencyExchange.Attach(desktopApp);
            currencyExchange.Attach(email);
            currencyExchange.ExchangeRate = 150;

            currencyExchange.Detach(app);
            currencyExchange.ExchangeRate = 200;
        }
    }
}
