using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home8.Observer
{
    public class AppObserver : IObserver
    {
        public void Update(double exchangeRate)
        {
            Console.WriteLine($"App: {exchangeRate}");
        }
    }

}
