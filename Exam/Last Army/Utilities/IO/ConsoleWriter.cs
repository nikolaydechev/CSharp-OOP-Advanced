
    using System;
    using System.Text;

public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        private StringBuilder outputGatherer;

        public ConsoleWriter()
            : this(new StringBuilder())
        {
        }

        public ConsoleWriter(StringBuilder outputGatherer)
        {
            this.OutputGatherer = outputGatherer;
        }

        public StringBuilder OutputGatherer
        {
            get
            {
                return this.outputGatherer;
            }

            private set
            {
                this.outputGatherer = value;
            }
        }

        public void GatherOutput(string outputToGather)
        {
            this.OutputGatherer.AppendLine(outputToGather);
        }

        public void WriteGatheredOutput()
        {
            Console.Write(this.OutputGatherer);
        }
}

