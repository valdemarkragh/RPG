using System;
using Xunit;
using RPG;

namespace RPGTests
{
    public class CharacterCreationTests
    {
        [Fact]
        public void CreateChar()
        {
            Warrior warrior = new Warrior("Valdemar");
            Assert.Equal(1, warrior.Level);
        }
    }
}
