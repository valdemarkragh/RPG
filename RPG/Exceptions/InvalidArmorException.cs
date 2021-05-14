﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message)
        {

        }

        public override string Message => "You are not able to equip that armor";
    }
}
