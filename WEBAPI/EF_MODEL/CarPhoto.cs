using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.EF_MODEL
{
    public class CarPhoto
    {
        public Guid Id { get; set; }
        public string Photo { get; set; }

        public Guid CarModelId { get; set; }

        public CarModel CarModel { get; set; }
    }
}
