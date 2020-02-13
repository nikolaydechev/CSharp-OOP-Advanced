using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Skeleton.Models
{
    class BaseEmergencyCenter
    {
        private string name;

        private int amountOfMaximumEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.amountOfMaximumEmergencies = amountOfMaximumEmergencies;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int AmountOfMaximumEmergencies
        {
            get
            {
                return this.amountOfMaximumEmergencies;
            }
            set
            {
                this.amountOfMaximumEmergencies = value;
            }
        }

        public abstract Boolean isForRetirement();
    }
}
