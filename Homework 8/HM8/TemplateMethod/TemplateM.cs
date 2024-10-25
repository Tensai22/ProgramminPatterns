using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8.TemplateMethod
{
    public abstract class Beverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }
        }

        protected abstract void Brew();
        protected abstract void AddCondiments();

        protected virtual bool CustomerWantsCondiments() => true;

        private void BoilWater() => Console.WriteLine("Boiling water...");
        private void PourInCup() => Console.WriteLine("Pouring into cup...");
    }

    public class Tea : Beverage
    {
        protected override void Brew() => Console.WriteLine("Steeping the tea");
        protected override void AddCondiments() => Console.WriteLine("Adding lemon");

        protected override bool CustomerWantsCondiments()
        {
            Console.WriteLine("Would you like lemon with your tea (y/n)?");
            return Console.ReadLine()?.ToLower() == "y";
        }
    }

    public class Coffee : Beverage
    {
        protected override void Brew() => Console.WriteLine("Dripping coffee through filter");
        protected override void AddCondiments() => Console.WriteLine("Adding sugar and milk");

        protected override bool CustomerWantsCondiments()
        {
            Console.WriteLine("Would you like milk and sugar with your coffee (y/n)?");
            return Console.ReadLine()?.ToLower() == "y";
        }
    }

}
