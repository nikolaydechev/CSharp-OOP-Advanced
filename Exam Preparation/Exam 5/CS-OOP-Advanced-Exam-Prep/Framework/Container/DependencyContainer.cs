namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Lifecycle.Component;
    using Parser;
    using Parser.Strategies;
    using Provider.Type;

    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> components;
        private readonly IDictionary<Type, object> resolvedComponents;
        private readonly IParser parser;
        private readonly ITypeProvider typeProvider;

        private const string InitializeMethod = "Initialize";

        public DependencyContainer(IParser parser, ITypeProvider typeProvider)
        {
            this.parser = parser;
            this.typeProvider = typeProvider;
            this.components = new Dictionary<Type, Type>();
            this.resolvedComponents = new Dictionary<Type, object>();
            this.FillComponents();
        }

        public T Resolve<T>()
        {
            if (!this.components.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException("Cannot map dependency of type "
                    + typeof(T).Name
                    + ". It is not annotated with @Component ");
            }

            T result = default(T);

            if (this.components.ContainsKey(typeof(T)))
            {
                Type resultType = this.components[typeof(T)];
                result = (T)Activator.CreateInstance(resultType);

                this.ResolveDependencies(result);

                return result;
            }

            result = Activator.CreateInstance<T>();

            this.ResolveDependencies(result);

            return result;
        }

        public void RegisterMapping<TFrom>(object to)
        {
            this.resolvedComponents[typeof(TFrom)] = to;
            this.components[typeof(TFrom)] = to.GetType();
        }

        public void ResolveDependencies(object controller)
        {
            FieldInfo[] currentDependencies =
                controller.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(x => x.GetCustomAttributes().Any(attr => attr.GetType() == typeof(InjectAttribute)))
                    .ToArray();

            foreach (FieldInfo currentDependency in currentDependencies)
            {
                Type currentDependencySource = currentDependency.FieldType;

                if (!this.components.ContainsKey(currentDependencySource))
                {
                    throw new InvalidOperationException("Cannot map dependency of type "
                                                        + currentDependencySource.Name +
                                                        ". It is not annotated with @Component ");

                }

                if (!this.resolvedComponents.ContainsKey(currentDependencySource))
                {
                    Type currentDependencyTarget = this.components[currentDependencySource];

                    object currentDependencyInstance = Activator.CreateInstance(currentDependencyTarget);

                    this.resolvedComponents[currentDependencySource] = currentDependencyInstance;

                    currentDependency.SetValue(controller, currentDependencyInstance);

                    this.ResolveDependencies(currentDependencyInstance);

                    MethodInfo initMethod = currentDependencyInstance.GetType().GetMethods(
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                        )
                        .FirstOrDefault(m => m.Name == InitializeMethod && m.GetParameters().Length == 0);

                    initMethod?.Invoke(currentDependencyInstance, new object[0]);
                }
                else
                {
                    object currentDependencyInstance = this.resolvedComponents[currentDependencySource];
                    currentDependency.SetValue(controller, currentDependencyInstance);
                }

               
            }

        }

        public void FillComponents()
        {
            this.parser.Parse(
                new ComponentParserStrategy(this.typeProvider),
                this.components 
                );
        }
    }
}
