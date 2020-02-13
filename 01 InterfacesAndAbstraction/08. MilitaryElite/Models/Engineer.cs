using System;
using System.Collections.Generic;

namespace _08.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public IList<Repair> Repairs { get; set; }

        public Engineer(string id, string firstName, string lastName, double salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"{Environment.NewLine}Repairs:" +
                   $"{Environment.NewLine}{string.Join(Environment.NewLine, this.Repairs)}";
            
        }
    }
}
