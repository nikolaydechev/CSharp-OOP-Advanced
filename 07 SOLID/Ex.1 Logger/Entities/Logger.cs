namespace Ex._1_Logger.Entities
{
    using Ex._1_Logger.Interfaces;

    public class Logger : ILogger
    {
        private IAppender appender;

        public Logger(IAppender consoleAppender)
        {
            this.appender = consoleAppender;
        }
        

        public Logger(IAppender consoleAppender, IAppender fileAppender)
        {
            this.appender = consoleAppender;
            this.appender = fileAppender;
        }
        public void Error(string dateTime, string message)
        {
            throw new System.NotImplementedException();
        }

        public void Info(string dateTime, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
