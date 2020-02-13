using System.Collections.Generic;
using _08.MilitaryElite.Models;

namespace _08.MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IList<Repair> Repairs { get; }
    }
}
