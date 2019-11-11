using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessModel;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.EF_MODEL;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {
        private CarDbContext _context;
        public InitController(CarDbContext carDbContext)
        {
            _context = carDbContext;
        }

        // GET api/Init
        [HttpGet]
        public IEnumerable<string> Get()
        {
            CarDbCommand.InitializeDb(_context);
            return new [] {"Ok"};
        }
    }
}
