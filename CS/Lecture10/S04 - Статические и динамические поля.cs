using System;

namespace Slide04
{
    public class Triangle
    {
        public double[] Sides = new double[3];
        public static double AngleSum = Math.PI;
    }

    public class Program
    {
        static void Main()
        {
            // Создание объекта-треугольника
            var triangle = new Triangle();
            // Обращение к динамическому полю
            triangle.Sides[0] = 1;

            //Обращение к статическому полю
            Console.WriteLine(Triangle.AngleSum);

        }
    }
}