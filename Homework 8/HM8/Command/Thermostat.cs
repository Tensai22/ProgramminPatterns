using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8.Command
{
    public class Thermostat
    {
        private int temperature = 12;
        public void Increase() => Console.WriteLine($"Temperature is increased to {++temperature}");
        public void Decrease() => Console.WriteLine($"Temperature is decreased to {--temperature}");
    }
}
