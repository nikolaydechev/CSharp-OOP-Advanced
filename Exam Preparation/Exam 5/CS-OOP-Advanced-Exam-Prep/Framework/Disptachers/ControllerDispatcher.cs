namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Disptachers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Container;
    using Lifecycle.Controller;
    using Lifecycle.Request;
    using Parser;
    using Parser.Strategies;
    using Provider.Type;

    public class ControllerDispatcher : IDispatcher
    {
        private readonly IDictionary<RequestMethod, IDictionary<string, ControllerActionPair>>
            controllers;

        private readonly IParser parser;

        private readonly IDependencyContainer container;

        private readonly ITypeProvider typeProvider;

        public ControllerDispatcher(IParser parser, IDependencyContainer container, ITypeProvider typeProvider)
        {
            this.parser = parser;
            this.container = container;
            this.typeProvider = typeProvider;
            this.controllers = new Dictionary<RequestMethod, IDictionary<string, ControllerActionPair>>();
            this.FillControllers();
            this.BuildDependencyGraph();
        }

        public string Dispatch(RequestMethod requestMethod, string uri)
        {
            string[] uriTokens = uri.Split('/');

            IDictionary<string, ControllerActionPair> innerDictionary
                = this.controllers[requestMethod];
            foreach (var regexControllerPair in innerDictionary)
            {
                string regex = regexControllerPair.Key;
                ControllerActionPair controllerAction = regexControllerPair.Value;
                var argumentsMapping = controllerAction.ArgumentsMapping;
                int index = 0;
                object[] argumentsToPass = new object[argumentsMapping.Count];
                if (Regex.IsMatch(uri, regex))
                {
                    foreach (var positionTypesPair in argumentsMapping)
                    {
                        string singleArgument = uriTokens[positionTypesPair.Key];
                        Type typeToCast = positionTypesPair.Value;
                        object argumentToPass = Convert.ChangeType(singleArgument, typeToCast);
                        argumentsToPass[index++] = argumentToPass;
                    }

                    object controller = controllerAction.Controller;
                    MethodInfo method = controllerAction.Action;

                    return (string)method.Invoke(controller, argumentsToPass);
                }
            }

            return null;
        }

        private void FillControllers()
        {
            this.parser.Parse(
                new ControllerParserStrategy(this.typeProvider),
                this.controllers
                );
        }

        private void BuildDependencyGraph()
        {
            foreach (object controller in this.controllers.Values
                   .SelectMany(c => c.Values)
                   .Select(c => c.Controller))
            {
                this.container.ResolveDependencies(controller);
            }
        }
    }
}
