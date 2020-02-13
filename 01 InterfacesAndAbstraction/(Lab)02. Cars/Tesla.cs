using System;

public class Tesla : ICar, IElectricCar
{
    public string Model { get;}

    public string Color { get; }

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public int Battery { get; }

    public override string ToString()
    {
        return $"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries" + Environment.NewLine +
               $"{this.Start()}" + Environment.NewLine +
               $"{this.Stop()}";
    }
}