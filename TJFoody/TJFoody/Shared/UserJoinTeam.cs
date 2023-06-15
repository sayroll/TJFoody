using System;
using System.Collections.Generic;

namespace TJFoody.Shared
{
    public partial class UserJoinTeam
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? TeamId { get; set; }
        public string? Time { get; set; }
    }
}
