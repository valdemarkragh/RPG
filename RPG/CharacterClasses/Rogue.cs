using System;
using System.Collections.Generic;

namespace RPG
{
    public class Rogue : Character
    {
        public Rogue(string Name) : base(Name)
        {
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.LEATHER, ArmorTypes.MAIL };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.DAGGER, WeaponTypes.SWORD };
            PrimaryAttributes.Vitality = 8;
            PrimaryAttributes.Strength = 2;
            PrimaryAttributes.Dexterity = 6;
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
            PrimaryAttributes.Vitality += 3;
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 4;
            PrimaryAttributes.Intelligence += 1;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            double WeaponDps = CalcWeaponDPS();
            Damage = Math.Round(WeaponDps * (1 + (PrimaryAttributes.Dexterity / 100)), 2);
        }
    }
}
