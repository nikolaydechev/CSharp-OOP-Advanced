namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Parser.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Lifecycle;
    using Lifecycle.Controller;
    using Lifecycle.Request;
    using Provider.Type;

    public class ControllerParserStrategy : IAttributeParserStrategy<RequestMethod, IDictionary<string, ControllerActionPair>>
    {
        private readonly ITypeProvider typeProvider;

        public ControllerParserStrategy(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Parse(IDictionary<RequestMethod, IDictionary<string, ControllerActionPair>> result)
        {
            foreach (var controller in this.typeProvider.GetClassesByAttribute(typeof(ControllerAttribute)))
            {
                foreach (var currentMethod in this.typeProvider.GetMethodsByAttribute(controller, typeof(RequestMappingAttribute)))
                {
                    RequestMappingAttribute requestMapping =
                        currentMethod.GetCustomAttribute<RequestMappingAttribute>();
                    RequestMethod requestMethod = requestMapping.Method;
                    string mapping = requestMapping.Value;
                    List<string> mappingTokens = mapping.Split('/').ToList();

                    Dictionary<int, Type> argumentsMapping = new Dictionary<int, Type>();

                    mapping = this.ConvertPlaceholersToRegex(mappingTokens, currentMethod, argumentsMapping, mapping);

                    object controllerInstance = Activator.CreateInstance(controller);

                    ControllerActionPair pair = new ControllerActionPair(controllerInstance, currentMethod,
                        argumentsMapping);

                    if (!result.ContainsKey(requestMethod))
                    {
                        result.Add(requestMethod, new Dictionary<string, ControllerActionPair>());
                    }

                    result[requestMethod].Add(mapping, pair);
                }
            }
        }

        private string ConvertPlaceholersToRegex(List<string> mappingTokens, MethodInfo currentMethod,
            Dictionary<int, Type> argumentsMapping, string mapping)
        {
            for (int i = 0; i < mappingTokens.Count; i++)
            {
                if (mappingTokens[i].StartsWith("{") && mappingTokens[i].EndsWith("}"))
                {
                    foreach (ParameterInfo parameterInfo in currentMethod.GetParameters())
                    {
                        if (
                            parameterInfo.GetCustomAttributes()
                                .All(x => x.GetType() != typeof(UriParameterAttribute)))
                        {
                            continue;
                        }

                        UriParameterAttribute uriParameter =
                            parameterInfo.GetCustomAttribute<UriParameterAttribute>();
                        if (mappingTokens[i].Equals("{" + uriParameter.Value + "}"))
                        {
                            argumentsMapping.Add(i, parameterInfo.ParameterType);


                            mapping = mapping.Replace(mappingTokens[i],
                                parameterInfo.ParameterType == typeof(string) ? "\\w+" : "\\d+");
                            break;
                        }
                    }
                }
            }
            return mapping;
        }
    }
}