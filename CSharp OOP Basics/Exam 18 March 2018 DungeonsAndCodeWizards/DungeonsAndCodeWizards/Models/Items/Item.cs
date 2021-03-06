﻿using DungeonsAndCodeWizards.Models.Characters;
using System;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public abstract void AffectCharacter(Character character);

        protected void EnsureIsAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
