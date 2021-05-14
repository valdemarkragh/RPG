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
                CharacterPrinter.PrintEquipMessage(warrior.EquipArmor(testPlateBody));
            }
            catch (InvalidArmorException ex)
            {
                CharacterPrinter.PrintEquipMessage(ex.Message);
            }

            CharacterPrinter.PrintCharacterInfo(warrior);
        }
    }
}
