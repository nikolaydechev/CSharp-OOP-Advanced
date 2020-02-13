namespace _02.KingsGambit.Models
{
    using System;
    using _02.KingsGambit.Interfaces;

    public class Footman : Person, IKillable
    {
        private King king;

        public Footman(string name, King king)
            : base(name)
        {
            this.king = king;
            king.GetAttacked += this.KingGetAttacked;

            this.IsAlive = true;
        }

        public bool IsAlive { get; }

        private void KingGetAttacked(object sender, System.EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }

        public void Kill()
        {
            this.king.GetAttacked -= this.KingGetAttacked;
        }
    }
}
