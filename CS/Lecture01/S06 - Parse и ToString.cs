﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide06
{
    class Program
    {
        static void MainX()
        {

            int integerNumber = 12;

            // string text = integerNumber; // Так делать нельзя
            // string text = (string)integerNumber; // Так тоже нельзя. Это не конверсия, а нетривиальная операция, наподобие Math.Round


            string text = integerNumber.ToString(); 
            /* Так можно превратить число в строку.
             * На самом деле, все что угодно можно превратить в строку с помощью ToString().
             * Результат не обязательно вам понравится, но для числовых типов все будет ОК
             */

            integerNumber = int.Parse("234"); 
            /* Перевод строки в числа осуществляется с помощью метода Parse
             * int - всего лишь псевдоним для класса Int32, и у этого класса могут быть собственные методы!
             * Обратите внимание на статический метод int.Parse (вызывается с именем класса) и нестатический integerNumber.ToString() (вызывается с именем переменной).
             */

            // Этот метод зависит от текущей культуры операционной системы. 
            var realNumber = double.Parse("34.56");

            //Вот так этого можно избежать
            realNumber = double.Parse("34.56", CultureInfo.InvariantCulture); 


            int number = int.Parse(Console.ReadLine()); // А вот так осуществляется чтение числа из консоли
        }
    }
}
