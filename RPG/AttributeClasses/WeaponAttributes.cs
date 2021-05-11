using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class WeaponAttributes
    {
        public int Damage { get; set; }
        public double AttackSpeed { get; set; }

        public WeaponAttributes(int Damage, double AttackSpeed)
        {
            this.Damage = Damage;
            this.AttackSpeed = AttackSpeed;
        }
    }
}
