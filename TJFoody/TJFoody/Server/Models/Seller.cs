﻿using System;
using System.Collections.Generic;

namespace TJFoody.Server.Models
{
    public partial class Seller
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; }
    }
}