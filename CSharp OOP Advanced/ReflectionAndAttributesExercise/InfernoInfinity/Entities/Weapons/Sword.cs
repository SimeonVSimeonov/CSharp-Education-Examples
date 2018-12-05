﻿using InfernoInfinity.Entities.Effects;

namespace InfernoInfinity.Entities.Weapons
{
    public class Sword : Weapon
    {
        const int minDamage = 4;
        const int maxDamage = 6;

        public Sword(string name, string rarity)
            : base(name, minDamage, maxDamage, new Magic[3], rarity)
        {
        }
    }
}
