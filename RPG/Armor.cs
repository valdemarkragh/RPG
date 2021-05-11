using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Armor : Item
    {
        public ArmorTypes ArmorType { get; set; }
        public PrimaryAttributes ArmorAttributes { get; set; }
    }
}
