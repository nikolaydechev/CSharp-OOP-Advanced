namespace _06.Twitter
{
    using _06.Twitter.Interfaces;
    using _06.Twitter.Models;

    class StartUp
    {
        static void Main(string[] args)
        {
            IMessage tweet = new Tweet("test msg");
            IWriter console = new ConsoleWriter();
            IClient microwave = new MicrowaveOven(console);
            microwave.RetrieveMessage(tweet);

        }
    }
}
