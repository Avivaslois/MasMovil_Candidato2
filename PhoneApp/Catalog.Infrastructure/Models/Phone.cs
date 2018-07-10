using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Catalog.Infrastructure.Models
{ 
    public class Phone
    {      
        public int Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string ImgUrl { get; set; }
    }
}
