using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StationaryServer2.Models.Stationary
{
    public partial class Category
    {
        public int CategotyId { get; set; }
        public string CategotyName { get; set; }
        public int? IdParent { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
