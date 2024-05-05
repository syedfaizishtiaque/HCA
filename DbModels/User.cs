using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class User
    {
        public int UserSk { get; set; }
        public int? ApplicationSk { get; set; }
        public int? LocationSk { get; set; }
        public int? DepartmentSk { get; set; }
        public int? DesignationSk { get; set; }
        public string UserName { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime PasswordExpiry { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
