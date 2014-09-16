
using System;
using System.Threading;
delegate void MyAction(ref int value);
class RTriangle { public double H; public double[] C; public static double Angle; } 

class Program
{
    static void Main()
    {
        var tr1 = new RTriangle();
        tr1.H = 5;
        tr1.C = new double[2];
        tr1.C[0] = 3;
        var tr2 = new RTriangle();
        tr2.H = 10;
        Console.WriteLine(
            RTriangle.Angle);
    }
}
