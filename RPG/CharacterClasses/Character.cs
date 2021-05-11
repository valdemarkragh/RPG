using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public PrimaryAttributes PrimaryAttributes { get; set; } = new PrimaryAttributes();
        public List<WeaponTypes> AllowedWeapons { get; set; }
        public List<ArmorTypes> AllowedArmor { get; set; }

        public Dictionary<ArmorSlots, Item> EquippedItems { get; set; } = new Dictionary<ArmorSlots, Item>
        {
            {ArmorSlots.HEAD, new Armor()},
            {ArmorSlots.BODY, new Armor()},
            {ArmorSlots.LEGS, new Armor()},
            {ArmorSlots.WEAPON, new Weapon()}
        };

        public Character(string name)
        {
            Name = name;
            Level = 1;
            Damage = 1;
        }

        public abstract void LevelUp(int lvl);
        public void EquipArmor(Armor Armor)
        {
            if (AllowedArmor.Contains(Armor.ArmorType) && Level >= Armor.ItemLevel)
            {
                EquippedItems[Armor.ItemSlot] = Armor;
                Console.WriteLine("New armor equipped!");
            }
            else
            {
                Console.WriteLine("You are not allowed to equip this armor!");
            }
        }
        public void EquipWeapon(Weapon Weapon)
        {
            if (AllowedWeapons.Contains(Weapon.WeaponType) && Level >= Weapon.ItemLevel)
            {
                EquippedItems[Weapon.ItemSlot] = Weapon;
                Console.WriteLine("New weapon equipped!");
            }
            else
            {
                Console.WriteLine("You are not allowed to equip this weapon!");
            }
        }

        public abstract void CalcDamage();

        public void CalcTotalAttributes()
        {
            foreach (var item in EquippedItems)
            {
                if (item.Value.ItemName != null && item.Value is Armor)
                {
                    PrimaryAttributes.Vitality += item.Value.ArmorAttributes.Vitality;
                    PrimaryAttributes.Strength += item.Value.ArmorAttributes.Strength;
                    PrimaryAttributes.Dexterity += item.Value.ArmorAttributes.Dexterity;
                    PrimaryAttributes.Intelligence += item.Value.ArmorAttributes.Intelligence;
                }
            }
        }
    }
}
