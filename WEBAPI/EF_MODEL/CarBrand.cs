using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.EF_MODEL
{
    public class CarBrand
    {
        public Guid Id { get; set; }
        [StringLength(64)]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Describe { get; set; }

        public ICollection<CarModel> CarModels { get; set; }

        public CarBrand()
        {
            CarModels = new List<CarModel>();
        }
    }
}
