using Pr7.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pr7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TravelContext context = new TravelContext();
            context.ChangeCalculation(new PlaneTravel());
            Console.WriteLine($"Cost of plane travel: {context.CalculateTravelCost(2, 1, true)}");

            context.ChangeCalculation(new TrainTravel());
            Console.WriteLine($"Cost of train travel: {context.CalculateTravelCost(4, 3, false)}");

            Exchanger stockExchange = new Exchanger();

            stockExchange.AddStock("BTC", 18000);
            stockExchange.AddStock("ETH", 2000);

            Trader traderBabek = new Trader("Babek");
            Trader traderBobik = new Trader("Bobik");
            TradingRobot teslaRobot = new TradingRobot("Tesla Robot", 1000);
            TradingRobot googleRobot = new TradingRobot("Gooogle Robot", 800);

            stockExchange.Attach("BTC", traderBabek);
            stockExchange.Attach("BTC", teslaRobot);
            stockExchange.Attach("ETH", traderBobik);
            stockExchange.Attach("ETH", googleRobot);

            stockExchange.UpdateStockPrice("BTC", 1400);
            stockExchange.UpdateStockPrice("ETH", 2600);

            stockExchange.Detach("BTC", teslaRobot);
            stockExchange.UpdateStockPrice("BTC", 1500);

        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
        public interface ICostCalculate
        {
            double Calculate(int passenger, int typeClass, bool baggage);
        }
        public class PlaneTravel : ICostCalculate
        {
            public int passenger { get; set; }
            public int typeClass { get; set; }
            public int baggage { get; set; }

            public double Calculate(int passenger, int typeClass, bool baggage)
            {
                double cost = 0;
                if (typeClass == 1)
                {
                    cost = passenger * 1200;
                }
                else if (typeClass == 2)
                {
                    cost = passenger * 1000;
                }
                else
                {
                    cost = passenger * 800;

                }

                if (baggage)
                {
                    cost = cost * 2;
                }
                return cost;
            }
        }
        public class TrainTravel : ICostCalculate
        {
            public int passenger { get; set; }
            public int typeClass { get; set; }
            public bool baggage { get; set; }

            public double Calculate(int passenger, int typeClass, bool baggage)
            {
                double cost = 0;
                if (typeClass == 1)
                {
                    cost = passenger * 1000;
                }
                else if (typeClass == 2)
                {
                    cost = passenger * 800;
                }
                else
                {
                    cost = passenger * 500;
                }

                if (baggage)
                {
                    cost = cost * 2;
                }
                return cost;
            }
        }
        public class TravelContext
        {
            private ICostCalculate calculation;
            public void ChangeCalculation(ICostCalculate calculation)
            {
                this.calculation = calculation;
            }

            public double CalculateTravelCost(int passenger, int TypeClass, bool baggage)
            {
                if (calculation == null)
                {
                    throw new Exception("Error");
                }
                return calculation.Calculate(passenger, TypeClass, baggage);
            }
        }
    }
}
