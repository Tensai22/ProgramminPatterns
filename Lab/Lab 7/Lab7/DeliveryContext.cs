using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class DeliveryContext
    {
        private IShippingStrategy _shippingStrategy;

        public void SetShippingStrategy(IShippingStrategy strategy)
        {
            _shippingStrategy = strategy;
        }

        public decimal CalculateCost(decimal weight, decimal distance)
        {
            if (_shippingStrategy == null)
            {
                throw new InvalidOperationException("Стратегия доставки не установлена.");
            }

            if (weight <= 0 || distance <= 0)
            {
                throw new ArgumentException("Вес и расстояние должны быть положительными числами.");
            }

            return _shippingStrategy.CalculateShippingCost(weight, distance);
        }
    }

}
