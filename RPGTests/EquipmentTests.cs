using System;
using Xunit;
using RPG;

namespace RPGTests
{
    public class EquipmentTests
    {
        [Fact]
        public void EquipWeapon_EquipHighLvlWeapon_ShouldThrowInvalidWeaponException()
        {
            Warrior warrior = new Warrior("Valdemar");
            Weapon testAxe = new Weapon()
            {
                ItemName = "Common axe",
                ItemLevel = 2,
                ItemSlot = ArmorSlots.WEAPON,
                WeaponType = WeaponTypes.AXE,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(testAxe));
        }

        [Fact]
        public void EquipArmor_EquipHighLvlArmor_ShouldThrowInvalidArmorException()
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
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(testPlateBody));
        }

        [Fact]
        public void EquipWeapon_EquipWrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            Warrior warrior = new Warrior("Valdemar");
            Weapon testBow = new Weapon()
            {
                ItemName = "Common bow",
                ItemLevel = 2,
                ItemSlot = ArmorSlots.WEAPON,
                WeaponType = WeaponTypes.BOW,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(testBow));
        }

        [Fact]
        public void EquipArmor_EquipWrongArmorType_ShouldThrowInvalidArmorException()
        {
            Warrior warrior = new Warrior("Valdemar");
            Armor testClothHead = new Armor()
            {
                ItemName = "Common cloth head armor",
                ItemLevel = 2,
                ItemSlot = ArmorSlots.HEAD,
                ArmorType = ArmorTypes.CLOTH,
                ArmorAttributes = new PrimaryAttributes() { Vitality = 1, Intelligence = 5 }
            };
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(testClothHead));
        }

        [Fact]
        public void EquipWeapon_EquipValidWeapon_ShouldReturnSuccessMessage()
        {
            Warrior warrior = new Warrior("Valdemar");
            Weapon testAxe = new Weapon()
            {
                ItemName = "Common axe",
                ItemLevel = 1,
                ItemSlot = ArmorSlots.WEAPON,
                WeaponType = WeaponTypes.AXE,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };

            Assert.Equal("New weapon equipped!", warrior.EquipWeapon(testAxe));
        }

        [Fact]
        public void EquipArmor_EquipValidArmor_ShouldReturnSuccessMessage()
        {
            Warrior warrior = new Warrior("Valdemar");
            Armor testPlateBody = new Armor()
            {
                ItemName = "Common plate body armor",
                ItemLevel = 1,
                ItemSlot = ArmorSlots.BODY,
                ArmorType = ArmorTypes.PLATE,
                ArmorAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };

            Assert.Equal("New armor equipped!", warrior.EquipArmor(testPlateBody));
        }

        [Fact]
        public void CalcDamage_CalcDamageWithoutWeapon_ShouldReturnDamage()
        {
            Warrior warrior = new Warrior("Valdemar");
            warrior.CalcDamage();

            Assert.Equal(1 * (1 + (5 / 100)), warrior.Damage);
        }

        [Fact]
        public void CalcDamage_CalcDamageWithValidWeapon_ShouldReturnDamage()
        {
            Warrior warrior = new Warrior("Valdemar");
            Weapon testAxe = new Weapon()
            {
                ItemName = "Common axe",
                ItemLevel = 1,
                ItemSlot = ArmorSlots.WEAPON,
                WeaponType = WeaponTypes.AXE,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            warrior.EquipWeapon(testAxe);
            warrior.CalcDamage();

            Assert.Equal((7 * 1.1) * (1 + (5 / 100)), warrior.Damage);
        }

        [Fact]
        public void CalcDamage_CalcDamageWithValidWeaponAndArmor_ShouldReturnDamage()
        {
            Warrior warrior = new Warrior("Valdemar");
            Armor testPlateBody = new Armor()
            {
                ItemName = "Common plate body armor",
                ItemLevel = 1,
                ItemSlot = ArmorSlots.BODY,
                ArmorType = ArmorTypes.PLATE,
                ArmorAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };
            warrior.EquipArmor(testPlateBody);
            Weapon testAxe = new Weapon()
            {
                ItemName = "Common axe",
                ItemLevel = 1,
                ItemSlot = ArmorSlots.WEAPON,
                WeaponType = WeaponTypes.AXE,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            warrior.EquipWeapon(testAxe);
            warrior.CalcDamage();

            Assert.Equal((7 * 1.1) * (1 + ((5 + 1) / 100)), warrior.Damage);
        }
    }
}
