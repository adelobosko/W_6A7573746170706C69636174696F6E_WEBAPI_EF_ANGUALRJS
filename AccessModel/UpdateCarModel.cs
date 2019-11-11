using System;

namespace AccessModel
{
    public class UpdateCarModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public Guid CarBrandId { get; set; }
    }
}
