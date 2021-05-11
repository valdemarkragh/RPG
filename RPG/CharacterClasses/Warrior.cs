using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Warrior : Character
    {
        public SecondaryAttributes SecondaryAttributes { get; set; }

        public Warrior(string Name) : base(Name)
        {
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.PLATE };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.AXE, WeaponTypes.HAMMER, WeaponTypes.SWORD };
            PrimaryAttributes.Vitality = 10;
            PrimaryAttributes.Strength = 5;
            PrimaryAttributes.Dexterity = 2;
            PrimaryAttributes.Intelligence = 1;
            SecondaryAttributes = new SecondaryAttributes(PrimaryAttributes);
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
        }

        public override void CalcDamage()
        {
            CalcTotalAttributes();
            if (EquippedItems[ArmorSlots.WEAPON] != null)
            {
                double WeaponSpeed = EquippedItems[ArmorSlots.WEAPON].WeaponAttributes.AttackSpeed;
                int WeaponDamage = EquippedItems[ArmorSlots.WEAPON].WeaponAttributes.Damage;
                int WeaponDPS = (int)WeaponSpeed * WeaponDamage;
                Damage = WeaponDPS * (1 + (PrimaryAttributes.Strength / 100));
                Console.WriteLine(Damage);
            }
            else
            {
                Damage = 1 * (1 + (PrimaryAttributes.Strength / 100));
            }
        }
    }
}
