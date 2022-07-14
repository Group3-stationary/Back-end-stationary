using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StationaryServer2.Models.Stationary
{
    public partial class Employee
    {
        public Employee()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public int? Superiors { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}

