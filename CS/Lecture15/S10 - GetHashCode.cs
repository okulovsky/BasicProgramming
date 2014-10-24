using System;
using System.Collections.Generic;

namespace Slide00
{
    public class Program
    {
        static void MainX()
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.ContainsKey("B");
            
            dictionary.ContainsValue("X");

            dictionary["F"] = "Z";
        }
    }
}