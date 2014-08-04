using System;

namespace Slide06
{
    public class Program
    {
        static void MainX()
        {
            string str = "abc";
            //Если раскомментировать эту строку, возникнет ошибка: строки нельзя модифицировать.
            //Не существует никакого способа изменить состояние конкретной строки.
            //str[0] = 'a';
        }
    }
}