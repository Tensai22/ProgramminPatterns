namespace Name
{
    class Program
    {
        public static void Main()
        {
            INotificationService emailService = new EmailService();
            Notification emailNotification = new Notification(emailService);
            emailNotification.Send("Это тестовое уведомление по Email.");

            INotificationService smsService = new SmsService();
            Notification smsNotification = new Notification(smsService);
            smsNotification.Send("Это тестовое уведомление по SMS.");

        }
        public interface INotificationService
        {
            void SendNotification(string message);
        }

        public class EmailService : INotificationService
        {
            public void SendNotification(string message)
            {
                Console.WriteLine($"Отправка Email: {message}");
            }
        }

        public class SmsService : INotificationService
        {
            public void SendNotification(string message)
            {
                Console.WriteLine($"Отправка SMS: {message}");
            }
        }

        public class Notification
        {
            private readonly INotificationService _notificationService;

            public Notification(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }

            public void Send(string message)
            {
                _notificationService.SendNotification(message);
            }
        }
    }
}
















