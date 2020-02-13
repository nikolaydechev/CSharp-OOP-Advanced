namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class RetireUnitCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireUnitCommand(string[] data)
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            
            return this.Repository.RemoveUnit(unitType);
        }
    }
}
