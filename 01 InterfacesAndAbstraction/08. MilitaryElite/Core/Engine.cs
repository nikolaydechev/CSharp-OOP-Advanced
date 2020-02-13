using System;
using System.Collections.Generic;
using System.Linq;
using _08.MilitaryElite.Models;

namespace _08.MilitaryElite
{
    public class Engine
    {
        private static readonly IList<Private> Privates = new List<Private>();

        public Engine() { }

        public void Run(List<ISoldier> soldiers)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split(' ');

                try
                {
                    switch (inputArgs[0])
                    {
                        case "Private":
                            var @private = SoldierFactory.SoldierFactory.Private(
                                inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]));

                            soldiers.Add(@private);
                            Privates.Add(@private);
                            break;

                        case "LeutenantGeneral":
                            var ids = inputArgs.Skip(5).ToList();
                            var leutenant = SoldierFactory.SoldierFactory.LeutenantGeneral(
                                inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]));

                            foreach (string id in ids)
                            {
                                leutenant.Privates.Add(Privates.First(x => x.Id == id));
                            }

                            soldiers.Add(leutenant);
                            break;

                        case "Engineer":

                            var engineer = SoldierFactory.SoldierFactory.Engineer(
                                inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]), inputArgs[5]);

                            for (int i = 6; i < inputArgs.Length; i += 2)
                            {
                                engineer.Repairs.Add(new Repair(inputArgs[i], int.Parse(inputArgs[i + 1])));
                            }

                            soldiers.Add(engineer);
                            break;

                        case "Commando":
                            var commando = SoldierFactory.SoldierFactory.Commando(
                                inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]), inputArgs[5]);


                            for (int i = 6; i < inputArgs.Length; i += 2)
                            {
                                try
                                {
                                    commando.Missions.Add(new Mission(inputArgs[i], inputArgs[i + 1]));
                                }
                                catch (Exception)
                                {
                                }
                            }

                            soldiers.Add(commando);
                            break;

                        case "Spy":
                            soldiers.Add(
                                SoldierFactory.SoldierFactory.Spy(
                                    inputArgs[1], inputArgs[2], inputArgs[3], int.Parse(inputArgs[4])));
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

