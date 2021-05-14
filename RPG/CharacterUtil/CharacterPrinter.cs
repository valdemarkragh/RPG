using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class CharacterPrinter
    {
        /// <summary>
        /// Prints the characters stats to the console.
        /// </summary>
        public static void PrintCharacterInfo(Character Character)
        {
            Character.CalcDamage();
            Character.CalcSecondaryAttributes();
            PrimaryAttributes totalAttributes = Character.CalcTotalAttributes();

            StringBuilder charInfo = new StringBuilder();
            charInfo.AppendLine("Character stats: ");
            charInfo.AppendLine("Name: " + Character.Name);
            charInfo.AppendLine("Level: " + Character.Level);
            charInfo.AppendLine("Vitality: " + totalAttributes.Vitality);
            charInfo.AppendLine("Strength: " + totalAttributes.Strength);
            charInfo.AppendLine("Dexterity: " + totalAttributes.Dexterity);
            charInfo.AppendLine("Intelligence: " + totalAttributes.Intelligence);
            charInfo.AppendLine("Health: " + Character.SecondaryAttributes.Health);
            charInfo.AppendLine("Armor Rating: " + Character.SecondaryAttributes.ArmorRating);
            charInfo.AppendLine("Elemental Resistance: " + Character.SecondaryAttributes.ElementalResistance);
            charInfo.AppendLine("DPS: " + Character.Damage);

            Console.WriteLine(charInfo);
        }
    }
}
