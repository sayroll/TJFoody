using System;
using System.Collections.Generic;

namespace TJFoody.Server.Models
{
    public partial class Cuisine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SellerId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
