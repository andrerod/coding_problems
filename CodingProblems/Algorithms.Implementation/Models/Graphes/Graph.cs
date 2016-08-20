using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation.Models.Graphes
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; }
        public List<Edge<T>> Edges { get; set; }
    }
}
