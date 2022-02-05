using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodesTreeManager.Models
{
    public class NodeTree : Node
    {
        public List<Node> NodesChild { get; set; }
    }
}
