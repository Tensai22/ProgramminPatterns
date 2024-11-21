using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    public interface IHotelService
    {
        List<string> FindHotels(string location, string roomType, decimal maxPrice);
        string GetHotelDetails(int hotelId);
    }

    public interface IBookingService
    {
        bool BookRoom(int hotelId, int roomId, DateTime checkIn, DateTime checkOut, int userId);
        bool CheckAvailability(int hotelId, int roomId, DateTime checkIn, DateTime checkOut);
    }

    public interface IPaymentService
    {
        bool ProcessPayment(int userId, decimal amount);
        bool VerifyPayment(int paymentId);
    }

    public interface INotificationService
    {
        void SendNotification(int userId, string message);
        void SendReminder(int bookingId);
    }

    public interface IUserManagementService
    {
        bool Register(string username, string password);
        int Login(string username, string password);
    }
    public class HotelService : IHotelService
    {
        public List<string> FindHotels(string location, string roomType, decimal maxPrice)
        {
            return new List<string> { "Hotel A", "Hotel B" };
        }

        public string GetHotelDetails(int hotelId)
        {
            return $"Hotel {hotelId}: Location, Room Types, Prices";
        }
    }
    public class BookingService : IBookingService
    {
        public bool BookRoom(int hotelId, int roomId, DateTime checkIn, DateTime checkOut, int userId)
        {
            Console.WriteLine($"Room {roomId} in Hotel {hotelId} booked by User {userId}");
            return true;
        }

        public bool CheckAvailability(int hotelId, int roomId, DateTime checkIn, DateTime checkOut)
        {
            return true;
        }
    }
    public class PaymentService : IPaymentService
    {
        public bool ProcessPayment(int userId, decimal amount)
        {
            Console.WriteLine($"Processed payment of {amount:C} for User {userId}");
            return true;
        }

        public bool VerifyPayment(int paymentId)
        {
            return true;
        }
    }
    public class NotificationService : INotificationService
    {
        public void SendNotification(int userId, string message)
        {
            Console.WriteLine($"Notification to User {userId}: {message}");
        }

        public void SendReminder(int bookingId)
        {
            Console.WriteLine($"Reminder sent for Booking {bookingId}");
        }
    }
    public class UserManagementService : IUserManagementService
    {
        private Dictionary<string, string> users = new Dictionary<string, string>();

        public bool Register(string username, string password)
        {
            if (users.ContainsKey(username))
                return false;

            users[username] = password;
            return true;
        }

        public int Login(string username, string password)
        {
            if (users.TryGetValue(username, out var storedPassword) && storedPassword == password)
                return username.GetHashCode(); 
            return -1;
        }
    }
    public class UI
    {
        private readonly IHotelService _hotelService;
        private readonly IBookingService _bookingService;
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;
        private readonly IUserManagementService _userManagementService;

        public UI(
            IHotelService hotelService,
            IBookingService bookingService,
            IPaymentService paymentService,
            INotificationService notificationService,
            IUserManagementService userManagementService)
        {
            _hotelService = hotelService;
            _bookingService = bookingService;
            _paymentService = paymentService;
            _notificationService = notificationService;
            _userManagementService = userManagementService;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the Hotel Booking System!");
            Console.WriteLine("1. Register\n2. Login\n3. Exit");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter username: ");
                var username = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                if (_userManagementService.Register(username, password))
                    Console.WriteLine("Registration successful!");
                else
                    Console.WriteLine("User already exists.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter username: ");
                var username = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                var userId = _userManagementService.Login(username, password);
                if (userId != -1)
                {
                    Console.WriteLine("Login successful!");
                }
                else
                    Console.WriteLine("Invalid credentials.");
            }
        }
    }

}
