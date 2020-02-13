namespace _02.Blobs.Commands
{
    using System.Collections.Generic;
    using _02.Blobs.Attributes;
    using _02.Blobs.Core;
    using _02.Blobs.Entities;
    using _02.Blobs.Entities.Attacks.Factory;
    using _02.Blobs.Entities.Behaviors.Factory;

    [Alias("create")]
    public class CreateCommand : Command
    {
        [Inject]
        private Dictionary<string, Blob> blobCollection;
        [Inject]
        private AttackFactory attackFactory;
        [Inject]
        private BehaviorFactory behaviorFactory;

        public CreateCommand(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            var currentBehavior = this.behaviorFactory.ProduceBehavior(this.Data[4]);
            var currentAttack = this.attackFactory.ProduceAttack(this.Data[5]);
            var currentBlob = new Blob(this.Data[1], int.Parse(this.Data[2]), int.Parse(this.Data[3]), currentBehavior,currentAttack);
            this.blobCollection.Add(this.Data[1], currentBlob);
        }
    }
}
