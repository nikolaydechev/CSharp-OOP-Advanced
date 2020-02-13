using System;
using System.Collections.Generic;

namespace _08.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public IList<Mission> Missions { get; }

        public Commando(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public override string ToString()
        {
            string missions = this.Missions.Count > 0 ? "\r\n" +$"{string.Join(Environment.NewLine, this.Missions)}" : "";

            return base.ToString() +
                   $"{Environment.NewLine}Missions:{missions}";
        } 
    }
}
