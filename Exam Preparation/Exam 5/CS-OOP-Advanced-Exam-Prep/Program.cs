﻿namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using System.Reflection;
    using Framework.Container;
    using Framework.Disptachers;
    using Framework.Parser;
    using Provider.Type;

    public class Program
    {
        static void Main()
        {
            ITypeProvider typeProvider = new TypeProvider(Assembly.GetExecutingAssembly());
            IParser parser = new AttributeParser();
            IDependencyContainer container = new DependencyContainer(parser, typeProvider);
            container.RegisterMapping<ITypeProvider>(typeProvider);
            IDispatcher dispatcher = new ControllerDispatcher(parser, container, typeProvider);
            container.RegisterMapping<IDispatcher>(dispatcher);

            IEngine engine = container.Resolve<IEngine>();

            engine.Run();
        }
    }
}
