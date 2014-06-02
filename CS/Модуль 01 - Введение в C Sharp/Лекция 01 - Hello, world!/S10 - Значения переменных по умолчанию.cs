using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide10
{
    class Program
    {
        static string unassignedStringVariable;
        static int unassignedIntVariable;

        static void MainX()
        {
            int localVariable;
            // localVariable++; 
            // так нельзя! Значение переменной неопределено.

            unassignedIntVariable++; 
            //так можно. Глобальные переменные инициализированы значением по умолчанию. Для int это 0.

            unassignedStringVariable += "a";
            //это вызовет ошибку. Значение по умолчанию для string - это null, а не пустая строка. Его ни с чем складывать нельзя.
        }

    }
}