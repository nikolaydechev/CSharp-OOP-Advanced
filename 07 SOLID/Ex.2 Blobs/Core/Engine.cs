namespace _02.Blobs.Core
{
    using System;
    using _02.Blobs.Interfaces;

    public class Engine
    {
        private IReader reader;
        private GameActionsExecutor gameActionsExecutor;

        public Engine(IReader reader, GameActionsExecutor gameActionsExecutor)
        {
            this.reader = reader;
            this.gameActionsExecutor = gameActionsExecutor;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "drop")
                {
                    break;
                }
                
                this.gameActionsExecutor.InterpretCommand(input);

                this.gameActionsExecutor.RollTurn();
            }
        }
    }
}
