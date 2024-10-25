using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8.Command
{
    public class TemperatureDownCommand : ICommand
    {
        private Thermostat _thermostat;
        public TemperatureDownCommand(Thermostat thermostat) => _thermostat = thermostat;

        public void Execute() => _thermostat.Decrease();
        public void Undo() => _thermostat.Increase();
    }
}
