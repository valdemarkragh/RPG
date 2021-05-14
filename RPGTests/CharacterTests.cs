using System;
using Xunit;
using RPG;

namespace RPGTests
{
    public class CharacterTests
    {
        [Fact]
        public void NewCharacter_CreatingAcharacter_ReturnLvlOfCharacter()
        {
            Warrior warrior = new Warrior("Valdemar");
            Assert.Equal(1, warrior.Level);
        }

        [Fact]
        public void LevelUp_LevelingUpCharacter_ReturnLvlOfCharacter()
        {
            Warrior warrior = new Warrior("Valdemar");
            warrior.LevelUp();
            Assert.Equal(2, warrior.Level);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void LevelUp_LevelingUpCharacterWithZeroOrNegativeNumber_ShouldThrowArgumentException(int lvl)
        {
            Warrior warrior = new Warrior("Valdemar");

            Assert.Throws<ArgumentException>(() => warrior.LevelUp(lvl));
        }

        [Fact]
        public void NewCharacter_BaseStatsSetCorrectlyOnCreation_ReturnBaseStatsOfWarrior()
        {
            Warrior warrior = new Warrior("Valdemar");
            Assert.Equal(10, warrior.BasePrimaryAttributes.Vitality);
            Assert.Equal(5, warrior.BasePrimaryAttributes.Strength);
            Assert.Equal(2, warrior.BasePrimaryAttributes.Dexterity);
            Assert.Equal(1, warrior.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void NewCharacter_BaseStatsSetCorrectlyOnCreation_ReturnBaseStatsOfMage()
        {
            Mage mage = new Mage("Valdemar");
            Assert.Equal(5, mage.BasePrimaryAttributes.Vitality);
            Assert.Equal(1, mage.BasePrimaryAttributes.Strength);
            Assert.Equal(1, mage.BasePrimaryAttributes.Dexterity);
            Assert.Equal(8, mage.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void NewCharacter_BaseStatsSetCorrectlyOnCreation_ReturnBaseStatsOfRanger()
        {
            Ranger ranger = new Ranger("Valdemar");
            Assert.Equal(8, ranger.BasePrimaryAttributes.Vitality);
            Assert.Equal(1, ranger.BasePrimaryAttributes.Strength);
            Assert.Equal(7, ranger.BasePrimaryAttributes.Dexterity);
            Assert.Equal(1, ranger.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void NewCharacter_BaseStatsSetCorrectlyOnCreation_ReturnBaseStatsOfRogue()
        {
            Rogue rogue = new Rogue("Valdemar");
            Assert.Equal(8, rogue.BasePrimaryAttributes.Vitality);
            Assert.Equal(2, rogue.BasePrimaryAttributes.Strength);
            Assert.Equal(6, rogue.BasePrimaryAttributes.Dexterity);
            Assert.Equal(1, rogue.BasePrimaryAttributes.Intelligence);
        }


        [Fact]
        public void LevelUp_IncreasingBaseStatsCorrectlyBasedOnLevel_ReturnBaseStatsOfWarrior()
        {
            Warrior warrior = new Warrior("Valdemar");
            warrior.LevelUp();
            Assert.Equal(15, warrior.BasePrimaryAttributes.Vitality);
            Assert.Equal(8, warrior.BasePrimaryAttributes.Strength);
            Assert.Equal(4, warrior.BasePrimaryAttributes.Dexterity);
            Assert.Equal(2, warrior.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void LevelUp_IncreasingBaseStatsCorrectlyBasedOnLevel_ReturnBaseStatsOfMage()
        {
            Mage mage = new Mage("Valdemar");
            mage.LevelUp();
            Assert.Equal(8, mage.BasePrimaryAttributes.Vitality);
            Assert.Equal(2, mage.BasePrimaryAttributes.Strength);
            Assert.Equal(2, mage.BasePrimaryAttributes.Dexterity);
            Assert.Equal(13, mage.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void LevelUp_IncreasingBaseStatsCorrectlyBasedOnLevel_ReturnBaseStatsOfRanger()
        {
            Ranger ranger = new Ranger("Valdemar");
            ranger.LevelUp();
            Assert.Equal(10, ranger.BasePrimaryAttributes.Vitality);
            Assert.Equal(2, ranger.BasePrimaryAttributes.Strength);
            Assert.Equal(12, ranger.BasePrimaryAttributes.Dexterity);
            Assert.Equal(2, ranger.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void LevelUp_IncreasingBaseStatsCorrectlyBasedOnLevel_ReturnBaseStatsOfRogue()
        {
            Rogue rogue = new Rogue("Valdemar");
            rogue.LevelUp();
            Assert.Equal(11, rogue.BasePrimaryAttributes.Vitality);
            Assert.Equal(3, rogue.BasePrimaryAttributes.Strength);
            Assert.Equal(10, rogue.BasePrimaryAttributes.Dexterity);
            Assert.Equal(2, rogue.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void CalcSecondaryAttributes_IncreasingSecondaryStatsCorrectlyBasedOnLevel_ReturnSecStatsOfWarrior()
        {
            Warrior warrior = new Warrior("Valdemar");
            warrior.LevelUp();
            Assert.Equal(150, warrior.SecondaryAttributes.Health);
            Assert.Equal(12, warrior.SecondaryAttributes.ArmorRating);
            Assert.Equal(2, warrior.SecondaryAttributes.ElementalResistance);
        }
    }
}
