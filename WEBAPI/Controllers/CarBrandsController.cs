using System;
using System.Collections.Generic;
using System.Linq;
using AccessModel;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.EF_MODEL;

namespace WEBAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : ControllerBase
    {
        private CarDbContext _context;
        public CarBrandsController(CarDbContext carDbContext)
        {
            _context = carDbContext;
        }

        // GET api/carbrands
        [HttpGet]
        public IEnumerable<UpdateCarBrand> Get()
        {
            var carBrands = CarDbCommand.GetCarBrands(_context);
            var newCarBrands = carBrands.Select(brand => new UpdateCarBrand() {Id = brand.Id, Name = brand.Name, Logo = brand.Logo, Describe = brand.Describe}).ToList();
            return newCarBrands;
        }

        // GET api/carbrands/guid
        [HttpGet("{guid}")]
        public CarBrand Get(Guid guid)
        {
            return CarDbCommand.GetCarBrand(_context, guid);
        }

        // POST api/carbrands
        [HttpPost]
        public JsonResult Post([FromBody] NewCarBrand updateCarBrand)
        {
            CarDbCommand.CreateCarBrand(_context, updateCarBrand);
            return new JsonResult(null);
        }

        // PUT api/carbrands/guid
        [HttpPut("{guid}")]
        public JsonResult Put(Guid guid, [FromBody] UpdateCarBrand updateCarBrand)
        {
            CarDbCommand.UpdateCarBrand(_context, updateCarBrand);
            return new JsonResult(null);
        }

        // DELETE api/carbrands/guid
        [HttpDelete("{guid}")]
        public JsonResult Delete(Guid guid)
        {
            CarDbCommand.DeleteCarBrand(_context, guid);
            return new JsonResult(null);
        }
    }
}
