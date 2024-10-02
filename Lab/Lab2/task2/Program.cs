namespace Name
{
    class Program
    {
        public static void Main(){
            Car car1 = new();
            car1.Start();
            Truck truck2 = new();
            truck2.Stop();
        }
    }
    public abstract class Vehicle{
        public void Start()
        {
            Console.WriteLine($"{GetType().Name} is starting");
        }
        public void Stop()
        {
            Console.WriteLine($"{GetType().Name} is stopping");
        }
    }
    public class Car : Vehicle{

    }

    public class Truck : Vehicle{

    }

    
}