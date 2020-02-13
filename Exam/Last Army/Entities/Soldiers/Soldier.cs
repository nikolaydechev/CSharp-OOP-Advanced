using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get;protected set; }

    public double Endurance { get; protected set; }
    
    public abstract double OverallSkill { get;  }
    
    public IDictionary<string, IAmmunition> Weapons { get; protected set; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public abstract void Regenerate();

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public virtual void CompleteMission(IMission mission)
    {
        string type = mission.GetType().Name;

        switch (type)
        {
            case "Easy":
                this.Endurance -= 20;
                this.AmmunitionRevision(30);
                this.Experience += mission.EnduranceRequired;
                break;
            case "Medium":
                this.Endurance -= 50;
                this.AmmunitionRevision(50);
                this.Experience += mission.EnduranceRequired;
                break;
            case "Hard":
                this.Endurance -= 80;
                this.AmmunitionRevision(70);
                this.Experience += mission.EnduranceRequired;
                break;
        }
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}