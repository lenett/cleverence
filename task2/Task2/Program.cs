
using System;
using System.Threading;
using Task2;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
AsyncCallere12.TestMethod3();


public class AsyncCallere12
{
    public static void TestMethod3()
    {
        EventHandler h = new EventHandler(Wait);
        var ac = new AsyncCaller(h);
        bool completedOK = ac.Invoke(7000, null, EventArgs.Empty);
        Console.WriteLine(completedOK);
    }

    private static void Wait(object? obj, EventArgs eventArgs)
    {
        Thread.Sleep(5000);
    }
}

