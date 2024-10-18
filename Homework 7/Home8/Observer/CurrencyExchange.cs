using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home8.Observer
{
    public class CurrencyExchange : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private double _exchangeRate;

        public double ExchangeRate
        {
            get { return _exchangeRate; }
            set
            {
                _exchangeRate = value;
                Notification();
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notification()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_exchangeRate);
            }
        }
    }

}
