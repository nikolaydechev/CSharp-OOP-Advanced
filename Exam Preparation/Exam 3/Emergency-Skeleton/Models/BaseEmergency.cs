using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Skeleton.Models
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    class BaseEmergency
    {
        private string description;

        private EmergencyLevel emergencyLevel;

        private RegistrationTime registrationTime;

        protected BaseEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime)
        {
            this.Description = description;
            this.emergencyLevel = emergencyLevel;
            this.registrationTime = registrationTime;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public EmergencyLevel Level
        {
            get
            {
                return this.emergencyLevel;
            }
            set
            {
                this.emergencyLevel = value;
            }
        }

        public RegistrationTime Time
        {
            get
            {
                return this.registrationTime;
            }
            set
            {
                this.registrationTime = value;
            }
        }
    }
}
