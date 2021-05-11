using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class SecondaryAttributes
    {
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public int ElementalResistance { get; set; }

        public SecondaryAttributes(PrimaryAttributes PrimaryAttributes)
        {
            Health = PrimaryAttributes.Vitality * 10;
            ArmorRating = PrimaryAttributes.Strength * PrimaryAttributes.Vitality;
            ElementalResistance = PrimaryAttributes.Intelligence;
        }
    }
}
