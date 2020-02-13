namespace _02.Blobs.Entities.Behaviors.Factory
{
    using System;
    using _02.Blobs.Interfaces;

    public class BehaviorFactory : CreateBehavior
    {
        public override IBehavior ProduceBehavior(string behaviorType)
        {
            switch (behaviorType)
            {
                case "Aggressive": return new Aggressive();
                case "Inflated": return new Inflated();
                default: throw new ArgumentException("Invalid type", $"{behaviorType}");
            }
        }
    }
}
