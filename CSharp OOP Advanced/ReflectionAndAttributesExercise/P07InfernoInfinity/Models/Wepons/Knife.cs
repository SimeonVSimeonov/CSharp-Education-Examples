namespace P07InfernoInfinity.Models.Wepons
{
    using P07InfernoInfinity.Models.Enums;

    public class Knife : Weapon
    {
        public Knife(WeaponRarity rarity, string name)
            : base(rarity, name, 3, 4, 2)
        {
        }
    }
}
