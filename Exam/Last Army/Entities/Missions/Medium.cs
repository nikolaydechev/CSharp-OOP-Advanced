
   

public class Medium : Mission
    {
        private const double MediumEnduranceRequired = 50;

        public Medium(double scoreToComplete)
            : base(MediumEnduranceRequired, scoreToComplete)
        {
            this.Name = "Capturing dangerous criminals";
            this.WearLevelDecrement = 50;
        }
    }

