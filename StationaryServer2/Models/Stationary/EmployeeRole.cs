using System;
using System.Collections.Generic;

#nullable disable

namespace StationaryServer2.Models.Stationary
{
    public partial class EmployeeRole
    {
        public int EmployeeRolesId { get; set; }
        public string EmployeeId { get; set; }
        public int RoleId { get; set; }
    }
}
