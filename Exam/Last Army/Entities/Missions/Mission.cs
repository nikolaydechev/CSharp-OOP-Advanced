
    public abstract class Mission : IMission
    {
        protected Mission(double enduranceRequired, double scoreToComplete)
        {
            ////this.Name = name;
            this.EnduranceRequired = enduranceRequired;
            this.ScoreToComplete = scoreToComplete;
            ////this.WearLevelDecrement = wearLevelDecrement;
        }

        public string Name { get; protected set; }

        public double EnduranceRequired { get; }

        public double ScoreToComplete { get; }

        public double WearLevelDecrement { get; protected set; }
    }

