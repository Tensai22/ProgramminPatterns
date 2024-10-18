using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr7.Observer
{
    public class Exchanger : ISubject
    {
        private Dictionary<string, decimal> _stocks = new Dictionary<string, decimal>();
        private Dictionary<string, List<IObserver>> _observers = new Dictionary<string, List<IObserver>>(); 

        public void AddStock(string stockSymbol, decimal price)
        {
            _stocks[stockSymbol] = price;
            _observers[stockSymbol] = new List<IObserver>();
        }

        public void UpdateStockPrice(string stockSymbol, decimal price)
        {
            if (_stocks.ContainsKey(stockSymbol))
            {
                _stocks[stockSymbol] = price;
                Notify(stockSymbol, price); 
            }
        }

        public void Attach(string stockSymbol, IObserver observer)
        {
            if (_observers.ContainsKey(stockSymbol))
            {
                _observers[stockSymbol].Add(observer);
            }
        }

        public void Detach(string stockSymbol, IObserver observer)
        {
            if (_observers.ContainsKey(stockSymbol))
            {
                _observers[stockSymbol].Remove(observer);
            }
        }

        public void Notify(string stockSymbol, decimal price)
        {
            if (_observers.ContainsKey(stockSymbol))
            {
                foreach (var observer in _observers[stockSymbol])
                {
                    observer.Update(stockSymbol, price);
                }
            }
        }
        public async Task NotifyAsync(string stockSymbol, decimal price)
        {
            if (_observers.ContainsKey(stockSymbol))
            {
                var notifyTasks = _observers[stockSymbol].Select(observer => Task.Run(() => observer.Update(stockSymbol, price)));
                await Task.WhenAll(notifyTasks);
            }
        }

    }

}
