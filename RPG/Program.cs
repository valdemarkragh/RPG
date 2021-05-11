using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Valdemar");
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.LevelUp();
            Armor testPlateChest = new Armor("Common plate", 1, ArmorSlots.BODY, ArmorTypes.PLATE, new PrimaryAttributes(1, 10, 3, 2));
            warrior.EquipArmor(testPlateChest);
            Armor testPlateHelm = new Armor("Common plate", 1, ArmorSlots.HEAD, ArmorTypes.PLATE, new PrimaryAttributes(1, 255, 3, 2));
            warrior.EquipArmor(testPlateHelm);
            Weapon testAxe = new Weapon("Common axe", 1, ArmorSlots.WEAPON, WeaponTypes.AXE, new WeaponAttributes(10, 1.1));
            warrior.EquipWeapon(testAxe);
            warrior.CalcDamage();
        }
    }
}
