using System;
using System.Collections.Generic;

#nullable disable

namespace StationaryServer2.Models.Stationary
{
    public partial class Permission
    {
        public int PermissionsId { get; set; }
        public string PermissionsName { get; set; }
        public string DisplayName { get; set; }
        public int ParentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
