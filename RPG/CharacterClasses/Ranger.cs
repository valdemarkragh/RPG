using System;
using System.Collections.Generic;

namespace RPG
{
    public class Ranger : Character
    {
        public Ranger(string Name) : base(Name)
        {
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.LEATHER, ArmorTypes.MAIL };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.BOW };
            PrimaryAttributes.Vitality = 8;
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 7;
            PrimaryAttributes.Intelligence = 1;
            CalcSecondaryAttributes();
        }

        public override void LevelUp(int lvl = 1)
        {
            if (lvl < 0)
            {
                throw new ArgumentException();
            }
            Level += lvl;
            PrimaryAttributes.Vitality += 2;
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 5;
            PrimaryAttributes.Intelligence += 1;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            PrimaryAttributes totalAttributes = CalcTotalAttributes();
            double WeaponDps = CalcWeaponDPS();
            Damage = Math.Round(WeaponDps * (1 + (totalAttributes.Dexterity / 100)), 2);
        }
    }
}
