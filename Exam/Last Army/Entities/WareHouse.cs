using System.Collections.Generic;
using System.Linq;
using Last_Army.Interfaces;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private GameController gameController;

    public WareHouse()
        :this(null)
    {
    }

    public WareHouse(GameController gameController)
    {
        this.Ammunitions = new Dictionary<string, IList<IAmmunition>>();
        this.ammunitionFactory = new AmmunitionFactory();
        this.gameController = gameController;
    }

    public IDictionary<string, IList<IAmmunition>> Ammunitions { get; }

    public void EquipArmy(IArmy army)
    {
        List<ISoldier> soldiers = army.Soldiers.ToList();


        foreach (var soldier in soldiers)
        {
            this.EquipSoldier(soldier);
        }
    }

    private void EquipSoldier(ISoldier soldier)
    {
        var soldierWeapons = new Dictionary<string, IAmmunition>();
        foreach (var reservedAmmunition in soldier.Weapons)
        {
            soldierWeapons.Add(reservedAmmunition.Key, reservedAmmunition.Value);
        }

        bool hasAllEquipment = soldier.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (hasAllEquipment)
        {
            return;
        }

        foreach (var weapon in soldierWeapons)
        {
            if (this.Ammunitions[weapon.Key].Count > 0)
            {
                soldier.Weapons[weapon.Key] = this.Ammunitions[weapon.Key][0];
                this.Ammunitions[weapon.Key].RemoveAt(0);
            }
        }
    }
    
    public void AddAmmunitions(string name, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var ammunition = this.ammunitionFactory.CreateAmmunition(name);

            if (!this.Ammunitions.ContainsKey(ammunition.Name))
            {
                this.Ammunitions[ammunition.Name] = new List<IAmmunition>();
            }
            this.Ammunitions[ammunition.Name].Add(ammunition);
        }

    }
}

