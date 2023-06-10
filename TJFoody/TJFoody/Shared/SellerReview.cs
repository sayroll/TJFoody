using System;
using System.Collections.Generic;

namespace TJFoody.Shared
{
    public partial class SellerReview
    {
        public int Id { get; set; }
        public int? SellerId { get; set; }
        public string? UserId { get; set; }
        public string? Content { get; set; }
        public string? Date { get; set; }
        public int? Rate { get; set; }
    }
}
