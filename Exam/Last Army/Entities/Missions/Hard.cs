
    

public class Hard : Mission
    {
        private const double HardEnduranceRequired = 80;

        public Hard(double scoreToComplete) 
            : base(HardEnduranceRequired, scoreToComplete)
        {
            this.Name = "Disposal of terrorists";
            this.WearLevelDecrement = 70;
        }
    }

