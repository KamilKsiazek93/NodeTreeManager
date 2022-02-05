﻿using NodesTreeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodesTreeManager.Data
{
    public interface IDataRepository
    {
        Task<IEnumerable<NodeTree>> GetAllNodes();
        Task<Node> FindNode(int id);
        Task AddNode(Node node);
        Task EditNode(Node node);
        Task DeleteNode(Node node);
    }
}
