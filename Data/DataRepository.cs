﻿using NodesTreeManager.Models;
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

        public async Task DeleteNode(Node node)
        {
            _nodeDbContext.Remove(node);
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
            List<NodeTree> nodes = new List<NodeTree>();
            nodes = await GetChildNodes(0);
            return nodes;
        }

        private async Task<List<NodeTree>> GetChildNodes(int parentId)
        {
            var nodes = new List<NodeTree>();
            nodes = await _nodeDbContext.Nodes.Where(item => item.ParentId == parentId).
                Select(node => new NodeTree() { Id = node.Id, ParentId = node.ParentId, Name = node.Name })
                .ToListAsync();

            foreach (var node in nodes)
            {
                node.NodesChild = await GetChildNodes(node.Id);
            }

            return nodes;
        }
    }
}
