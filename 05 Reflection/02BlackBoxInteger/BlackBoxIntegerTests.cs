namespace _02BlackBoxInteger
{
    using System.Reflection;
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInt);
            // --public constructor--
            //BlackBoxInt bbI = (BlackBoxInt)Activator.CreateInstance(classType, 0);


            // Option 1 (initialize object from a private constructor):
            Type[] paramTypes = new Type[] { typeof(int) };

            var constructor = classType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                null, paramTypes, null);
            BlackBoxInt bbI = (BlackBoxInt)constructor.Invoke(new object[] { 0 });

            //Option 2 (initialize object from a private constructor):
            //Type[] paramTypes = new Type[] { typeof(int) };
            //object[] paramValues = new object[] { 0 };
            //BlackBoxInt bbI = Construct<BlackBoxInt>(paramTypes, paramValues);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputParams = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                int @value = int.Parse(inputParams[1]);
                
                MethodInfo method = classType
                    .GetMethod(inputParams[0], BindingFlags.NonPublic | BindingFlags.Instance);

                method.Invoke(bbI, new object[] { @value });

                FieldInfo currentField = classType
                    .GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                Console.WriteLine(currentField.GetValue(bbI));

            }

        }
        public static T Construct<T>(Type[] paramTypes, object[] paramValues)
        {
            Type t = typeof(T);

            ConstructorInfo ci = t.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, paramTypes, null);

            return (T)ci.Invoke(paramValues);
        }
    }
}
