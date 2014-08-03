
using System;
using System.Threading;
delegate void MyAction(ref int value);

class Program
{
    static void Action(ref int value)
    {
        Console.WriteLine("Action sleeps");
        Thread.Sleep(100);
        value = 1;
        Console.WriteLine("Value updated");
        Console.WriteLine("Action sleeps");
        Thread.Sleep(200);
        Console.WriteLine("Action exited");
    }

    static void Main()
    {
        int myVal = 1;
        new MyAction(Action).BeginInvoke(ref myVal, null, null);
        Thread.Sleep(150);
        Console.WriteLine("Value in Main =" + myVal);
        Thread.Sleep(1000);
    }

}