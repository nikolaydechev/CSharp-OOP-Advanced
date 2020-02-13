namespace _02.Blobs.Commands
{
    using System.Collections.Generic;
    using _02.Blobs.Attributes;
    using _02.Blobs.Entities;

    [Alias("attack")]
    public class AttackCommand : Command
    {
        [Inject]
        private Dictionary<string, Blob> blobCollection;

        public AttackCommand(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            string attackerName = this.Data[1];
            string targetName = this.Data[2];

            this.blobCollection[attackerName].Attack(this.blobCollection[targetName]);
        }
    }
}
