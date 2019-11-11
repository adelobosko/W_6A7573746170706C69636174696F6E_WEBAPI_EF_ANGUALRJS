using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.EF_MODEL
{
    public class CarModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public Guid CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public ICollection<CarPhoto> CarPhotos { get; set; }

        public CarModel()
        {
            CarPhotos = new List<CarPhoto>();
        }

    }
}
