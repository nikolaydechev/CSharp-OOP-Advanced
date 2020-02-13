namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Commands;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            var type = assembly.GetTypes().First(t => t.Name.ToLower().Contains(commandName));

            IExecutable commandClassInstance = 
                (IExecutable)Activator.CreateInstance(type, new object[] { data });

            commandClassInstance = this.InjectDependencies(commandClassInstance);

            MethodInfo executeMethod = type.GetMethod("Execute");
            
            string result = (string)executeMethod.Invoke(commandClassInstance, new object[] { });

            return result;
            //string result = string.Empty;
            //switch (commandName)
            //{
            //    case "add":
            //        result = this.AddUnitCommand(data);
            //        break;
            //    case "report":
            //        result = this.ReportCommand(data);
            //        break;
            //    case "fight":
            //        Environment.Exit(0);
            //        break;
            //    default:
            //        throw new InvalidOperationException("Invalid command!");
            //}
            //return result;
        }

        private IExecutable InjectDependencies(IExecutable commandClassInstance)
        {
            FieldInfo[] commandFields = commandClassInstance.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes<InjectAttribute>() != null)
                .ToArray();

            FieldInfo[] engineFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo commandField in commandFields)
            {
                FieldInfo engineField = engineFields
                    .First(f => f.FieldType == commandField.FieldType);

                object valueToInject = engineField.GetValue(this);

                commandField.SetValue(commandClassInstance, valueToInject);
            }

            return commandClassInstance;
        }


        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        //private string AddUnitCommand(string[] data)
        //{
        //    string unitType = data[1];
        //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    this.repository.AddUnit(unitToAdd);
        //    string output = unitType + " added!";
        //    return output;
        //}
    }
}
