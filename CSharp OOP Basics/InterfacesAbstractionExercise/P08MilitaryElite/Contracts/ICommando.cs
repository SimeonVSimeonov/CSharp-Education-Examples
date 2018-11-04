using System.Collections.Generic;

namespace P08MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; set; } 
    }
}
