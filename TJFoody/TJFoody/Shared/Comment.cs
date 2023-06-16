using System;
using System.Collections.Generic;

namespace TJFoody.Shared
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string? Phone { get; set; }
        public string? Content { get; set; }
        public string? Time { get; set; }
        public int? ReplyId { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
