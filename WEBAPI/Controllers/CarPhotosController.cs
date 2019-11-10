using System;
using System.Collections.Generic;
using AccessModel;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.EF_MODEL;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPhotosController : ControllerBase
    {
        private CarDbContext _context;
        public CarPhotosController(CarDbContext carDbContext)
        {
            _context = carDbContext;
            CarDbCommand.IntitializeDb(_context);
        }

        // GET api/CarPhotos
        [HttpGet]
        public IEnumerable<CarPhoto> Get()
        {
            return CarDbCommand.GetCarPhotos(_context);
        }

        // GET api/CarPhotos/guid
        [HttpGet("{guid}")]
        public CarPhoto Get(Guid guid)
        {
            return CarDbCommand.GetCarPhoto(_context, guid);
        }

        // POST api/CarPhotos
        [HttpPost]
        public IActionResult Post([FromBody] NewCarPhoto newCarPhoto)
        {
            return CarDbCommand.CreateCarPhoto(_context, newCarPhoto);
        }

        // PUT api/CarPhotos/guid
        [HttpPut("{guid}")]
        public IActionResult Put(Guid guid, [FromBody] NewCarPhoto newCarPhoto)
        {
            return CarDbCommand.UpdateCarPhoto(_context, guid, newCarPhoto);
        }

        // DELETE api/CarPhotos/guid
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            return CarDbCommand.DeleteCarPhoto(_context, guid);

        }
    }
}