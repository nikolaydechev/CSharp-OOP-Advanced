namespace _07.CustomList
{
    public class StartUp
    {
        public static void Main()
        {
            var dataStructure = new GenericDataStructure<string>();

            var command = new CommandInterpreter(dataStructure);
            
            command.ExecuteCommand();
        }
    }
}
