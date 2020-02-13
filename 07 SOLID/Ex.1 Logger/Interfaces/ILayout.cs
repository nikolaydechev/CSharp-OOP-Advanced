namespace Ex._1_Logger.Interfaces
{
    public interface ILayout
    {
        string DateTime { get; }

        string ReportLevel { get; }

        string Message { get; }
    }
}
