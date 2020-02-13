namespace _06.Twitter.Models
{
    using System;
    using _06.Twitter.Interfaces;

    public class Tweet : IMessage
    {
        public Tweet(string content)
        {
            if (content == string.Empty)
            {
                throw new ArgumentNullException();
            }

            if (content.Length > 255)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Content = content;
        }

        public string Content { get; }
    }
}
