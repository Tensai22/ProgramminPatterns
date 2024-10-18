using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr7.Observer
{
    public class TradingRobot : IObserver
    {
        private string _name;
        private decimal _threshold;

        public TradingRobot(string name, decimal threshold)
        {
            _name = name;
            _threshold = threshold;
        }

        public void Update(string stockSymbol, decimal price)
        {
            if (price < _threshold)
            {
                Console.WriteLine($"Robot {_name} buying {stockSymbol}, price is {price}");
            }
            else
            {
                Console.WriteLine($"Robot {_name} isnt buying {stockSymbol} current price: {price}");
            }
        }
    }

}
