﻿using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int HealthPotionWeight = 5;

        public HealthPotion() 
            : base(HealthPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIsAlive(character);
            character.Health += 20;
        }
    }
}
