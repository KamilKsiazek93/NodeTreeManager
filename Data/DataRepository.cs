using NodesTreeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodesTreeManager.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly NodeDbContext _nodeDbContext;
        public DataRepository(NodeDbContext nodeDbContext)
        {
            _nodeDbContext = nodeDbContext;
        }
        public async Task AddNode(Node node)
        {
            await _nodeDbContext.Nodes.AddAsync(node);
            await _nodeDbContext.SaveChangesAsync();
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
