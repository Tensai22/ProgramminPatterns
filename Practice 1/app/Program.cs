using System;
using System.Collections.Generic;

namespace Name
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime T_camry = new DateTime(2008, 5, 12);
            DateTime H_civic = new DateTime(1998, 01, 01);
            DateTime HD_sportster = new DateTime(1952, 01, 01);
            DateTime BMW_sertao = new DateTime(2008, 01, 01);

            Car car1 = new("Toyota", "Camry", T_camry, 4, "Mechanical");
            Car car2 = new("Honda", "Civic", H_civic, 2, "Mechanical");

            Motorcycle motorcycle1 = new("Harley Davidson", "Sportster", HD_sportster, "sports", false);
            Motorcycle motorcycle2 = new("BMW", "G650GS Sertao", BMW_sertao, "off-road", false);

            // Cars garage
            Garage carGarage = new("Cars Garage");
            carGarage.AddTransport(car1);
            carGarage.AddTransport(car2);
            carGarage.Info();
            
            // Motorcycles garage
            Garage motorcycleGarage = new("Motorcycles Garage");
            motorcycleGarage.AddTransport(motorcycle1);
            motorcycleGarage.AddTransport(motorcycle2);
            motorcycleGarage.Info();

            // Autopark
            Fleet Autopark = new ("Autopark");
            Autopark.AddGarage(carGarage);
            Autopark.AddGarage(motorcycleGarage);
            Autopark.Info();
            Autopark.FindTransport(car1);
            Autopark.FindTransport(motorcycle1);

            car1.EngineStart();
            motorcycle1.EngineStart();
        }
    }

    public abstract class Vehicle
    {
        public string brand { get; set; }
        public string model { get; set; }
        public DateTime year { get; set; }

        public Vehicle(string brand, string model, DateTime year)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
        }

        public void EngineStart()
        {
            Console.WriteLine($"{brand} Engine is on");
        }

        public void EngineStop()
        {
            Console.WriteLine("Engine is stopped");
        }
    }

    public class Car : Vehicle
    {
        public int DoorsQuantity { get; set; }
        public string TypeOfTransmission { get; set; }

        public Car(string brand, string model, DateTime year, int doorsQuantity, string typeOfTransmission)
            : base(brand, model, year)
        {
            DoorsQuantity = doorsQuantity;
            TypeOfTransmission = typeOfTransmission;
        }
    }

    public class Motorcycle : Vehicle
    {
        public string bodyType { get; set; }
        public bool box { get; set; }

        public Motorcycle(string brand, string model, DateTime year, string bodyType, bool box)
            : base(brand, model, year)
        {
            this.bodyType = bodyType;
            this.box = box;
        }
    }

    public class Garage
    {
        public string ListOfTransports { get; set; }
        private List<Vehicle> vehicles = new List<Vehicle>();

        public Garage(string ListOfTransports)
        {
            this.ListOfTransports = ListOfTransports;
        }

        public void AddTransport(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void Info()
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Vehicle brand: {vehicle.brand}, model: {vehicle.model}, year: {vehicle.year.Year}");
            }
        }

        public List<Vehicle> GetVehicles()
        {
            return vehicles;
        }
    }

    public class Fleet
    {
        public string ListOfGarages { get; set; }
        private List<Garage> garages = new List<Garage>();

        public Fleet(string ListOfGarages)
        {
            this.ListOfGarages = ListOfGarages;
        }

        public void AddGarage(Garage garage)
        {
            garages.Add(garage);
        }

        public void FindTransport(Vehicle vehicle)
        {
            foreach (var garage in garages)
            {
                foreach (var storedVehicle in garage.GetVehicles())
                {
                    if (storedVehicle.brand == vehicle.brand && storedVehicle.model == vehicle.model)
                    {
                        Console.WriteLine($"Your searching vehicle stored in: {garage.ListOfTransports}, brand: {storedVehicle.brand}, model: {storedVehicle.model}, year: {storedVehicle.year.Year}");
                    }
                }
            }
        }

        public void Info()
        {
            foreach (var garage in garages)
            {
                Console.WriteLine(garage.ListOfTransports);
            }
        }
    }
}
