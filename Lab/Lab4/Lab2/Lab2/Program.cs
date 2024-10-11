using System;

namespace Lab2
{
    class Program
    {
        public static void Main(string[] args)  
        {
            Console.WriteLine("Выберите тип транспортного средства (1: Автомобиль, 2: Мотоцикл, 3: Самолет, 4: Велосипед): ");
            string choice = Console.ReadLine();

            TransportFactory factory = null;

            switch (choice)
            {
                case "1":
                    factory = new CarFactory();
                    break;
                case "2":
                    factory = new MotorcycleFactory();
                    break;
                case "3":
                    factory = new PlaneFactory();
                    break;
                case "4":
                    factory = new BicycleFactory();
                    break;
                default:
                    Console.WriteLine("Неправильный ввод.");
                    return;
            }

            ITransport transport = factory.CreateTransport();

            Console.WriteLine("Введите модель транспортного средства: ");
            string model = Console.ReadLine();

            Console.WriteLine("Введите максимальную скорость транспортного средства: ");
            int speed;
            if (!int.TryParse(Console.ReadLine(), out speed))
            {
                Console.WriteLine("Неправильный ввод скорости.");
                return;
            }

            Console.WriteLine($"Модель: {model}, Максимальная скорость: {speed} км/ч.");
            transport.Move();
            transport.Refuel();
        }
    }

    public interface ITransport
    {
        void Move();
        void Refuel();
    }

    public class Car : ITransport
    {
        public void Move()
        {
            Console.WriteLine("Автомобиль едет по дороге.");
        }

        public void Refuel()
        {
            Console.WriteLine("Автомобиль заправляется бензином.");
        }
    }

    public class Motorcycle : ITransport
    {
        public void Move()
        {
            Console.WriteLine("Мотоцикл едет по шоссе.");
        }

        public void Refuel()
        {
            Console.WriteLine("Мотоцикл заправляется бензином.");
        }
    }

    public class Plane : ITransport
    {
        public void Move()
        {
            Console.WriteLine("Самолет летит в небе.");
        }

        public void Refuel()
        {
            Console.WriteLine("Самолет заправляется керосином.");
        }
    }

    public abstract class TransportFactory
    {
        public abstract ITransport CreateTransport();
    }

    public class CarFactory : TransportFactory
    {
        public override ITransport CreateTransport()
        {
            return new Car();
        }
    }

    public class MotorcycleFactory : TransportFactory
    {
        public override ITransport CreateTransport()
        {
            return new Motorcycle();
        }
    }

    public class PlaneFactory : TransportFactory
    {
        public override ITransport CreateTransport()
        {
            return new Plane();
        }
    }

    public class Bicycle : ITransport
    {
        public void Move()
        {
            Console.WriteLine("Велосипед едет по велосипедной дорожке.");
        }

        public void Refuel()
        {
            Console.WriteLine("Велосипед не нуждается в топливе.");
        }
    }

    public class BicycleFactory : TransportFactory
    {
        public override ITransport CreateTransport()
        {
            return new Bicycle();
        }
    }
}
