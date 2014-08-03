
using System;
using System.Threading;
delegate void MyAction(ref int value);

class Program
{
    static int n;

    static void Update()
    {
        n++;
    }

    static void MainЧ()
    {
        string str = "asd";
        n = 1;
        Update();
        Console.WriteLine(n);
    }
}
