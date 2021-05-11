using System;
using System.Collections.Generic;

namespace RPG
{
    public class Warrior : Character
    {
        public Warrior(string Name) : base(Name)
        {
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.PLATE, ArmorTypes.MAIL };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.AXE, WeaponTypes.HAMMER, WeaponTypes.SWORD };
            PrimaryAttributes.Vitality = 10;
            PrimaryAttributes.Strength = 5;
            PrimaryAttributes.Dexterity = 2;
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
            PrimaryAttributes.Vitality += 5;
            PrimaryAttributes.Strength += 3;
            PrimaryAttributes.Dexterity += 2;
            PrimaryAttributes.Intelligence += 1;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            double WeaponDps = CalcWeaponDPS();
            Damage = Math.Round(WeaponDps * (1 + (PrimaryAttributes.Strength / 100)), 2);
        }
    }
}
