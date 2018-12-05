﻿using InfernoInfinity.Entities.Effects;

namespace InfernoInfinity.Entities.Weapons
{
    public class Knife : Weapon
    {
        const int minDamage = 3;
        const int maxDamage = 4;

        public Knife(string name, string rarity)
            : base(name, minDamage, maxDamage, new Magic[2], rarity)
        {
        }
    }
}
