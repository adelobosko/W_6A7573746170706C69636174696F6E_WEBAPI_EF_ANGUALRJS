using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.EF_MODEL
{
    public class CarDbContext : DbContext
    {
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarPhoto> CarPhotos { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options)
            : base(options)
        { }
    }
}
