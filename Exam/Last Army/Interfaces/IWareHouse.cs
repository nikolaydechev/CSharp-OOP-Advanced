namespace Last_Army.Interfaces
{
    using System.Collections.Generic;

    public interface IWareHouse
    {
        void EquipArmy(IArmy army);

        IDictionary<string, IList<IAmmunition>> Ammunitions { get; }

        void AddAmmunitions(string ammunition, int count);
    }
}
