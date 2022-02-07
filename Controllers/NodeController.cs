using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodesTreeManager.Data;
using NodesTreeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodesTreeManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        public NodeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet("nodes")]
        public async Task<IEnumerable<NodeTree>> GetAllNode()
        {
            return await _dataRepository.GetAllNodes();
        }
        
        [HttpGet("nodes/{id}")]
        public async Task<List<NodeTree>> GetChildNode(int id)
        {
            return await _dataRepository.GetNode(id);
        }

        [HttpPost("nodes")]
        public async Task<ActionResult> AddNode(Node node)
        {
            await _dataRepository.AddNode(node);
            return Ok(new { message = "Dodano nowy element" });
        }

        [HttpPut("nodes/{id}")]
        public async Task<ActionResult> EditNode(Node node)
        {
            var newParent = await _dataRepository.GetNode(node.ParentId);
            if(!newParent.Any() && node.ParentId != 0)
            {
                return NotFound(new { message = "Nie można przypisać tego elementu do elementu narzędnego" });
            }
            await _dataRepository.EditNode(node);
            return Ok(new { message = "Zaktualizowano dane" });
        }

        [HttpDelete("nodes/{id}")]
        public async Task<ActionResult> DeleteNode(int id)
        {
            var node = await _dataRepository.GetNode(id);
            if(!node.Any())
            {
                return NotFound(new { message = "Nie znaleziono podanego elementu" });
            }
            await _dataRepository.DeleteNode(node);
            return Ok(new { message = "Usunięto podany element" });
        }
    }
}
