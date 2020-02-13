namespace _01HarestingFields
{
    using System.Reflection;
    using System.Text;
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);
            var sb = new StringBuilder();

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                    case "protected":
                    case "public":
                    case "all":
                        foreach (FieldInfo field in classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                        {
                            if (field.IsPublic && (input == "public" || input == "all"))
                            {
                                sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
                            }
                            else if (field.IsFamily && (input == "protected" || input == "all"))
                            {
                                sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                            }
                            else if (field.IsPrivate && (input == "private" || input == "all"))
                            {
                                sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
