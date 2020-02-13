namespace _02.Blobs.Commands
{
    using System.Collections.Generic;
    using System.Text;
    using _02.Blobs.Attributes;
    using _02.Blobs.Core.IO;
    using _02.Blobs.Entities;
    using _02.Blobs.Interfaces;

    [Alias("status")]
    public class StatusCommand : Command
    {
        [Inject]
        private Dictionary<string, Blob> blobCollection;
        [Inject]
        private IWriter writer;

        public StatusCommand(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Blob blob in this.blobCollection.Values)
            {
                sb.AppendLine(blob.ToString());
            }

            this.writer.WriteLine(sb.ToString().Trim());
        }
    }
}
