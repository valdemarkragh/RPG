using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public double Damage { get; set; }
        public int Health { get; set; }
        public PrimaryAttributes PrimaryAttributes { get; set; } = new PrimaryAttributes();
        public SecondaryAttributes SecondaryAttributes { get; set; } = new SecondaryAttributes();
        public List<WeaponTypes> AllowedWeapons { get; set; }
        public List<ArmorTypes> AllowedArmor { get; set; }

        public Dictionary<ArmorSlots, Item> Equipment { get; set; } = new Dictionary<ArmorSlots, Item>
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
        public abstract void CalcDamage();
        public void EquipArmor(Armor Armor)
        {
            try
            {
                ValidateArmor(Armor);
            }
            catch (InvalidArmorException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ValidateArmor(Armor Armor)
        {
            if (AllowedArmor.Contains(Armor.ArmorType) && Level >= Armor.ItemLevel)
            {
                AddArmorAttributes(Armor);
                Equipment[Armor.ItemSlot] = Armor;
                Console.WriteLine("New armor equipped!");
            }
            else
            {
                throw new InvalidWeaponException("You are not able to use this Weapon");
            }
        }
        public void EquipWeapon(Weapon Weapon)
        {
            try
            {
                ValidateWeapon(Weapon);
            }
            catch (InvalidWeaponException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ValidateWeapon(Weapon Weapon)
        {
            if (AllowedWeapons.Contains(Weapon.WeaponType) && Level >= Weapon.ItemLevel)
            {
                Equipment[Weapon.ItemSlot] = Weapon;
                Console.WriteLine("New weapon equipped!");
            }
            else
            {
                throw new InvalidWeaponException("You are not able to use this weapon");
            }
        }

        public double CalcWeaponDPS()
        {
            double WeaponDPS;

            if (Equipment[ArmorSlots.WEAPON].ItemName != null)
            {
                double WeaponSpeed = Equipment[ArmorSlots.WEAPON].WeaponAttributes.AttackSpeed;
                int WeaponDamage = Equipment[ArmorSlots.WEAPON].WeaponAttributes.Damage;
                WeaponDPS = WeaponDamage * WeaponSpeed;
            }
            else
            {
                WeaponDPS = 1 * (1 + (PrimaryAttributes.Strength / 100));
            }

            return WeaponDPS;
        }

        public void CalcSecondaryAttributes()
        {
            SecondaryAttributes.Health = PrimaryAttributes.Vitality * 10;
            SecondaryAttributes.ArmorRating = PrimaryAttributes.Strength + PrimaryAttributes.Dexterity;
            SecondaryAttributes.ElementalResistance = PrimaryAttributes.Intelligence;
        }

        public void AddArmorAttributes(Armor Armor)
        {
            if (Equipment[Armor.ItemSlot].ItemName != null)
            {
                PrimaryAttributes.Vitality += Armor.ArmorAttributes.Vitality - Equipment[Armor.ItemSlot].ArmorAttributes.Vitality;
                PrimaryAttributes.Strength += Armor.ArmorAttributes.Strength - Equipment[Armor.ItemSlot].ArmorAttributes.Strength;
                PrimaryAttributes.Dexterity += Armor.ArmorAttributes.Dexterity - Equipment[Armor.ItemSlot].ArmorAttributes.Dexterity;
                PrimaryAttributes.Intelligence += Armor.ArmorAttributes.Intelligence - Equipment[Armor.ItemSlot].ArmorAttributes.Intelligence;
            }
            else
            {
                PrimaryAttributes.Vitality += Armor.ArmorAttributes.Vitality;
                PrimaryAttributes.Strength += Armor.ArmorAttributes.Strength;
                PrimaryAttributes.Dexterity += Armor.ArmorAttributes.Dexterity;
                PrimaryAttributes.Intelligence += Armor.ArmorAttributes.Intelligence;
            }
            CalcSecondaryAttributes();
        }

        public void CharacterStats()
        {
            CalcDamage();
            StringBuilder Stats = new StringBuilder();
            Stats.AppendLine("Character stats: ");
            Stats.AppendLine("Name: " + Name);
            Stats.AppendLine("Level: " + Level);
            Stats.AppendLine("Vitality: " + PrimaryAttributes.Vitality);
            Stats.AppendLine("Strength: " + PrimaryAttributes.Strength);
            Stats.AppendLine("Dexterity: " + PrimaryAttributes.Dexterity);
            Stats.AppendLine("Intelligence: " + PrimaryAttributes.Intelligence);
            Stats.AppendLine("Health: " + SecondaryAttributes.Health);
            Stats.AppendLine("Armor Rating: " + SecondaryAttributes.ArmorRating);
            Stats.AppendLine("Elemental Resistance: " + SecondaryAttributes.ElementalResistance);
            Stats.AppendLine("DPS: " + Damage);


            Console.WriteLine(Stats);
        }
    }
}
