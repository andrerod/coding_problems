using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation.Models
{

    public class GraphNode
    {
        public IList<GraphNode> Edges { get; set; }

        public object Value { get; set; }

        public GraphNode()
        {
            Edges = new List<GraphNode>();
        }
    }

}
