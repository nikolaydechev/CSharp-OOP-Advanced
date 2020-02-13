using System;

namespace _08.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        protected SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.corps = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() +
                $"{Environment.NewLine}Corps: {this.Corps}";
        }
    }
}
