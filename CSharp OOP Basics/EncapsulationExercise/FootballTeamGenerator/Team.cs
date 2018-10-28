using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Rating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Round(this.players.Select(p => p.Skill()).Sum() / (double)this.players.Count);
        }

        public void AddPayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            bool containsPlayer = this.players.Any(p => p.Name == playerName);
            if (!containsPlayer)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            Player player = this.players.Where(p => p.Name == playerName).First();
            this.players.Remove(player);
        }
    }
}
