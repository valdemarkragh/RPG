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
            BasePrimaryAttributes.Vitality = 10;
            BasePrimaryAttributes.Strength = 5;
            BasePrimaryAttributes.Dexterity = 2;
            BasePrimaryAttributes.Intelligence = 1;
            CalcSecondaryAttributes();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 5;
            BasePrimaryAttributes.Strength += 3;
            BasePrimaryAttributes.Dexterity += 2;
            BasePrimaryAttributes.Intelligence += 1;
            CalcSecondaryAttributes();
        }

        public override void CalcDamage()
        {
            PrimaryAttributes totalAttributes = CalcTotalAttributes();
            double WeaponDps = CalcWeaponDPS();
            Damage = WeaponDps * (1 + (totalAttributes.Strength / 100));
        }
    }
}
