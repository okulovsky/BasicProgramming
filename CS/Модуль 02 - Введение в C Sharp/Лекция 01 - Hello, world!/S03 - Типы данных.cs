﻿//Этот блок using студия подставляет автоматически. Мы не будем его стирать.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide03
{
    class Program
    {
        static void MainX()
        {
            /*
             * Переменная - это именованная область памяти.
             * 
             * Тип переменной - это формат области памяти, определяющий множество возможных значений переменной,     
             *                  и множество допустимых операций над ней
             */

            int integerNumber;
            // так объявляется переменная: тип (int), затем имя (integerNumber)
            
            // так осуществляется присваивание           
            integerNumber = 10;

            // double - основной тип чисел с плавающей точкой. Можно совмещать объявление и присваивание.
            double realNumber = 12.34;

            // float - тип меньшей точности. Суффикс f говорит, что 1.234 - константа типа float, а не double. Используются в графике.
            float floatNumber = 1.234f;

            //long (большие целые числа). Используются в основном для подсчета милисекунд.
            long longIntegerNumber = 3000000000000; 
                                                     
            /* Есть и другие типы данных: short, decimal, и т.д.
             * Но, в основном, для чисел вы будете пользоваться int и double, иногда - long и float
             */
        }
    }
}
