using System;
using System.Collections.Generic;
using AccessModel;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.EF_MODEL;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private CarDbContext _context;
        public CarModelsController(CarDbContext carDbContext)
        {
            _context = carDbContext;
            CarDbCommand.IntitializeDb(_context);
        }

        // GET api/carmodels
        [HttpGet]
        public IEnumerable<CarModel> Get()
        {
            return CarDbCommand.GetCarModels(_context);
        }

        // GET api/carmodels/guid
        [HttpGet("{guid}")]
        public CarModel Get(Guid guid)
        {
            return CarDbCommand.GetCarModel(_context, guid);
        }

        // POST api/carmodels
        [HttpPost]
        public IActionResult Post([FromBody] NewCarModel newCarModel)
        {
            return CarDbCommand.CreateCarModel(_context, newCarModel);
        }

        // PUT api/carmodels/guid
        [HttpPut("{guid}")]
        public IActionResult Put(Guid guid, [FromBody] NewCarModel newCarModel)
        {
            return CarDbCommand.UpdateCarModel(_context, guid, newCarModel);
        }

        // DELETE api/carmodels/guid
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            return CarDbCommand.DeleteCarModel(_context, guid);

        }
    }
}
