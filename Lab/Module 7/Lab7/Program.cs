using Lab7.Task1;
using Lab7.Task2;
using Lab7.Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Light livingRoomLight = new Light();
            Television tv = new Television();

            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            ICommand tvOn = new TelevisionOnCommand(tv);
            ICommand tvOff = new TelevisionOffCommand(tv);

            RemoteControl remote = new RemoteControl();

            remote.SetCommands(lightOn, lightOff);
            Console.WriteLine("Управление светом:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton();

            remote.SetCommands(tvOn, tvOff);
            Console.WriteLine("\nУправление телевизором:");
            remote.PressOnButton();
            remote.PressOffButton();

            //Task2


            Beverage tea = new Tea();
            Console.WriteLine("Приготовление чая:");
            tea.PrepareRecipe();

            Console.WriteLine();

            Beverage coffee = new Coffee();
            Console.WriteLine("Приготовление кофе:");
            coffee.PrepareRecipe();


            //Task3
            Console.WriteLine("");

            ChatMediator chatMediator = new ChatMediator();

            User user1 = new User(chatMediator, "Алиса");
            User user2 = new User(chatMediator, "Боб");
            User user3 = new User(chatMediator, "Чарли");

            chatMediator.RegisterColleague(user1);
            chatMediator.RegisterColleague(user2);
            chatMediator.RegisterColleague(user3);

            user1.Send("Привет всем!");
            user2.Send("Привет ребята!");
            user3.Send("Всем привет!");
        }
    }
}
