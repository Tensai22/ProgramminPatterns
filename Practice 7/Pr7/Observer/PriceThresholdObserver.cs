using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr7.Observer
{
    public class PriceThresholdObserver : IObserver
    {
        private string _name;
        private decimal _threshold;

        public PriceThresholdObserver(string name, decimal threshold)
        {
            _name = name;
            _threshold = threshold;
        }

        public void Update(string stockSymbol, decimal price)
        {
            if (price > _threshold)
            {
                Console.WriteLine($"{_name}: {stockSymbol}{_threshold} and is now {price}");
            }
        }
    }

}
