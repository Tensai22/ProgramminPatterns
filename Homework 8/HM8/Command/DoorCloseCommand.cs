using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8.Command
{
    public class DoorCloseCommand : ICommand
    {
        private Door _door;
        public DoorCloseCommand(Door door) => _door = door;

        public void Execute() => _door.Close();
        public void Undo() => _door.Open();
    }
}
