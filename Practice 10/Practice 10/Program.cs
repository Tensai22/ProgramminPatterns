using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    public abstract class OrganizationComponent
    {
        public string name;
        public double salary;

        public abstract void Add(OrganizationComponent component);
        public abstract void Remove(OrganizationComponent component);
    }

    internal class Program
    {
    
        static void Main(string[] args)
        {
            //HotelFacade hotelFacade = new HotelFacade();
            //hotelFacade.BookRoom('22-08-2005', 25, 5, 23);
            //ctrl k c

            Department department = new Department();
            department.name = "IT Departament";
            Employee Stacy = new Employee();
            Employee Cecilion = new Employee();
            Employee Thomas = new Employee();
            department.Add(Stacy);
            department.Add(Cecilion);
            department.Add(Thomas);
            department.GetCount();

            Department department2 = new Department();
            department2.name = "ML Department";
            Employee John = new Employee();
            Employee Phrarrell = new Employee();
            department2.Add(John);
            department2.Add(Phrarrell);

            Department department3 = new Department();
            department3.name = "Finances Department";
            Employee Lesly = new Employee();
            Employee Mia = new Employee();
            department3.Add(Mia);
            department3.Add(Lesly);
            
        }
    }
    public class HotelFacade
    {
        public void BookRoom(DateTime StartTime, DateTime EndTime, int peopleAmount, int roomNum)
        {
            RoomBookingSystem roomBookingSystem = new RoomBookingSystem();
            roomBookingSystem.MakeReservations(StartTime, EndTime, peopleAmount);
            roomBookingSystem.Payment(5000);
            CleaningService cleaningService = new CleaningService();
            cleaningService.Notify(StartTime, EndTime, roomNum);
            RestaurantService restaurantService = new RestaurantService();
            restaurantService.Notify(peopleAmount, 200);
        }
    }
}
