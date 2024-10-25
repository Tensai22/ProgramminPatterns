using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Light
    {
        public void On() => Console.WriteLine("Light is On");
        public void Off() => Console.WriteLine("Light is Off");
    }

    public class AirConditioner
    {
        public void TurnOn() => Console.WriteLine("Air Conditioner is On");
        public void TurnOff() => Console.WriteLine("Air Conditioner is Off");
    }

    public class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light) => _light = light;

        public void Execute() => _light.On();
        public void Undo() => _light.Off();
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;
        public LightOffCommand(Light light) => _light = light;

        public void Execute() => _light.Off();
        public void Undo() => _light.On();
    }

    public class AirConditionerOnCommand : ICommand
    {
        private AirConditioner _ac;
        public AirConditionerOnCommand(AirConditioner ac) => _ac = ac;

        public void Execute() => _ac.TurnOn();
        public void Undo() => _ac.TurnOff();
    }

    public class AirConditionerOffCommand : ICommand
    {
        private AirConditioner _ac;
        public AirConditionerOffCommand(AirConditioner ac) => _ac = ac;

        public void Execute() => _ac.TurnOff();
        public void Undo() => _ac.TurnOn();
    }
    public class RemoteControl
    {
        private ICommand[] _onCommands;
        private ICommand[] _offCommands;
        private Stack<ICommand> _commandHistory;

        public RemoteControl()
        {
            _onCommands = new ICommand[5];
            _offCommands = new ICommand[5];
            _commandHistory = new Stack<ICommand>();
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            _onCommands[slot] = onCommand;
            _offCommands[slot] = offCommand;
        }

        public void OnButtonPressed(int slot)
        {
            _onCommands[slot]?.Execute();
            _commandHistory.Push(_onCommands[slot]);
        }

        public void OffButtonPressed(int slot)
        {
            _offCommands[slot]?.Execute();
            _commandHistory.Push(_offCommands[slot]);
        }

        public void UndoButtonPressed()
        {
            if (_commandHistory.Count > 0)
            {
                var lastCommand = _commandHistory.Pop();
                lastCommand?.Undo();
            }
        }
    }

    public class MacroCommand : ICommand
    {
        private List<ICommand> _commands;
        public MacroCommand(List<ICommand> commands) => _commands = commands;

        public void Execute() => _commands.ForEach(cmd => cmd.Execute());
        public void Undo() => _commands.ForEach(cmd => cmd.Undo());
    }

}
