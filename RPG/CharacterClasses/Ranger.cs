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
            BasePrimaryAttributes.Vitality = 8;
            BasePrimaryAttributes.Strength = 1;
            BasePrimaryAttributes.Dexterity = 7;
            BasePrimaryAttributes.Intelligence = 1;
            CalcSecondaryAttributes();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 2;
            BasePrimaryAttributes.Strength += 1;
            BasePrimaryAttributes.Dexterity += 5;
            BasePrimaryAttributes.Intelligence += 1;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            PrimaryAttributes totalAttributes = CalcTotalAttributes();
            double WeaponDps = CalcWeaponDPS();
            Damage = WeaponDps * (1 + (totalAttributes.Dexterity / 100));
        }
    }
}
