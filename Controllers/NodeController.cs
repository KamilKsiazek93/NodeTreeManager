using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodesTreeManager.Data;
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
    }
}
