namespace _02.Blobs.Interfaces
{
    using _02.Blobs.Entities;

    public interface IBehavior
    {
        bool IsTriggered { get; }

        void Trigger(Blob source);

        void ApplyPostTriggerEffect(Blob source);
    }
}