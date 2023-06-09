using System;
using System.Collections.Generic;

namespace TJFoody.Shared
{
    public partial class CuisineReview
    {
        public int Id { get; set; }
        public int? CuisineId { get; set; }
        public string? Content { get; set; }
        public int? Rate { get; set; }
        public string? Date { get; set; }
        public int? UserId { get; set; }
    }
}
