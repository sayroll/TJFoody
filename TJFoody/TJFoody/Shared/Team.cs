using System;
using System.Collections.Generic;

namespace TJFoody.Shared
{
    public partial class Team
    {
        public int TeamId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Tag { get; set; }
        public int? LeaderId { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int? Count { get; set; }
        public string? DeadLine { get; set; }
    }
}
