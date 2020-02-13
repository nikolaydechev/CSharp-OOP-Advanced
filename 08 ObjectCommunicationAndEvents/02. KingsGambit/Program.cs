namespace _02.KingsGambit
{
    using System;
    using System.Collections.Generic;
    using _02.KingsGambit.Interfaces;
    using _02.KingsGambit.Models;

    public class Program
    {
        public static void Main()
        {
            var king = new King(Console.ReadLine());
            var listOfSoldiers = new Dictionary<string, IKillable>();


            var guards = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var guard in guards)
            {
                listOfSoldiers.Add(guard, new RoyalGuard(guard, king));
            }

            var footmen = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var footman in footmen)
            {
                listOfSoldiers.Add(footman, new Footman(footman, king));
            }


            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split();
                switch (inputArgs[0])
                {
                    case "Attack":
                        king.Attacked();
                        
                        break;

                    case "Kill":
                        listOfSoldiers[inputArgs[1]].Kill();
                        break;
                }
            }
        }
    }
}
