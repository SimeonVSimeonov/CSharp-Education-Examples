using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Factory;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private Stack<Item> items;
        private int rounds;


        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)  
        {
            var inputFaction = args[0];
            var characterType = args[1];
            var name = args[2];

            Character character = this.characterFactory.CreateCharacter(inputFaction, characterType, name);

            characters.Add(character);

            string result = $"{name} joined the party!";
            return result;
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.items.Push(item);
            string result = $"{itemName} added to pool.";
            return result;
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            Character character = GetCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.items.Pop();
            character.Bag.AddItem(item);

            var result = $"{characterName} picked up {item.GetType().Name}!";
            return result;
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = GetCharacter(characterName);
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            var result = $"{character.Name} used {itemName}.";
            return result;
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var giver = GetCharacter(giverName);
            var receiver = GetCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            string result = $"{giverName} used {itemName} on {receiverName}.";
            return result;
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var giver = GetCharacter(giverName);
            var receiver = GetCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);


            string result = $"{giverName} gave {receiverName} {itemName}.";
            return result;
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}," +
                    $" AP: {character.Armor}/{character.BaseArmor}, " +
                    $"Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = GetCharacter(attackerName);
            var receiver = GetCharacter(receiverName);

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            ((Warrior)attacker).Attack(receiver);

            sb.AppendLine(string.Format("{0} attacks {1} for {2} hit points! {1} has {3}/{4} HP and {5}/{6} AP left!",
                attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Health,
                receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = GetCharacter(healerName);
            var healingReceiver = GetCharacter(healingReceiverName);

            if (healer is Warrior)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            ((Cleric)healer).Heal(healingReceiver);

            sb.AppendLine($"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! " +
                $"{healingReceiver.Name} has {healingReceiver.Health} health now!");

            return sb.ToString().TrimEnd();

        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.Where(x => x.IsAlive))
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (characters.Count(x => x.IsAlive)<=1)
            {
                rounds++;
            }

            return sb.ToString().TrimEnd();
            
        }

        public bool IsGameOver()
        {
            if (rounds>1)
            {
                return true;
            }

            return false;
        }

        private Character GetCharacter(string characterName)
        {
            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
