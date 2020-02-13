namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using System;
    using Framework.Disptachers;
    using Framework.Lifecycle.Component;
    using Framework.Lifecycle.Request;
    using IO.Readers;
    using IO.Writers;

    [Component]
    public class Engine : IEngine
    {
        [Inject]
        private IWriter writer;

        [Inject]
        private IReader reader;

        [Inject]
        private IDispatcher dispatcher;

        private const string EndLine = "ILIENCI";

        public void Run()
        {
            string line = this.reader.ReadLine();

            while (line != EndLine)
            {
                string[] tokens = line.Split();
                RequestMethod requestMethod =
                    (RequestMethod) Enum.Parse(typeof(RequestMethod), tokens[0]);
                string uri = tokens[1];
                string result = this.dispatcher.Dispatch(requestMethod, uri);
                this.writer.WriteLine(result);
                line = this.reader.ReadLine();
            }
        }
    }
}
