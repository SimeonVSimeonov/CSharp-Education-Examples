﻿using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private CardRepository cardRepository;

        public PlayerFactory()
        {
            this.cardRepository = new CardRepository();
        }

        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            switch (type)
            {
                case "Beginner" :
                    player = new Beginner(cardRepository, username);
                    break;

                case "Advanced":
                    player = new Advanced(cardRepository, username);
                    break;
            }

            return player;
        }
    }
}
