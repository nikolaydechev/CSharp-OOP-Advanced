using System.Collections.Generic;
using _08.MilitaryElite.Models;

namespace _08.MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        IList<Mission> Missions { get; }
    }
}
