using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public abstract class Character
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; }
        protected double Damage { get; set; }
        public PrimaryAttributes PrimaryAttributes { get; set; } = new PrimaryAttributes();
        public PrimaryAttributes BasePrimaryAttributes { get; set; } = new PrimaryAttributes();
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
        }

        /// <summary>
        /// Levels up the character. Default lvl is set to 1.
        /// Adds the class specific attributes to the character when a lvl is given.
        /// If negative number is passed throws ArgumentException.
        /// </summary>
        /// <param name="lvl"></param>
        public virtual void LevelUp(int lvl) {
            try
            {
                if(lvl < 0)
                {
                    throw new ArgumentException();
                }
                Level += lvl;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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
            Weapon weapon = Equipment.Where(item => item.Key == ArmorSlots.WEAPON).Select(item => item.Value as Weapon).FirstOrDefault();

            if (weapon.ItemName != null)
            {
                double WeaponSpeed = weapon.WeaponAttributes.AttackSpeed;
                int WeaponDamage = weapon.WeaponAttributes.Damage;
                WeaponDPS = WeaponDamage * WeaponSpeed;
            }

            return WeaponDPS;
        }

        /// <summary>
        /// Calculates the secondary attributes of the character.
        /// The health is calculated by multiplying the characters totalvitality with 10.
        /// The armor is calculated by adding the totalstrength and totaldexterity of the character.
        /// The elemental resistance is equal to the intelligence of the character.
        /// </summary>
        public void CalcSecondaryAttributes()
        {
            PrimaryAttributes totalAttributes = CalcTotalAttributes();

            SecondaryAttributes.Health = totalAttributes.Vitality * 10;
            SecondaryAttributes.ArmorRating = totalAttributes.Strength + totalAttributes.Dexterity;
            SecondaryAttributes.ElementalResistance = totalAttributes.Intelligence;
        }

        /// <summary>
        /// Calculates the total attributes of the character.
        /// The calculation is based on the primaryattributes and the baseprimaryattributes.
        /// </summary>
        /// <returns>totalAttributes</returns>
        public PrimaryAttributes CalcTotalAttributes()
        {
            PrimaryAttributes primaryAttributes = CalcPrimaryAttributes();
            PrimaryAttributes totalAttributes = BasePrimaryAttributes + primaryAttributes;

            return totalAttributes;
        }

        /// <summary>
        /// Calculates the primary attributes based on the equipped armor.
        /// If an item is equipped in a slot, proceed to add the armor attributes to the calculatedStats object.
        /// </summary>
        /// <returns>calculatedStats</returns>
        public PrimaryAttributes CalcPrimaryAttributes()
        {
            PrimaryAttributes calculatedStats = new PrimaryAttributes();
            List<Armor> armors = Equipment.Where(item => item.Key != ArmorSlots.WEAPON).Select(item => item.Value as Armor).ToList();

            foreach (Armor armor in armors)
            {
                if(armor.ItemName != null)
                {
                    calculatedStats += armor.ArmorAttributes;
                }
            }

            return calculatedStats;
        }

        /// <summary>
        /// Prints the characters stats to the console.
        /// </summary>
        public void CharacterStats()
        {
            CalcDamage();
            CalcSecondaryAttributes();
            PrimaryAttributes totalAttributes = CalcTotalAttributes();

            StringBuilder Stats = new StringBuilder();
            Stats.AppendLine("Character stats: ");
            Stats.AppendLine("Name: " + Name);
            Stats.AppendLine("Level: " + Level);
            Stats.AppendLine("Vitality: " + totalAttributes.Vitality);
            Stats.AppendLine("Strength: " + totalAttributes.Strength);
            Stats.AppendLine("Dexterity: " + totalAttributes.Dexterity);
            Stats.AppendLine("Intelligence: " + totalAttributes.Intelligence);
            Stats.AppendLine("Health: " + SecondaryAttributes.Health);
            Stats.AppendLine("Armor Rating: " + SecondaryAttributes.ArmorRating);
            Stats.AppendLine("Elemental Resistance: " + SecondaryAttributes.ElementalResistance);
            Stats.AppendLine("DPS: " + Damage);

            Console.WriteLine(Stats);
        }
    }
}
