namespace Ex._1_Logger.Interfaces
{
    public interface ILogger
    {
        void Error(string dateTime, string message);

        void Info(string dateTime, string message);
    }
}
