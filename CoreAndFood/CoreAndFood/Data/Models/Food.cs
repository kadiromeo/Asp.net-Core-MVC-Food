using System;
namespace CoreAndFood.Data.Models
{
    public class Food
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Stock { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public short CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
