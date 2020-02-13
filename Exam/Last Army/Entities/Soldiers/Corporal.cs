
using System;
using System.Collections.Generic;
using Last_Army.Attributes;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;

    public Corporal(string name, int age, double experience, double endurance)
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
            "MachineGun",
            "Helmet",
            "Knife",
        };

    protected override IReadOnlyList<string> WeaponsAllowed { get { return this.weaponsAllowed; } }

    public override double OverallSkill
    {
        get
        {
            return (this.Age + this.Experience) * OverallSkillMiltiplier;
        }
    }

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

