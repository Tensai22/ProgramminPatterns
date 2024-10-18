using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr7.Observer
{
    public interface ISubject
    {
        void Attach(string stockSymbol, IObserver observer);
        void Detach(string stockSymbol, IObserver observer);
        void Notify(string stockSymbol, decimal price);
    }
}
