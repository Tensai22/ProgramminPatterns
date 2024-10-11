using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    public class Pizza
    {
        public string Size { get; set; }
        public string Sauce { get; set; }
        public string Cheese { get; set; }
    }
    public interface IPizzaBuilder
    {
        void SetSize();
        void SetSauce();
        void SetCheese();
        Pizza GetPizza();
    }
    public class Margaritta : IPizzaBuilder
    {
        private Pizza pizza = new Pizza();
        public Pizza GetPizza()
        {
            return pizza;
        }
        public void SetSize()
        {
            pizza.Size = "Small";
        }
        public void SetSauce()
        {
            pizza.Sauce = "Barbeque";
        }
        public void SetCheese()
        {
            pizza.Cheese = "Goat milk";
        }
    }
    public class PizzaDirecter
    {
        private IPizzaBuilder _pizzaBuilder;
        public PizzaDirecter(IPizzaBuilder pizzaBuilder)
        {
            _pizzaBuilder = pizzaBuilder;
        }
        public void ConstructPizza()
        {
            _pizzaBuilder.SetSize();
            _pizzaBuilder.SetSauce();
            _pizzaBuilder.SetCheese();
        }
        public Pizza GetPizza()
        {
            return _pizzaBuilder.GetPizza();
        }

    }
}
