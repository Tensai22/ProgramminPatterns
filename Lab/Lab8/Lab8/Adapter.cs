using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount); 
        void RefundPayment(double amount); 
    }

    public class InternalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Обработка платежа на сумму {amount} через внутреннюю систему.");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Возврат платежа на сумму {amount} через внутреннюю систему.");
        }
    }

    public class ExternalPaymentSystemA
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Выполнение платежа на сумму {amount} через внешнюю платежную систему Paypal.");
        }

        public void MakeRefund(double amount)
        {
            Console.WriteLine($"Возврат платежа на сумму {amount} через внешнюю платежную систему Paypal.");
        }
    }

    public class ExternalPaymentSystemB
    {
        public void SendPayment(double amount)
        {
            Console.WriteLine($"Отправка платежа на сумму {amount} через внешнюю платежную систему Kaspi.");
        }

        public void ProcessRefund(double amount)
        {
            Console.WriteLine($"Обработка возврата на сумму {amount} через внешнюю платежную систему Kaspi.");
        }
    }

    public class PaymentAdapterA : IPaymentProcessor
    {
        private ExternalPaymentSystemA _externalSystemA;

        public PaymentAdapterA(ExternalPaymentSystemA externalSystemA)
        {
            _externalSystemA = externalSystemA;
        }

        public void ProcessPayment(double amount)
        {
            _externalSystemA.MakePayment(amount);
        }

        public void RefundPayment(double amount)
        {
            _externalSystemA.MakeRefund(amount);
        }
    }

    public class PaymentAdapterB : IPaymentProcessor
    {
        private ExternalPaymentSystemB _externalSystemB;

        public PaymentAdapterB(ExternalPaymentSystemB externalSystemB)
        {
            _externalSystemB = externalSystemB;
        }

        public void ProcessPayment(double amount)
        {
            _externalSystemB.SendPayment(amount);
        }

        public void RefundPayment(double amount)
        {
            _externalSystemB.ProcessRefund(amount);
        }
    }
}
