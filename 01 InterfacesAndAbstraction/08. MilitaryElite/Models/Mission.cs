using System;

namespace _08.MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;
        public string CodeName { get; }
        
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        
        public string State
        {
            get
            {
                return this.state;
            }
            protected set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("State is not valid!");
                }

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
