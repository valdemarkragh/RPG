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

        /// <summary>
        /// Levels up the character. Default lvl is set to 1.
        /// Adds the class specific attributes to the character when a lvl is given.
        /// If negative number is passed throws ArgumentException.
        /// </summary>
        /// <param name="lvl"></param>
        public abstract void LevelUp(int lvl);

        /// <summary>
        /// Calculates the characters total damage based on weapon and primary attribute.
        /// Sets the characters damage to a number of type double.
        /// </summary>
        public abstract void CalcDamage();

        /// <summary>
        /// Equips the given instance of the armor class.
        /// Catches the custom InvalidArmorException if error occours.
        /// </summary>
        /// <param name="Armor"></param>
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

        /// <summary>
        /// Validates the given instance of the armor class.
        /// The method checks if the AllowedArmor List contains the Type of the armor
        /// and if the characters level is above or equal to the itemlevel of the armor
        /// Throws InvalidWeaponException if the condition is not fulfilled
        /// </summary>
        /// <param name="Armor"></param>
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

        /// <summary>
        /// Equips the given instance of the Weapon class.
        /// Catches the custom InvalidWeaponException if error occours.
        /// </summary>
        /// <param name="Weapon"></param>
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

        /// <summary>
        /// Validates the given instance of the weapon class.
        /// The method checks if the AllowedWeapons List contains the Type of the weapon.
        /// and if the characters level is above or equal to the itemlevel of the weapon.
        /// Throws InvalidWeaponException if the condition is not fulfilled.
        /// </summary>
        /// <param name="Armor"></param>
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

        /// <summary>
        /// Calculates the DPS of the current equipped weapon. 
        /// The WeaponSpeed and the WeaponDamage of the equipped weapon is multiplied and returned.
        /// If theres no weapon equipped the DPS is set to a default calculation.
        /// </summary>
        /// <returns>Returns WeaponDPS</returns>
        public double CalcWeaponDPS()
        {
            double WeaponDPS = 1;

            if (Equipment[ArmorSlots.WEAPON].ItemName != null)
            {
                double WeaponSpeed = Equipment[ArmorSlots.WEAPON].WeaponAttributes.AttackSpeed;
                int WeaponDamage = Equipment[ArmorSlots.WEAPON].WeaponAttributes.Damage;
                WeaponDPS = WeaponDamage * WeaponSpeed;
            }

            return WeaponDPS;
        }

        /// <summary>
        /// Calculates the secondary attributes of the character.
        /// The health is calculated by multiplying the characters vitality with 10.
        /// The armor is calculated by adding the strength and dexterity of the character.
        /// The elemental resistance is equal to the intelligence of the character.
        /// </summary>
        public void CalcSecondaryAttributes()
        {
            SecondaryAttributes.Health = PrimaryAttributes.Vitality * 10;
            SecondaryAttributes.ArmorRating = PrimaryAttributes.Strength + PrimaryAttributes.Dexterity;
            SecondaryAttributes.ElementalResistance = PrimaryAttributes.Intelligence;
        }

        /// <summary>
        /// Adds the new equipped armor attributes to the characters primary attributes.
        /// The method checks if theres already an equipped item on the current slot.
        /// If the condition is met then it proceeds to minus the new armors attributes with the previous armors attributes.
        /// Else it adds the equipped armors attributes.
        /// </summary>
        /// <param name="Armor"></param>
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

        /// <summary>
        /// Prints the characters stats to the console.
        /// </summary>
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
