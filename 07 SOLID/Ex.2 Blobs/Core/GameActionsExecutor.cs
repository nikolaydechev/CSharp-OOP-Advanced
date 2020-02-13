namespace _02.Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Entities;
    using Entities.Attacks.Factory;
    using Entities.Behaviors.Factory;
    using _02.Blobs.Attributes;
    using _02.Blobs.Core.IO;
    using _02.Blobs.Interfaces;

    public class GameActionsExecutor
    {
        private Dictionary<string, Blob> blobCollection;
        private AttackFactory attackFactory;
        private BehaviorFactory behaviorFactory;
        private IWriter writer;

        public GameActionsExecutor()
        {
            this.blobCollection = new Dictionary<string, Blob>();
            this.AttackFactory = new AttackFactory();
            this.BehaviorFactory = new BehaviorFactory();
            this.writer = new Writer();
        }

        public Dictionary<string, Blob> BlobCollection => this.blobCollection;

        public AttackFactory AttackFactory { get { return this.attackFactory; } set { this.attackFactory = value; } }

        public BehaviorFactory BehaviorFactory { get { return this.behaviorFactory; } set { this.behaviorFactory = value; } }

        public void RollTurn()
        {
            foreach (Blob blob in this.blobCollection.Values)
            {
                blob.MoveToNextTurn();
            }
        }

        public void InterpretCommand(string[] input)
        {
            try
            {
                IExecutable command = this.ParseCommand(input);
                command.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private IExecutable ParseCommand(string[] input)
        {
            var command = input[0];

            object[] parametersForConstruction = new object[]
            {
                input
            };

            Type typeOfCommand =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                                       .Where(atr => atr.Equals(command))
                                       .ToArray().Length > 0);

            if (typeOfCommand == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            Type typeOfExecutor = typeof(GameActionsExecutor);

            IExecutable exe = (IExecutable)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfExecutor = typeOfExecutor
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldInfo in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldInfo.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfExecutor.Any(x=>x.FieldType == fieldInfo.FieldType))
                    {
                        fieldInfo.SetValue(exe, fieldsOfExecutor.First(x=>x.FieldType == fieldInfo.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}
