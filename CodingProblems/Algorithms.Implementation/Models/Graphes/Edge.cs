using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation.Models.Graphes
{
    public class Edge<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public int Weight { get; set; }
    }
}
