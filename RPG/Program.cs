using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Valdemar");
            warrior.LevelUp();
            warrior.CharacterStats();
        }
    }
}
