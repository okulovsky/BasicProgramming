using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide09
{
    class Program
    {
        static string unassignedStringVariable;
        static int unassignedIntVariable;

        static void Main()
        {
            int localVariable;
            //Console.WriteLine(localVariable.ToString());
            // так нельзя! Значение переменной неопределено.

            Console.WriteLine(unassignedIntVariable.ToString());
            //так можно. Глобальные переменные инициализированы значением по умолчанию. Для int это 0.

            Console.WriteLine(unassignedStringVariable.ToString());
            //это вызовет ошибку. Значение по умолчанию для string - это null, а не пустая строка.
            //Переменная не инициализирована, и нельзя вызывать ее методы

            Console.WriteLine(unassignedStringVariable);
            //Интересно, что так можно, потому что метод WriteLine проверяет, не является ли 
            //unassignedStringVariable null, и печатает пустую строку, если является.

        }
    }
}