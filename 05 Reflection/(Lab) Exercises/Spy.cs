using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClassName, params string[] requestedFieldsNames)
    {
        Type hackerClassType = Type.GetType(investigatedClassName);
        FieldInfo[] fields = hackerClassType.GetFields(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        Object hackerInstance = Activator.CreateInstance(hackerClassType, new object[] { });

        var sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {investigatedClassName}");

        foreach (FieldInfo field in fields.Where(f => requestedFieldsNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(hackerInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] fields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"All Private Methods of Class: {investigatedClass}");
        stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            stringBuilder.AppendLine(method.Name);
        }

        return stringBuilder.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        MethodInfo[] allMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic |
                                                       BindingFlags.Public | BindingFlags.Static);

        var sb = new StringBuilder();

        foreach (MethodInfo method in allMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (MethodInfo method in allMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}
