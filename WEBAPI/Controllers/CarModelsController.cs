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
        public IEnumerable<UpdateCarModel> Get()
        {
            var carModels = CarDbCommand.GetCarModels(_context);
            var newCarModels = carModels.Select(model => new UpdateCarModel() { Id = model.Id, Name = model.Name, Photo = model.Photo, CarBrandId = model.CarBrand.Id }).ToList();
            return newCarModels;
        }

        // GET api/carmodels/guid
        [HttpGet("{guid}")]
        public CarModel Get(Guid guid)
        {
            return CarDbCommand.GetCarModel(_context, guid);
        }

        // POST api/carmodels
        [HttpPost]
        public JsonResult Post([FromBody] NewCarModel updateCarModel)
        {
            CarDbCommand.CreateCarModel(_context, updateCarModel);
            return new JsonResult(null);
        }

        // PUT api/carmodels/guid
        [HttpPut("{guid}")]
        public JsonResult Put([FromBody] UpdateCarModel updateCarModel)
        {
            CarDbCommand.UpdateCarModel(_context, updateCarModel);
            return new JsonResult(null);
        }

        // DELETE api/carmodels/guid
        [HttpDelete("{guid}")]
        public JsonResult Delete(Guid guid)
        {
            CarDbCommand.DeleteCarModel(_context, guid);
            return new JsonResult(null);
        }
    }
}
