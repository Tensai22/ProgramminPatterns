using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            DeliveryContext deliveryContext = new DeliveryContext();

            Console.WriteLine("Выберите тип доставки: 1 - Стандартная, 2 - Экспресс, 3 - Международная, 4 - Ночная");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    deliveryContext.SetShippingStrategy(new StandardShippingStrategy());
                    break;
                case "2":
                    deliveryContext.SetShippingStrategy(new ExpressShippingStrategy());
                    break;
                case "3":
                    deliveryContext.SetShippingStrategy(new InternationalShippingStrategy());
                    break;
                case "4":
                    deliveryContext.SetShippingStrategy(new NightShippingStrategy());
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            try
            {
                Console.WriteLine("Введите вес посылки (кг):");
                decimal weight = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Введите расстояние доставки (км):");
                decimal distance = Convert.ToDecimal(Console.ReadLine());

                decimal cost = deliveryContext.CalculateCost(weight, distance);
                Console.WriteLine($"Стоимость доставки: {cost}$");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
