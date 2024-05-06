using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class Location
    {
        public int LocationSk { get; set; }
        public string LocationName { get; set; } = null!;
        public string? LocationDesc { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
