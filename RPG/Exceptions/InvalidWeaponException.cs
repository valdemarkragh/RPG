using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message)
        {

        }

        public override string Message => "You are not able to equip that weapon";
    }
}
