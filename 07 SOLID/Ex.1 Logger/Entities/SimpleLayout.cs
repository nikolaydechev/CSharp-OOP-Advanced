namespace Ex._1_Logger
{
    using Ex._1_Logger.Interfaces;

    public class SimpleLayout : ILayout
    {

        public string DateTime { get; protected set; }

        public string ReportLevel { get; protected set; }

        public string Message { get; protected set; }
    }
}
