using System;
using System.Collections.Generic;

namespace _08.MilitaryElite
{
    public class StartUp
    {
        public static void Main()
        {
            var soldiers = new List<ISoldier>();

            var engine = new Engine();

            engine.Run(soldiers);
            
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
