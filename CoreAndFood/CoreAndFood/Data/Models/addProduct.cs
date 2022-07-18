using System;
using Microsoft.AspNetCore.Http;

namespace CoreAndFood.Data.Models
{
    public class addProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public short Stock { get; set; }
        public short CategoryId { get; set; }
    }
}
