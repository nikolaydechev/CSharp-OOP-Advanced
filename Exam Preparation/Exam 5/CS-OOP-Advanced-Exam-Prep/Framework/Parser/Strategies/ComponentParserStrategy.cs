using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Parser.Strategies
{
    using Lifecycle.Component;
    using Provider.Type;

    public class ComponentParserStrategy : IAttributeParserStrategy<Type, Type>
    {
        private readonly ITypeProvider typeProvider;

        public ComponentParserStrategy(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Parse(IDictionary<Type, Type> result)
        {
            foreach (var componentType in this.typeProvider.GetClassesByAttribute(typeof(ComponentAttribute)))
            {
                foreach (var parent in componentType.GetInterfaces())
                {
                    result.Add(parent, componentType);
                }
            }
        }
    }
}
