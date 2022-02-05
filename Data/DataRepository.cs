using NodesTreeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodesTreeManager.Data
{
    public class DataRepository : IDataRepository
    {
        public Task AddNode(Node node)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNode(Node node)
        {
            throw new NotImplementedException();
        }

        public Task EditNode(Node node)
        {
            throw new NotImplementedException();
        }

        public Task<Node> FindNode(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NodeTree>> GetAllNodes()
        {
            throw new NotImplementedException();
        }
    }
}
