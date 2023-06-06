using System;
using System.Collections.Generic;

namespace TJFoody.Server.Models
{
    public partial class User
    {
        public string Phone { get; set; } = null!;
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Avartar { get; set; }
    }
}
