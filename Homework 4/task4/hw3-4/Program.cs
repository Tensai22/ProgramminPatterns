using System;

namespace Name
{
    class Program
    {
        public static void Main(){
            
        }
    }
    public class EmailSender
{
    public void SendEmail(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class SmsSender
{
    public void SendSms(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

public class NotificationService
{
    private EmailSender emailSender = new EmailSender();
    private SmsSender smsSender = new SmsSender();

    public void SendNotification(string message)
    {
        emailSender.SendEmail(message);
        smsSender.SendSms(message);
    }
}

    
}