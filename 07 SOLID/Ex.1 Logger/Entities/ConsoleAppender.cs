namespace Ex._1_Logger.Entities
{
    using Ex._1_Logger.Interfaces;

    public class ConsoleAppender : IAppender
    {
        private ILayout simpleLayout;

        public ConsoleAppender(ILayout simpleLayout)
        {
            this.simpleLayout = simpleLayout;
        }
    }
}
