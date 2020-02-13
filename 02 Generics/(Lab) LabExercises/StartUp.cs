using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        //EX.1

        //Box<int> box = new Box<int>();
        //box.Add(1);
        //box.Add(2);
        //box.Add(3);
        //Console.WriteLine(box.Remove());
        //box.Add(4);
        //box.Add(5);
        //Console.WriteLine(box.Remove());

        //EX.2

        //string[] strings = ArrayCreator.Create(5, "Pesho");
        //int[] integers = ArrayCreator.Create(10, 33);

        //EX.3

        Scale<int> scale = new Scale<int>(5, 8);

        Console.WriteLine(scale.GetHavier());
    }

}
