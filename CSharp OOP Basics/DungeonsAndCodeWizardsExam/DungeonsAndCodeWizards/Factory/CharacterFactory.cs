using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Characters;
using System;

namespace DungeonsAndCodeWizards.Factory
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            Character character = null;


            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name, factionResult);
                    break;
                case "Cleric":
                    character = new Cleric(name, factionResult);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
            
            return character;
        }
    }
}
