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
    public class CarBrandsController : ControllerBase
    {
        public CarBrandsController(CarDbContext carDbContext)
        {
            CarDbCommand.IntitializeDb(carDbContext);
        }

        // GET api/carbrands
        [HttpGet]
        public IEnumerable<CarBrand> Get()
        {
            return CarDbCommand.GetCarBrands();
        }

        // GET api/carbrands/guid
        [HttpGet("{guid}")]
        public CarBrand Get(Guid guid)
        {
            return CarDbCommand.GetCarBrand(guid);
        }

        // POST api/carbrands
        [HttpPost]
        public IActionResult Post([FromBody] NewCarBrand newCarBrand)
        {
            return CarDbCommand.CreateCarBrand(newCarBrand);
        }

        // PUT api/carbrands/guid
        [HttpPut("{guid}")]
        public IActionResult Put(Guid guid, [FromBody] NewCarBrand newCarBrand)
        {
            return CarDbCommand.UpdateCarBrand(guid, newCarBrand);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid guid)
        {
            return CarDbCommand.DeleteCarBrand(guid);

        }
    }
}
