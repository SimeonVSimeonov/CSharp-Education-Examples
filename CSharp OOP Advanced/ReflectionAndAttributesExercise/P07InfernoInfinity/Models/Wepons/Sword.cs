namespace P07InfernoInfinity.Models.Wepons
{
    using P07InfernoInfinity.Models.Enums;

    public class Sword : Weapon
    {
        public Sword(WeaponRarity rarity, string name)
            : base(rarity, name, 4, 6, 3)
        {
        }
    }
}
