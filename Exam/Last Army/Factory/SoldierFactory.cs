
    using System;
    using System.Linq;
    using System.Reflection;

    public class SoldierFactory : ISoldierFactory
    {
        public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
        {
            //Type typeOfSoldier = soldierTypeName.GetType();

            Type type = Assembly.GetExecutingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name.Equals(soldierTypeName, StringComparison.OrdinalIgnoreCase));

            ISoldier soldier = (ISoldier)Activator.CreateInstance(type, name, age, experience, endurance);

            return soldier;
        }

    }
