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
            BasePrimaryAttributes.Vitality = 8;
            BasePrimaryAttributes.Strength = 2;
            BasePrimaryAttributes.Dexterity = 6;
            BasePrimaryAttributes.Intelligence = 1;
            CalcSecondaryAttributes();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 3;
            BasePrimaryAttributes.Strength += 1;
            BasePrimaryAttributes.Dexterity += 4;
            BasePrimaryAttributes.Intelligence += 1;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            double WeaponDps = CalcWeaponDPS();
            Damage = Math.Round(WeaponDps * (1 + (PrimaryAttributes.Dexterity / 100)), 2);
        }
    }
}
