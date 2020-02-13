namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        //private IRepository repository;
        //private IUnitFactory unitFactory;

        protected Command(string[] data)
        {
            this.data = data;
            //this.repository = repository;
            //this.unitFactory = unitFactory;
        }

        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        //protected IRepository Repository
        //{
        //    get { return this.repository; }
        //    set { this.repository = value; }
        //}

        //protected IUnitFactory UnitFactory
        //{
        //    get { return this.unitFactory; }
        //    set { this.unitFactory = value; }
        //}

        public abstract string Execute();
    }
}
