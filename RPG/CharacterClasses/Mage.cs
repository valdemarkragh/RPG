using System;
using System.Collections.Generic;

namespace RPG
{
    class Mage : Character
    {
        public Mage(string Name) : base(Name)
        {
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.CLOTH };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.STAFF, WeaponTypes.WAND };
            PrimaryAttributes.Vitality = 5;
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 1;
            PrimaryAttributes.Intelligence = 8;
            CalcSecondaryAttributes();
        }

        public override void LevelUp(int lvl = 1)
        {
            if (lvl < 0)
            {
                throw new ArgumentException();
            }
            Level += lvl;
            PrimaryAttributes.Vitality += 3;
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 1;
            PrimaryAttributes.Intelligence += 5;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            double WeaponDps = CalcWeaponDPS();
            Damage = Math.Round(WeaponDps * (1 + (PrimaryAttributes.Intelligence / 100)), 2);
        }
    }
}
