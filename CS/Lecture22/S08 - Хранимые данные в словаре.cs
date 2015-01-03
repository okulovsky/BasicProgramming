using System;
using System.Collections.Generic;
using System.Linq;

using Slide06;

namespace Slide08
{
  

    public class Program
    {
        public static void MainX()
        {
            Dictionary<Node, string> captions = new Dictionary<Node, string>();
            var graph = new Graph(10);
            captions[graph[0]] = "0";
        }
    }
}