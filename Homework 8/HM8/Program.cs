using HM8.Command;
using HM8.Mediator;
using HM8.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Command
            Light light = new Light();
            Door door = new Door();
            Thermostat thermostat = new Thermostat();

            RemoteControl remote = new RemoteControl();

            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);
            ICommand doorOpen = new DoorOpenCommand(door);
            ICommand doorClose = new DoorCloseCommand(door);
            ICommand tempUp = new TemperatureUpCommand(thermostat);
            ICommand tempDown = new TemperatureDownCommand(thermostat);

            remote.ExecuteCommand(lightOn);
            remote.ExecuteCommand(doorOpen);
            remote.ExecuteCommand(tempUp);

            remote.UndoCommand();
            remote.UndoCommand();
            //TemplateMethod
            Beverage tea = new Tea();
            Beverage coffee = new Coffee();

            Console.WriteLine("Making tea");
            tea.PrepareRecipe();

            Console.WriteLine("\nMaking coffee");
            coffee.PrepareRecipe();
            //Mediator
            IMediator chatRoom = new ChatRoom();

            User user1 = new ConcreteUser(chatRoom, "Bagybek");
            User user2 = new ConcreteUser(chatRoom, "Aisyn");
            User user3 = new ConcreteUser(chatRoom, "Alinur");

            chatRoom.RegisterUser(user1);
            chatRoom.RegisterUser(user2);
            chatRoom.RegisterUser(user3);

            user1.Send("zDarova!");
            user2.Send("Privet!");
            user3.Send("Salam");
        }
    }
}
