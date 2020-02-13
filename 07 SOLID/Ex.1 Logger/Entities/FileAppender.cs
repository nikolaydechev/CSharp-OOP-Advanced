namespace Ex._1_Logger.Entities
{
    using Ex._1_Logger.Interfaces;

    public class FileAppender : IAppender
    {
        private ILayout simpleLayout;

        public FileAppender(ILayout simpleLayout)
        {
            this.simpleLayout = simpleLayout;
        }
    }
}
