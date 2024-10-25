using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8.Command
{
    public class TemperatureUpCommand : ICommand
    {
        private Thermostat _thermostat;
        public TemperatureUpCommand(Thermostat thermostat) => _thermostat = thermostat;

        public void Execute() => _thermostat.Increase();
        public void Undo() => _thermostat.Decrease();
    }
}
