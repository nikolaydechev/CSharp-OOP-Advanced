
using System.Collections.Generic;
using Last_Army.Attributes;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        foreach (string typeOfWeaponName in this.weaponsAllowed)
        {
            this.Weapons.Add(typeOfWeaponName, null);
        }
    }

    [Item]
    private readonly List<string> weaponsAllowed = new List<string>
        {
                "Gun",
                "AutomaticMachine",
                "Helmet",
        };

    public override double OverallSkill
    {
        get
        {
            return (this.Age + this.Experience) * OverallSkillMiltiplier;
        }
    }

    protected override IReadOnlyList<string> WeaponsAllowed { get { return this.weaponsAllowed; } }

    public override void Regenerate()
    {
        this.Endurance += 10 + this.Age;
        if (this.Endurance > 100)
        {
            this.Endurance = 100;
        }
    }

    public override void CompleteMission(IMission mission)
    {
        base.CompleteMission(mission);
    }
}

