using System.Text;

public interface IWriter
{
    void WriteLine(string output);

    void GatherOutput(string outputToGather);

    StringBuilder OutputGatherer { get; }

    void WriteGatheredOutput();
}
