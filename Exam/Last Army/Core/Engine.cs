using System;
using Last_Army.Interfaces;

public class Engine : IRunnable
{
    private const string TerminatingCommand = "Enough! Pull back!";

    private IReader reader;
    private IWriter writer;
    private GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        string input;
        while ((input = this.reader.ReadLine()) != TerminatingCommand)
        {
            try
            {
                this.gameController.GiveInputToGameController(input);
            }
            catch (Exception e)
            {
                this.writer.GatherOutput(e.Message);
            }
        }

        this.writer.WriteLine(this.gameController.RequestResult(this.writer.OutputGatherer));
    }
}

