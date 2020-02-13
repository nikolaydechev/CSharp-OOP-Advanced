using System;

public class Program
{
    public static void Main()
    {
        //EX.1
        //string result = spy.StealFieldInfo("Hacker", "username", "password");
        //EX.2
        //string result = spy.AnalyzeAcessModifiers("Hacker");
        //EX.3
        //string result = spy.RevealPrivateMethods("Hacker");
        Spy spy = new Spy();
        //EX.4
        string result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}
