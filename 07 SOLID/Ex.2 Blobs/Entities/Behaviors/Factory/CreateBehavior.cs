namespace _02.Blobs.Entities.Behaviors.Factory
{
    using System;
    using _02.Blobs.Interfaces;

    public abstract class CreateBehavior
    {
        public abstract IBehavior ProduceBehavior(string behaviorType);

    }
}
