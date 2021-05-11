using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Armor : Item
    {
        public ArmorTypes ArmorType { get; set; }

        public Armor() { }

        public Armor(string ItemName, int ItemLevel, ArmorSlots ItemSlot, ArmorTypes ArmorType, PrimaryAttributes ArmorAttributes) : base(ItemName, ItemLevel, ItemSlot)
        {
            this.ArmorType = ArmorType;
            this.ArmorAttributes = ArmorAttributes;
        }
    }
}
