using System;

namespace _09.TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(string[] lights)
        {
            this.Lights = new Light[lights.Length];

            for (int i = 0; i < lights.Length; i++)
            {
                this.Lights[i] = (Light)Enum.Parse(typeof(Light), lights[i]);
            }
        }

        public Light[] Lights { get; set; }

        public void Cycle()
        {
            for (int i = 0; i < this.Lights.Length; i++)
            {
                this.Lights[i] += 1;

                if ((int)this.Lights[i] > 2)
                {
                    this.Lights[i] = 0;
                }
            }
        }

        public override string ToString()
        {
            return $"{string.Join(" ", this.Lights)}";
        }
    }
}
