using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public string PartName { get; }
        public int WorkedHours { get; }

        public Repair(string partName, int workedHours)
        {
            this.PartName = partName;
            this.WorkedHours = workedHours;
        }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
        }
    }
}
