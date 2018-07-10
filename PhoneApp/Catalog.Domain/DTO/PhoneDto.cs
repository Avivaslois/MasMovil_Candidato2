using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.DTO
{
    public class PhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string ImgUrl { get; set; }
    }
}
