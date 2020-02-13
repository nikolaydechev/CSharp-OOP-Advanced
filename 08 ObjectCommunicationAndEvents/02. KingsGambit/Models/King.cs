namespace _02.KingsGambit.Models
{
    using System;
    using Interfaces;

    public class King : Person, IAttackable
    {
        public event EventHandler GetAttacked;

        public King(string name)
            : base(name)
        {
        }

        public void Attacked()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.GetAttacked?.Invoke(this, EventArgs.Empty);
        }
    }
}
