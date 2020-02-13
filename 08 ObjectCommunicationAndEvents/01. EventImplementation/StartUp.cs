namespace _01.EventImplementation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            
            dispatcher.NameChange += handler.OnDispatcherNameChange;
            
            string input;
            while ((input = Console.ReadLine()) != "End" )
            {
                dispatcher.Name = input;
            }
        }
    }
}
