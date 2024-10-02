namespace App
{
    class Program
    {
        public enum VehicleType
        {
            Car, Motorcycle, Truck
        }
        public static void Main(string[] args)
        {
            GetVehicle(VehicleType.Car).Drive();
            GetVehicle(VehicleType.Motorcycle).Drive();
            GetVehicle(VehicleType.Truck).Drive();

            GetVehicle(VehicleType.Car).Refuel();
            GetVehicle(VehicleType.Motorcycle).Refuel();
            GetVehicle(VehicleType.Truck).Refuel(); 
        }
        public static IVehicle GetVehicle(VehicleType vehicleType)
        {
            VehicleCreater creater = null;
            IVehicle vehicle = null;

            switch (vehicleType)
            {
                case VehicleType.Car:
                    creater = new CarCreater();
                    break;
                case VehicleType.Motorcycle:
                    creater = new MotorcycleCreater();
                    break;
                case VehicleType.Truck:
                    creater = new TruckCreater();
                    break;
            }
            vehicle = creater.CreateVehicle();
            return vehicle;
        }
        public interface IVehicle
        {
            void Drive();

            void Refuel();
        }
        public class Car : IVehicle
        {
            public string brand;
            public string model;
            public string fuelType;


            public Car(string brand, string model, string fuelType)
            {
                this.brand = brand;
                this.model = model;
                this.fuelType = fuelType;
            }

            public void Drive()
            {
                Console.WriteLine("Driving car");
            }
            public void Refuel()
            {
                Console.WriteLine("Refueling car");
            }
        }
        public class Motorcycle : IVehicle
        {
            public string motorcycleType;
            public int engineCapacity;
            public Motorcycle(string motorcycleType, int engineCapacity)
            {
                this.motorcycleType = motorcycleType;
                this.engineCapacity = engineCapacity;
            }

            public void Drive()
            {
                Console.WriteLine("Driving Motorcycle");
            }
            public void Refuel()
            {
                Console.WriteLine("Refueling Mototcycle");
            }
        }
        public class Truck : IVehicle
        {
            public string loadCapacity;
            public int axis;
            public Truck(string loadCapacity, int axis)
            {
                this.loadCapacity = loadCapacity;
                this.axis = axis;
            }
            public void Drive()
            {
                Console.WriteLine("Driving Truck");
            }
            public void Refuel()
            {
                Console.WriteLine("Refueling Truck");
            }
        }
        public abstract class VehicleCreater
        {
            public abstract IVehicle CreateVehicle();
        }
        public class CarCreater : VehicleCreater
        {
            public override IVehicle CreateVehicle()
            {
                return new Car();
            }
        }
        public class MotorcycleCreater : VehicleCreater
        {
            public override IVehicle CreateVehicle()
            {
                return new Motorcycle();
            }
        }
        public class TruckCreater : VehicleCreater
        {
            public override IVehicle CreateVehicle()
            {
                return new Truck();
            }
        }
    }
}