namespace _02.Blobs.Entities.Attacks.Factory
{
    using System;
    using _02.Blobs.Interfaces;

    public class AttackFactory : CreateAttack
    {
        public override IAttack ProduceAttack(string attackType)
        {
            switch (attackType)
            {
                case "PutridFart": return new PutridFart();
                case "Blobplode": return new Blobplode();
                default: throw new ArgumentException("Invalid type", $"{attackType}");
            }
        }
    }
}
