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
        public double Damage { get; protected set; }
        public PrimaryAttributes PrimaryAttributes { get; protected set; } = new PrimaryAttributes();
        public PrimaryAttributes BasePrimaryAttributes { get; protected set; } = new PrimaryAttributes();
        public SecondaryAttributes SecondaryAttributes { get; protected set; } = new SecondaryAttributes();
        protected List<WeaponTypes> AllowedWeapons { get; set; }
        protected List<ArmorTypes> AllowedArmor { get; set; }

        public Dictionary<ArmorSlots, Item> Equipment { get; set; } = new Dictionary<ArmorSlots, Item>
        {
            {ArmorSlots.HEAD, null},
            {ArmorSlots.BODY, null},
            {ArmorSlots.LEGS, null},
            {ArmorSlots.WEAPON, null}
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
        public virtual void LevelUp(int lvl)
        {
            if (lvl <= 0)
            {
                throw new ArgumentException();
            }
            Level += lvl;
        }

        /// <summary>
        /// Calculates the characters total damage based on weapon and primary attribute.
        /// Sets the characters damage to a number of type double.
        /// </summary>
        public abstract void CalcDamage();

        /// <summary>
        /// Equips the given instance of the armor class.
        /// The method checks if the AllowedArmor List contains the Type of the armor
        /// and if the characters level is above or equal to the itemlevel of the armor.
        /// Throws InvalidWeaponException if the condition is not fulfilled.
        /// </summary>
        /// <param name="Armor"></param>
        public string EquipArmor(Armor Armor)
        {
            if (Armor.ItemLevel > Level)
            {
                throw new InvalidArmorException("You are not high enough level to wear this armor");
            }

            if (!AllowedArmor.Contains(Armor.ArmorType))
            {
                throw new InvalidArmorException("You are not able to use this Armor");
            }

            Equipment[Armor.ItemSlot] = Armor;

            return "New armor equipped!";
        }

        /// <summary>
        /// Equips the given instance of the Weapon class.
        /// The method checks if the AllowedWeapons List contains the Type of the weapon.
        /// and if the characters level is above or equal to the itemlevel of the weapon.
        /// Throws InvalidWeaponException if the condition is not fulfilled.
        /// </summary>
        /// <param name="Weapon"></param>
        public string EquipWeapon(Weapon Weapon)
        {
            if (Weapon.ItemLevel > Level)
            {
                throw new InvalidWeaponException("You are not high enough level to wear this weapon");
            }

            if (!AllowedWeapons.Contains(Weapon.WeaponType))
            {
                throw new InvalidWeaponException("You are not able to use this weapon");
            }

            Equipment[Weapon.ItemSlot] = Weapon;

            return "New weapon equipped!";
        }

        /// <summary>
        /// Calculates the DPS of the current equipped weapon. 
        /// The WeaponSpeed and the WeaponDamage of the equipped weapon is multiplied and returned.
        /// If theres no weapon equipped the DPS is set to a default calculation.
        /// </summary>
        /// <returns>Returns WeaponDPS</returns>
        public double CalcWeaponDPS()
        {
            double weaponDPS = 1;
            Weapon weapon = Equipment.Where(item => item.Key == ArmorSlots.WEAPON).Select(item => item.Value as Weapon).FirstOrDefault();

            if (weapon != null)
            {
                double weaponSpeed = weapon.WeaponAttributes.AttackSpeed;
                int weaponDamage = weapon.WeaponAttributes.Damage;
                weaponDPS = weaponDamage * weaponSpeed;
            }

            return weaponDPS;
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
                if (armor != null)
                {
                    calculatedStats += armor.ArmorAttributes;
                }
            }

            return calculatedStats;
        }
    }
}
