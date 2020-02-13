using System;

namespace _09.TrafficLights
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var N = int.Parse(Console.ReadLine());

            var trafficLight = new TrafficLight(input);

            for (int i = 0; i < N; i++)
            {
                trafficLight.Cycle();
                Console.WriteLine(trafficLight);
            }
        }
    }
}
