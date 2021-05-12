namespace RPG
{
    public class Armor : Item
    {
        public ArmorTypes ArmorType { get; set; }
        public PrimaryAttributes ArmorAttributes { get; set; }
        public Armor() { }
        public Armor(string ItemName, int ItemLevel, ArmorSlots ItemSlot, ArmorTypes ArmorType, PrimaryAttributes ArmorAttributes) : base(ItemName, ItemLevel, ItemSlot)
        {
            this.ArmorType = ArmorType;
            this.ArmorAttributes = ArmorAttributes;
        }
    }
}
