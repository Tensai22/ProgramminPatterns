using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Task1
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }
    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }
    public class Light
    {
        public void On()
        {
            Console.WriteLine("Свет включен.");
        }

        public void Off()
        {
            Console.WriteLine("Свет выключен.");
        }
    }
    public class Television
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен.");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен.");
        }
    }
    public class TelevisionOnCommand : ICommand
    {
        private Television _tv;

        public TelevisionOnCommand(Television tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.On();
        }

        public void Undo()
        {
            _tv.Off();
        }
    }

    public class TelevisionOffCommand : ICommand
    {
        private Television _tv;

        public TelevisionOffCommand(Television tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.Off();
        }

        public void Undo()
        {
            _tv.On();
        }
    }
    public class RemoteControl
    {
        private ICommand _onCommand;
        private ICommand _offCommand;

        public void SetCommands(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }

        public void PressOnButton()
        {
            _onCommand.Execute();
        }

        public void PressOffButton()
        {
            _offCommand.Execute();
        }

        public void PressUndoButton()
        {
            _onCommand.Undo();
        }
    }

}
