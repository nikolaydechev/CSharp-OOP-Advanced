namespace _02.KingsGambit.Models
{
    using System;
    using _02.KingsGambit.Interfaces;

    public class RoyalGuard : Person, IKillable
    {
        private King king;

        public RoyalGuard(string name, King king)
            : base(name)
        {
            this.king = king;
            king.GetAttacked += KingGetAttacked;

            this.IsAlive = true;
        }

        public bool IsAlive { get; }

        private void KingGetAttacked(object sender, System.EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }

        public void Kill()
        {
            king.GetAttacked -= KingGetAttacked;
        }
    }
}
