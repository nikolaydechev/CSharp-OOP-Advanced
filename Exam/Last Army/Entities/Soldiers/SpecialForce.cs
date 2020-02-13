using System.Collections.Generic;
using System.Text;
using Last_Army.Attributes;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;

    public SpecialForce(string name, int age, double experience, double endurance)
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
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public override double OverallSkill => (this.Age + this.Experience) * OverallSkillMiltiplier;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override void Regenerate()
    {
        this.Endurance += 30 + this.Age;
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
