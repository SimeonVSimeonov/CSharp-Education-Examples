namespace P07InfernoInfinity.Contracts
{
    using P07InfernoInfinity.Models.Enums;

    public interface IRareWeapon
    {
        WeaponRarity Rarity { get; }
    }
}
