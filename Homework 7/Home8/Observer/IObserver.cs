using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home8.Observer
{
    public interface IObserver
    {
        void Update(double exchangeRate);
    }

}
