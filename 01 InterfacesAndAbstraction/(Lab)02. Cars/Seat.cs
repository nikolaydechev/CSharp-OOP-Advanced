﻿using System;

public class Seat : ICar
{
    public string Model { get; }

    public string Color { get; }

    public Seat(string model, string color)
    {
       this.Model = model;
       this.Color = color;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{this.Color} {nameof(Seat)} {this.Model}" + Environment.NewLine +
               $"{this.Start()}" + Environment.NewLine +
               $"{this.Stop()}";
    }
}