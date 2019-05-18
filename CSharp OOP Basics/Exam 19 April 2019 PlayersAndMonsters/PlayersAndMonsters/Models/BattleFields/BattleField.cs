using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    //TODO: Before the fight, both players get bonus health points from their deck.
    //Attacker attacks first and after that the enemy attacks.
    //If one of the players is dead you should stop the fight.

    public class BattleField : IBattleField
    {
        private ICardRepository cardRepository;

        public BattleField()
        {
            this.cardRepository = new CardRepository();
        }
        
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            BeginnerBonus(attackPlayer);
            BeginnerBonus(enemyPlayer);

            BonusPoints(attackPlayer);
            BonusPoints(enemyPlayer);

            while (!enemyPlayer.IsDead && !attackPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));
            }
        }

        private void BonusPoints(IPlayer player)
        {
            var bonusPoints = player.CardRepository.Cards.Sum(x => x.HealthPoints);
            player.Health += bonusPoints;
        }

        private void BeginnerBonus(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
