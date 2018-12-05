namespace P07InfernoInfinity.Models.Wepons
{
    using P07InfernoInfinity.Models.Enums;

    public class Axe : Weapon
    {
        public Axe(WeaponRarity rarity, string name)
            : base(rarity, name, 5, 10, 4)
        {
        }
    }
}
