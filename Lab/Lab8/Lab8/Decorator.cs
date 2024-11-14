using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public interface IBeverage
    {
        double GetCost();
        string GetDescription(); 
    }

    public class Coffee : IBeverage
    {
        public double GetCost()
        {
            return 50.0;
        }

        public string GetDescription()
        {
            return "Кофе";
        }
    }

    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage _beverage;

        public BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public virtual double GetCost()
        {
            return _beverage.GetCost();
        }

        public virtual string GetDescription()
        {
            return _beverage.GetDescription();
        }
    }

    public class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 10.0;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Молоко";
        }
    }

    public class SugarDecorator : BeverageDecorator
    {
        public SugarDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 5.0;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Сахар";
        }
    }

    public class ChocolateDecorator : BeverageDecorator
    {
        public ChocolateDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 15.0;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Шоколад";
        }
    }
}
