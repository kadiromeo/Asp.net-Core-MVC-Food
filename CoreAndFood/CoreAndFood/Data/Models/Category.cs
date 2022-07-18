using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Category
    {
        public short Id { get; set; }
        [Required]
        [StringLength(20,ErrorMessage ="Lütfen 20 karakterden fazla karakter girmeyin...!")]
        public string Name { get; set; }
        public List<Food> Foods { get; set; }
    }
}
