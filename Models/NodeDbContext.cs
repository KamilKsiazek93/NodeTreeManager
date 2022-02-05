using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodesTreeManager.Models
{
    public class NodeDbContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }
        public NodeDbContext(DbContextOptions<NodeDbContext> options) : base(options)
        {

        }
    }
}
