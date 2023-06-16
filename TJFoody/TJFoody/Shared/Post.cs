using System;
using System.Collections.Generic;

namespace TJFoody.Shared
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string? Phone { get; set; }
        public string? Postname { get; set; }
        public string? Content { get; set; }
        public string? Time { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
