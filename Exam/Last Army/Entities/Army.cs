using System.Collections.Generic;

public class Army : IArmy
{
    public Army()
    {
        this.SoldierArmy = new Dictionary<string, IList<ISoldier>>();
    }

    public IReadOnlyList<ISoldier> Soldiers
    {
        get
        {
            var list = new List<ISoldier>();
            foreach (var soldierArmyValue in this.SoldierArmy.Values)
            {
                foreach (var soldier in soldierArmyValue)
                {
                    list.Add(soldier);
                }
            }

            return list;
        }
    }
    
    public IDictionary<string, IList<ISoldier>> SoldierArmy { get; set; }

    public void AddSoldier(ISoldier soldier)
    {
        string typeSoldierName = soldier.GetType().Name;
        if (!this.SoldierArmy.ContainsKey(typeSoldierName))
        {
            this.SoldierArmy[typeSoldierName] = new List<ISoldier>();
        }
        this.SoldierArmy[typeSoldierName].Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        if (this.SoldierArmy.ContainsKey(soldierType))
        {
            foreach (var typeSoldier in this.SoldierArmy[soldierType])
            {
                typeSoldier.Regenerate();
            }
        }
    }
}

