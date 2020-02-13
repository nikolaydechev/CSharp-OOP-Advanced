namespace _02.Blobs
{
    using _02.Blobs.Core;
    using _02.Blobs.Core.IO;
    using _02.Blobs.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            GameActionsExecutor gameActionsExecutor = new GameActionsExecutor();

            Engine engine = new Engine(reader, gameActionsExecutor);
            engine.Run();
        }
    }
}
