using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class Role
    {
        public int RoleSk { get; set; }
        public int? ReportingTo { get; set; }
        public int? ApplicationSk { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDesc { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
