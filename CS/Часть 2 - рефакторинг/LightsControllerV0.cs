using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphore
{
    static partial class LightsController
    {
        // Очень неудачное название переменной! Почему t? В секундах или милисекундах? И т.д.
        // Переменные должны иметь осмысленные, понятные названия.
        // Для переименования, можно нажать правой кнопкой на имя переменной, и затем Refactor->Rename
        // static void Wait(double t) 
        // { 
        //     Thread.Sleep((int)(t * 1000)); 
        // }

        static void Wait(double timeInSeconds)
        {
            Thread.Sleep((int)(timeInSeconds * 1000));
        }
    }
}