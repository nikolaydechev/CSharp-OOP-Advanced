namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string UnitNameSpace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            Type typeUnit = Type.GetType(UnitNameSpace + unitType);

            IUnit unitInstance = (IUnit) Activator.CreateInstance(typeUnit);

            return unitInstance;
            //TODO: implement for Problem 3

            //var assembly = Assembly.GetExecutingAssembly();

            //var type = assembly.GetTypes().First(t => t.Name == unitType);

            //return (IUnit)Activator.CreateInstance(type);


        }
    }
}
