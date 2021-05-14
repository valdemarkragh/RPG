using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {

            Warrior warrior = new Warrior("Valdemar");
            Armor testPlateBody = new Armor()
            {
                ItemName = "Common plate body armor",
                ItemLevel = 2,
                ItemSlot = ArmorSlots.BODY,
                ArmorType = ArmorTypes.PLATE,
                ArmorAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };
            try
            {
                string equipResponse = warrior.EquipArmor(testPlateBody);
                Console.WriteLine(equipResponse);
            }
            catch (InvalidArmorException ex)
            {
                Console.WriteLine(ex.Message);
            }

            CharacterPrinter.PrintCharacterInfo(warrior);
        }
    }
}
