

public class Easy : Mission
    {
        private const double EasyEnduranceRequired = 20;

        public Easy(double scoreToComplete) 
            : base(EasyEnduranceRequired, scoreToComplete)
        {
            this.Name = "Suppression of civil rebellion";
            this.WearLevelDecrement = 20;
        }
    }

