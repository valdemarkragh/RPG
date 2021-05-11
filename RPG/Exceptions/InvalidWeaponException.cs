using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message)
        {

        }
    }
}
