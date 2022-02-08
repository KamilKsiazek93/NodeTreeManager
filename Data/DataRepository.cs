using NodesTreeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteNode(List<NodeTree> nodes)
        {
            // _nodeDbContext.RemoveRange(nodes);
            foreach(var node in nodes)
            {
                await RemoveChildNode(node.Id);
            }

            _nodeDbContext.RemoveRange(nodes);
            await _nodeDbContext.SaveChangesAsync();
        }

        private async Task RemoveChildNode(int parentId)
        {
            var nodes = await _nodeDbContext.Nodes.Where(item => item.ParentId == parentId).
                Select(node => new NodeTree() { Id = node.Id, ParentId = node.ParentId, Name = node.Name })
                .OrderBy(node => node.Name).ToListAsync();

            foreach (var node in nodes)
            {
                node.NodesChild = await GetChildNodes(node.Id);
            }

            _nodeDbContext.RemoveRange(nodes);
            await _nodeDbContext.SaveChangesAsync();
        }

        public async Task EditNode(Node node)
        {
            _nodeDbContext.Entry(node).State = EntityState.Modified;
            await _nodeDbContext.SaveChangesAsync();
        }

        public async Task<Node> FindNode(int id)
        {
            return await _nodeDbContext.Nodes.FindAsync(id);
        }

        public async Task<IEnumerable<NodeTree>> GetAllNodes()
        {
            return await GetChildNodes(0);
        }

        public async Task<List<NodeTree>> GetNode(int id)
        {
            return await GetParentNodes(id);
        }

        private async Task<List<NodeTree>> GetParentNodes(int id)
        {
            var nodes = new List<NodeTree>();
            nodes = await _nodeDbContext.Nodes.Where(item => item.Id == id).
                Select(node => new NodeTree() { Id = node.Id, ParentId = node.ParentId, Name = node.Name })
                .ToListAsync();

            foreach (var node in nodes)
            {
                node.NodesChild = await GetChildNodes(node.Id);
            }
            return nodes;
        }

        private async Task<List<NodeTree>> GetChildNodes(int parentId)
        {
            var nodes = new List<NodeTree>();
            nodes = await _nodeDbContext.Nodes.Where(item => item.ParentId == parentId).
                Select(node => new NodeTree() { Id = node.Id, ParentId = node.ParentId, Name = node.Name })
                .OrderBy(node => node.Name).ToListAsync();

            foreach (var node in nodes)
            {
                node.NodesChild = await GetChildNodes(node.Id);
            }

            return nodes;
        }

        public async Task<IEnumerable<NodesNames>> GetNodesNames()
        {
            return await _nodeDbContext.Nodes.Select(node => new NodesNames()
            { Id = node.Id, Name = node.Name }).OrderBy(node => node.Name).ToListAsync();
        }
    }
}
