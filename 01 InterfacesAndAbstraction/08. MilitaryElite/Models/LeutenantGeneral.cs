using System;
using System.Collections.Generic;

namespace _08.MilitaryElite.Models
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public IList<Private> Privates { get; set; }

        public LeutenantGeneral(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }

        public override string ToString()
        {
            var privates = this.Privates.Count > 0 
                ? $"  {string.Join(Environment.NewLine + "  ", this.Privates)}" 
                : "";

            return base.ToString() +
                   $"{Environment.NewLine}Privates:" +
                   $"{Environment.NewLine}{privates}";
        }

    }
}
