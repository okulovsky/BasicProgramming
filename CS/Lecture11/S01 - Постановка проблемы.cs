﻿using System;

namespace Slide01
{
    public class Program
    {
        // Допустим, нам надо отсортировать массив строк и массив чисел.
        // Если метод SortIntArray принимает int[], то никаким способом
        // не получится передать в него string[]
        // В результате, придется писать два метода, практически идентичных
        // и это нарушает принцип DRY
        static void Main()
        {
            SortIntArray(new int[] { 1, 2, 3 });
            //SortIntArray(new string[] { "A", "B", "C" });
            SortStringArray(new string[] { "A", "B", "C" });
        }

        static void SortIntArray(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                    if (array[j] < array[j - 1])
                    {
                        var temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
        }

        static void SortStringArray(string[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        var temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
        }
    }
}