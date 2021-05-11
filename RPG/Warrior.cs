using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Warrior : Character
    {
        public List<WeaponTypes> AllowedWeapons = new List<WeaponTypes> { WeaponTypes.AXE, WeaponTypes.HAMMER, WeaponTypes.SWORD };
        public List<ArmorTypes> AllowedArmor = new List<ArmorTypes> { ArmorTypes.PLATE };
        public Dictionary<string, object> EquippedItems = new Dictionary<string, object>
        {
            {"HEAD", false},
            {"BODY", false},
            {"LEGS", false},
            {"WEAPON", false}
        };
        public Warrior(string Name, PrimaryAttributes PrimaryAttributes) : base(Name, PrimaryAttributes)
        {
            this.PrimaryAttributes.Vitality = 10;
            this.PrimaryAttributes.Strength = 5;
            this.PrimaryAttributes.Dexterity = 2;
            this.PrimaryAttributes.Intelligence = 1;
        }

        public override void LevelUp()
        {
            this.Level += 1;
            this.PrimaryAttributes.Vitality += 5;
            this.PrimaryAttributes.Strength += 3;
            this.PrimaryAttributes.Dexterity += 2;
            this.PrimaryAttributes.Intelligence += 1;
        }

        public override void EquipArmor(Armor Armor)
        {
            if(AllowedArmor.Contains(Armor.ArmorType))
            {
                this.PrimaryAttributes.Vitality += Armor.ArmorAttributes.Vitality;
                this.PrimaryAttributes.Strength += Armor.ArmorAttributes.Strength;
                this.PrimaryAttributes.Dexterity += Armor.ArmorAttributes.Dexterity;
                this.PrimaryAttributes.Intelligence += Armor.ArmorAttributes.Intelligence;
            }
        }

        public override void EquipWeapon(Weapon Weapon)
        {
            if(AllowedWeapons.Contains(Weapon.WeaponType)) {
                this.Damage += Weapon.WeaponAttributes.Damage * (int)Weapon.WeaponAttributes.AttackSpeed;
            }
            
        }

        public override void CalcDamage()
        {
            EquippedItems.
        }
    }
}
