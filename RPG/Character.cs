using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public PrimaryAttributes PrimaryAttributes { get; set; }

        public Character(string Name, PrimaryAttributes PrimaryAttributes)
        {
            this.Name = Name;
            this.Level = 1;
            this.Damage = 0;
            this.Health = 0;
            this.PrimaryAttributes = PrimaryAttributes;
        }

        public abstract void LevelUp();
        public abstract void EquipArmor(Armor Armor);
        public abstract void EquipWeapon(Weapon Weapon);

        public abstract void CalcDamage();
    }
}
