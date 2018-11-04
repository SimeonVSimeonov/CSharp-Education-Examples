using P08MilitaryElite.Enums;
using System.Collections.Generic;

namespace P08MilitaryElite.Contracts
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {this.Corps}\nMissions:" +
                   $"{(this.Missions.Count == 0 ? "" : "\n  ")}{string.Join("\n  ", this.Missions)}";
        }
    }
}
