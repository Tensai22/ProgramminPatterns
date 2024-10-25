﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8.Command
{
    public class DoorOpenCommand : ICommand
    {
        private Door _door;
        public DoorOpenCommand(Door door) => _door = door;

        public void Execute() => _door.Open();
        public void Undo() => _door.Close();
    }
}