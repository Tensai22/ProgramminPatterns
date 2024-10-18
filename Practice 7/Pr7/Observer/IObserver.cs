using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr7.Observer
{
    public interface IObserver
    {
        void Update(string stockSymbol, decimal price);
    }
}
