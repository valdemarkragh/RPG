using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Weapon : Item
    {
        public WeaponTypes WeaponType { get; set; }
        public Weapon() { }
        public Weapon(string ItemName, int ItemLevel, ArmorSlots ItemSlot, WeaponTypes WeaponType, WeaponAttributes WeaponAttributes) : base(ItemName, ItemLevel, ItemSlot)
        {
            this.WeaponType = WeaponType;
            this.WeaponAttributes = WeaponAttributes;
        }
    }
}
