using System;
using System.Collections.Generic;

namespace RPG
{
    public class Mage : Character
    {
        public Mage(string Name) : base(Name)
        {
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.CLOTH };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.STAFF, WeaponTypes.WAND };
            BasePrimaryAttributes.Vitality = 5;
            BasePrimaryAttributes.Strength = 1;
            BasePrimaryAttributes.Dexterity = 1;
            BasePrimaryAttributes.Intelligence = 8;
            CalcSecondaryAttributes();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 3;
            BasePrimaryAttributes.Strength += 1;
            BasePrimaryAttributes.Dexterity += 1;
            BasePrimaryAttributes.Intelligence += 5;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            PrimaryAttributes totalAttributes = CalcTotalAttributes();
            double WeaponDps = CalcWeaponDPS();
            Damage = WeaponDps * (1 + (totalAttributes.Intelligence / 100));
        }
    }
}
