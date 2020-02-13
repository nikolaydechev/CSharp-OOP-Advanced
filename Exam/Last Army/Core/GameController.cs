using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Last_Army.Attributes;
using Last_Army.Interfaces;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionControllerField;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(ISoldierFactory soldierFactory, IMissionFactory missionFactory, IArmy army, IWriter writer)
    {
        this.missionFactory = missionFactory;
        this.soldierFactory = soldierFactory;
        this.Army = army;
        this.WareHouse = new WareHouse(this);
        this.MissionControllerField = new MissionController(army, this.WareHouse);
        this.writer = writer;
    }

    public ISoldierFactory SoldierFactory { get { return this.soldierFactory; } private set { this.soldierFactory = value; } }

    public IArmy Army
    {
        get
        {
            return this.army;
        }
        private set
        {
            this.army = value;
        }
    }

    public IWareHouse WareHouse
    {
        get { return this.wareHouse; }
        private set { this.wareHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return missionControllerField; }
        private set { missionControllerField = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var command = data[0];

        Type typeOfController = this.GetType();
        MethodInfo methodToExecute = typeOfController.GetMethod(command + "Command");

        methodToExecute.Invoke(this, new object[] { data });

    }

    public void MissionCommand(string[] data)
    {
        var type = data[1];
        var scoreToComplete = double.Parse(data[2]);
        IMission currentMission = this.missionFactory.CreateMission(type, scoreToComplete);

        this.writer.GatherOutput(this.MissionControllerField.PerformMission(currentMission).Trim());

    }

    public void SoldierCommand(string[] data)
    {
        if (data.Length == 3)
        {
            string name = data[2];
            this.Army.RegenerateTeam(name);
        }
        else
        {
            string type = data[1];
            string name = data[2];
            int age = int.Parse(data[3]); ;
            double experience = double.Parse(data[4]);
            double endurance = double.Parse(data[5]);

            var soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);
            if (!this.CheckIfSoldierCanJoinTeam(soldier))
            {
                this.writer.GatherOutput(string.Format(OutputMessages.NoWeaponAvailable, type, soldier.Name));
            }
            else
            {
                this.Army.AddSoldier(soldier);

            }
        }
    }

    public void WareHouseCommand(string[] data)
    {
        string name = data[1];
        int number = int.Parse(data[2]);

        this.WareHouse.AddAmmunitions(name, number);

    }

    public string RequestResult(StringBuilder result)
    {
        this.MissionControllerField.FailMissionsOnHold();

        var sb = new StringBuilder();
        sb.AppendLine(result.ToString().Trim());
        sb.AppendLine($"Results:");
        sb.AppendLine($"Successful missions - {this.MissionControllerField.SuccessMissionCounter}");
        sb.AppendLine($"Failed missions - {this.MissionControllerField.FailedMissionCounter}");
        sb.AppendLine($"Soldiers:");
        sb.AppendLine(string.Join(Environment.NewLine, this.Army.Soldiers.OrderByDescending(x => x.OverallSkill)));

        return sb.ToString().Trim();
    }

    ////Checks if all the ammunitions for this type of soldier are available
    private bool CheckIfSoldierCanJoinTeam(ISoldier soldier)
    {
        string exactSoldierTypeName = soldier.GetType().Name;

        Type typeOfSoldier = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(t => t.Name.Equals(exactSoldierTypeName));

        object instance = this.soldierFactory.CreateSoldier(exactSoldierTypeName, soldier.Name, soldier.Age,
            soldier.Experience, soldier.Endurance);

        FieldInfo weaponsAllowedField = typeOfSoldier
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute), true).Length != 0);

        var weaponsAllowedData = (List<string>)weaponsAllowedField.GetValue(instance);

        bool possibleToJoin = true;

        foreach (var weapon in weaponsAllowedData)
        {
            if (!this.WareHouse.Ammunitions.ContainsKey(weapon))
            {
                possibleToJoin = false;
                continue;
            }
            if (soldier.Weapons[weapon] == null && this.WareHouse.Ammunitions[weapon].Count > 0)
            {
                soldier.Weapons[weapon] = this.WareHouse.Ammunitions[weapon][0];
                this.WareHouse.Ammunitions[weapon].RemoveAt(0);
            }
            else
            {
                possibleToJoin = false;
            }

        }

        return possibleToJoin;
    }
    
}
