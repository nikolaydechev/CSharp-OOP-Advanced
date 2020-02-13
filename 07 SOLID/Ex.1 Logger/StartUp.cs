namespace Ex._1_Logger
{
    using Ex._1_Logger.Entities;
    using Ex._1_Logger.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender =
                new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

        }
    }
}
