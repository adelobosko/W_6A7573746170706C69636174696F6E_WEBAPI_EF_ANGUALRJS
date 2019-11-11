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
    public class CarPhotosController : ControllerBase
    {
        private CarDbContext _context;
        public CarPhotosController(CarDbContext carDbContext)
        {
            _context = carDbContext;
        }

        // GET api/CarPhotos
        [HttpGet]
        public IEnumerable<UpdateCarPhoto> Get()
        {
            var carPhotos = CarDbCommand.GetCarPhotos(_context);
            var newCarPhotos = carPhotos.Select(photo => new UpdateCarPhoto() { Id = photo.Id, Photo= photo.Photo, CarModelId = photo.CarModelId}).ToList();
            return newCarPhotos;
        }

        // GET api/CarPhotos/guid
        [HttpGet("{guid}")]
        public CarPhoto Get(Guid guid)
        {
            return CarDbCommand.GetCarPhoto(_context, guid);
        }

        // POST api/CarPhotos
        [HttpPost]
        public JsonResult Post([FromBody] NewCarPhoto newCarPhoto)
        {
            CarDbCommand.CreateCarPhoto(_context, newCarPhoto);
            return new JsonResult(null);
        }

        // PUT api/CarPhotos/guid
        [HttpPut("{guid}")]
        public JsonResult Put([FromBody] UpdateCarPhoto newCarPhoto)
        {
            CarDbCommand.UpdateCarPhoto(_context, newCarPhoto);
            return new JsonResult(null);
        }

        // DELETE api/CarPhotos/guid
        [HttpDelete("{guid}")]
        public JsonResult Delete(Guid guid)
        {
            CarDbCommand.DeleteCarPhoto(_context, guid);
            return new JsonResult(null);
        }
    }
}