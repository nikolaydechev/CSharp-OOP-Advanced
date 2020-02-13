namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        private string model;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        private string driver;

        public string Driver
        {
            get { return this.driver; }
            set { this.driver = value; }
        }

        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string PushGas()
        {
            return $"Zadu6avam sA!";
        }

        public string Brakes()
        {
            return $"Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.PushGas()}/{this.Driver}";
        }
    }
}
