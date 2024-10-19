using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hm3
{
    internal class Program
    {
        public enum LogLevel
        {
            Error,
            Warning,
            Info
        }
        static void Main(string[] args)
        {
            Log(LogLevel.Error, "ERROR!");
            Log(LogLevel.Warning, "WARNING.");
            Log(LogLevel.Info, "INFO?");

            LoggingService logg = new LoggingService();
            logg.Log("Some database messages and shi");
        }
        
        public static void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{level.ToString().ToUpper()}: {message}");
        }
        public class Config
        {
            public static string ConnectionString = "RANDOM DATABASE";
        }

        public class DatabaseService
        {
            public void Connect()
            {
                Console.WriteLine($"Connecting to {Config.ConnectionString}");
            }
        }

        public class LoggingService
        {
            public void Log(string message)
            {
                Console.WriteLine($"Logging to {Config.ConnectionString}. Message {message}");
            }
        }
        public void ProcessNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return;

            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
        public void PrintPositiveNumbers(int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
        public int Divide(int a, int b)
        {
            return b == 0 ? 0 : a / b;
        }
        public class User //Надо отделить методы иынутри класса юзер для принципа YAGNI
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
        }

        public class UserService
        {
            public void SaveToDatabase(User user)
            {
            }
        }

        public class EmailService
        {
            public void SendEmail(User user)
            {
            }
        }

        public class PrintService
        {
            public void PrintAddressLabel(User user)
            {
            }
        }
        public class FileReader
        {
            public string ReadFile(string filePath)
            {
                return "file content";
            }
        }
        public class ReportGenerator //вместо разных классов формата лучше сразу добавить формат в этот класс
        {
            public void GenerateReport(string format)
            {
            }
        }

    }
}
