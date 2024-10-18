using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr7.Observer
{
    public class Trader : IObserver
    {
        private string _name;

        public Trader(string name)
        {
            _name = name;
        }

        public void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"Trader {_name} notified: {stockSymbol} is now {price}");
        }
    }

}
