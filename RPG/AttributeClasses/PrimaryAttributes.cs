using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class PrimaryAttributes
    {
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public PrimaryAttributes() { }

        public PrimaryAttributes(int Vitality, int Strength, int Dexterity, int Inteliggence)
        {
            this.Vitality = Vitality;
            this.Strength = Strength;
            this.Dexterity = Dexterity;
            this.Intelligence = Intelligence;
        }
    }
}
