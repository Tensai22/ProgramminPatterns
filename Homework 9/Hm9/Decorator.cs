using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm9
{
    public interface IBeverage
    {
        string GetDescription();
        double Cost();
    }
    public class Espresso : IBeverage
    {
        public string GetDescription() => "Espresso";
        public double Cost() => 2.00;
    }

    public class Tea : IBeverage
    {
        public string GetDescription() => "Tea";
        public double Cost() => 1.50;
    }

    public class Latte : IBeverage
    {
        public string GetDescription() => "Latte";
        public double Cost() => 3.00;
    }
    public class Mocha : IBeverage
    {
        public string GetDescription() => "Mocha";
        public double Cost() => 3.50;
    }

    public class Cappuccino : IBeverage
    {
        public string GetDescription() => "Cappuccino";
        public double Cost() => 3.20;
    }

    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage _beverage;

        protected BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public virtual string GetDescription() => _beverage.GetDescription();
        public virtual double Cost() => _beverage.Cost();
    }
    public class Milk : BeverageDecorator
    {
        public Milk(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", Milk";
        public override double Cost() => _beverage.Cost() + 0.50;
    }

    public class Sugar : BeverageDecorator
    {
        public Sugar(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", Sugar";
        public override double Cost() => _beverage.Cost() + 0.20;
    }

    public class WhippedCream : BeverageDecorator
    {
        public WhippedCream(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", Whipped Cream";
        public override double Cost() => _beverage.Cost() + 0.70;
    }
    public class Vanilla : BeverageDecorator
    {
        public Vanilla(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", Vanilla";
        public override double Cost() => _beverage.Cost() + 0.75;
    }

    public class Caramel : BeverageDecorator
    {
        public Caramel(IBeverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", Caramel";
        public override double Cost() => _beverage.Cost() + 0.60;
    }

}
