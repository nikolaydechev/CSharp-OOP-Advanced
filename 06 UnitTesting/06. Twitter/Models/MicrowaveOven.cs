namespace _06.Twitter.Models
{
    using System;
    using _06.Twitter.Interfaces;

    public class MicrowaveOven : IClient
    {
        private IWriter writer;

        public MicrowaveOven(IWriter writer)
        {
            this.writer = writer;
        }

        public void RetrieveMessage(IMessage message)
        {
            this.writer.WriteLine(message.Content);
            this.RedirectToServer(message);
        }

        private void RedirectToServer(IMessage message)
        {
            this.writer.WriteLine("Redirected to server!");
        }
    }
}
