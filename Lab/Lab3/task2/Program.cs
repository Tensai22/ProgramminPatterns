namespace Name
{
    class Program
    {
        public static void Main()
        {
            double amount = 1000;

            IDiscountStrategy discountStrategy = new RegularCustomerDiscount();
            var calculator = new DiscountCalculator(discountStrategy);
            Console.WriteLine($"Regular customer discount: {calculator.CalculateDiscount(amount)}");

            discountStrategy = new SilverCustomerDiscount();
            calculator = new DiscountCalculator(discountStrategy);
            Console.WriteLine($"Silver customer discount: {calculator.CalculateDiscount(amount)}");

            discountStrategy = new GoldCustomerDiscount();
            calculator = new DiscountCalculator(discountStrategy);
            Console.WriteLine($"Gold customer discount: {calculator.CalculateDiscount(amount)}");

            discountStrategy = new PlatinumCustomerDiscount();
            calculator = new DiscountCalculator(discountStrategy);
            Console.WriteLine($"Platinum customer discount: {calculator.CalculateDiscount(amount)}");


        }
        public interface IDiscountStrategy
        {
            double CalculateDiscount(double amount);
        }

        public class RegularCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                return amount;
            }
        }

        public class SilverCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                return amount * 0.9;
            }
        }

        public class GoldCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                return amount * 0.8;
            }
        }

        public class PlatinumCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                return amount * 0.7;
            }
        }

        public class DiscountCalculator
        {
            private readonly IDiscountStrategy _discountStrategy;

            public DiscountCalculator(IDiscountStrategy discountStrategy)
            {
                _discountStrategy = discountStrategy;
            }

            public double CalculateDiscount(double amount)
            {
                return _discountStrategy.CalculateDiscount(amount);
            }
        }

    }
}