using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide08
{
    class Program
    {

        // Это метод, возвращающий значение типа int, принимающий два аргумента типа double.
        // Его можно называть функцией, но это название не очень распространено.
        // Сигнатура метода - это совокупность последовательности типов аргументов и типа возвращаемого значения 
        static int DivideAndRound(double a, double b)
        {
            // return указывает, какое значение будет возвращено
            return (int)Math.Round(a / b);
        }

        // Это метод, не возвращающий значения. Вместо типа возвращаемого значения стоит void
        static void WriteNumber(int number)
        {
            Console.WriteLine(number);
            
            // return указывается без значения, и его следует опускать
            return; 
        }


        static void MainX()
        {
            WriteNumber(DivideAndRound(10.5, 2.1));
        }
    }
}
