using System;

namespace AccessModel
{
    public class UpdateCarPhoto
    {
        public Guid Id { get; set; }
        public string Photo { get; set; }

        public Guid CarModelId { get; set; }
    }
}