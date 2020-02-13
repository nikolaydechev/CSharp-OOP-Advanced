namespace _03BarracksFactory.Core.Commands
{
    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute :  Attribute
    {
       
    }
}
