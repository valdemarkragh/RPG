namespace RPG
{
    public class PrimaryAttributes
    {
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public static PrimaryAttributes operator +(PrimaryAttributes a, PrimaryAttributes b)
        {
            PrimaryAttributes primaryAttributes = new PrimaryAttributes
            {
                Strength = a.Strength + b.Strength,
                Dexterity = a.Dexterity + b.Dexterity,
                Intelligence = a.Intelligence + b.Intelligence,
                Vitality = a.Vitality + b.Vitality
            };

            return primaryAttributes;
        }
    }
}
