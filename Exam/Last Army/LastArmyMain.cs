using System;
using System.Collections.Generic;
using System.Text;

public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IMissionFactory missionFactory = new MissionFactory();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IArmy army = new Army();

        GameController gameController = new GameController(soldierFactory, missionFactory,army,writer);
        Engine engine = new Engine(reader, writer, gameController);

        engine.Run();
    }
}
