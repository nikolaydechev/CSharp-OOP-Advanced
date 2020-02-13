namespace _05.BorderControl
{
    public class Robot : IInhabitant
    {
        private string model;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Id { get; }
    }
}
