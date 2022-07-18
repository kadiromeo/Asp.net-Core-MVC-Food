using System;
using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Admin
    {
        public byte Id { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }

    }
}
