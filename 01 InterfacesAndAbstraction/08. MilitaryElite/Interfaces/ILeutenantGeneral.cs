using System.Collections.Generic;
using _08.MilitaryElite.Models;

namespace _08.MilitaryElite
{
    public interface ILeutenantGeneral : IPrivate
    {
        IList<Private> Privates { get; }
    }
}
