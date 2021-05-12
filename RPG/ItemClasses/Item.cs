using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Item
    {
        public string ItemName { get; set; }
        public int ItemLevel { get; set; }
        public ArmorSlots ItemSlot { get; set; }
        public WeaponAttributes WeaponAttributes { get; set; }

        public Item() { }

        public Item(string ItemName, int ItemLevel, ArmorSlots ItemSlot)
        {
            this.ItemName = ItemName;
            this.ItemLevel = ItemLevel;
            this.ItemSlot = ItemSlot;
        }
    }
}
