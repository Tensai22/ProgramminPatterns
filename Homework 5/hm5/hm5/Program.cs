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
            IVehicle car1 = GetVehicle(VehicleType.Car, "honda", "civic", "gas");
            car1.Drive();
            car1.Refuel();
            IVehicle moto1 = GetVehicle(VehicleType.Motorcycle, "Off road", "800");
            moto1.Drive();
            moto1.Refuel();
            IVehicle truck1 = GetVehicle(VehicleType.Truck, "1000", "4");
            truck1.Drive();
            truck1.Refuel();

        }
        public static IVehicle GetVehicle(VehicleType vehicleType, params string[] vehicleData)
        {
            VehicleCreater creater = null;

            switch (vehicleType)
            {
                case VehicleType.Car:
                    creater = new CarCreater(vehicleData[0], vehicleData[1], vehicleData[2]);
                    break;
                case VehicleType.Motorcycle:
                    creater = new MotorcycleCreater(vehicleData[0], int.Parse(vehicleData[1]));
                    break;
                case VehicleType.Truck:
                    creater = new TruckCreater(vehicleData[0], int.Parse(vehicleData[1]));
                    break;
            }
            return creater.CreateVehicle();
        }
        public interface IVehicle
        {
            void Drive();

            void Refuel();
        }
        public class Car : IVehicle
        {
            public string brand { get; set; }
            public string model { get; set; }
            public string fuelType { get; set; }


            public Car(string brand, string model, string fuelType)
            {
                this.brand = brand;
                this.model = model;
                this.fuelType = fuelType;
            }

            public void Drive()
            {
                Console.WriteLine($"Driving car: {brand} {model}, fuel type: {fuelType}");
            }
            public void Refuel()
            {
                Console.WriteLine($"Refueling car {brand} {model} with {fuelType}");
            }
        }
        public class Motorcycle : IVehicle
        {
            public string motorcycleType { get; set; }
            public int engineCapacity { get; set; }
            public Motorcycle(string motorcycleType, int engineCapacity)
            {
                this.motorcycleType = motorcycleType;
                this.engineCapacity = engineCapacity;
            }

            public void Drive()
            {
                Console.WriteLine($"Driving Motorcycle, type: {motorcycleType}, with engine capacity: {engineCapacity} ");
            }
            public void Refuel()
            {
                Console.WriteLine("Refueling Mototcycle");
            }
        }
        public class Truck : IVehicle
        {
            public string loadCapacity { get; set; }
            public int axis { get; set; }
            public Truck(string loadCapacity, int axis)
            {
                this.loadCapacity = loadCapacity;
                this.axis = axis;
            }
            public void Drive()
            {
                Console.WriteLine($"Driving Truck. Load capacity: {loadCapacity} and {axis} amount of axis");
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
            private string _brand;
            private string _model;
            private string _fuelType;

            public CarCreater(string brand, string model, string fuelType)
            {
                _brand = brand;
                _model = model;
                _fuelType = fuelType;
            }
            public override IVehicle CreateVehicle()
            {
                return new Car(_brand, _model, _fuelType);
            }
        }
        public class MotorcycleCreater : VehicleCreater
        {
            private string _motorcycleType;
            private int _engineCapacity;

            public MotorcycleCreater(string motorcycleType, int engineCapacity)
            {
                _motorcycleType = motorcycleType;
                _engineCapacity = engineCapacity;
            }
            public override IVehicle CreateVehicle()
            {
                return new Motorcycle(_motorcycleType, _engineCapacity);
            }
        }
        public class TruckCreater : VehicleCreater
        {
            private string _loadCapacity;
            private int _axis;

            public TruckCreater(string loadCapacity, int axis)
            {
                _loadCapacity = loadCapacity;
                _axis = axis;
            }
            public override IVehicle CreateVehicle()
            {
                return new Truck(_loadCapacity, _axis);
            }
        }
    }
}