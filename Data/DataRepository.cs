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

        public async Task DeleteNode(Node node)
        {
            _nodeDbContext.Remove(node);
            await _nodeDbContext.SaveChangesAsync();
        }

        public Task EditNode(Node node)
        {
            throw new NotImplementedException();
        }

        public async Task<Node> FindNode(int id)
        {
            return await _nodeDbContext.Nodes.FindAsync(id);
        }

        public Task<IEnumerable<NodeTree>> GetAllNodes()
        {
            throw new NotImplementedException();
        }
    }
}
