using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class VuUserDetail
    {
        public int UserSk { get; set; }
        public int? ApplicationSk { get; set; }
        public int? DepartmentSk { get; set; }
        public int? DesignationSk { get; set; }
        public int? LocationSk { get; set; }
        public string UserName { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime PasswordExpiry { get; set; }
        public string? ApplicationName { get; set; }
        public string? ApplicationDesc { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string? DepartmentDesc { get; set; }
        public string DesignationName { get; set; } = null!;
        public string? DesignationDesc { get; set; }
        public string LocationName { get; set; } = null!;
        public string? LocationDesc { get; set; }
    }
}
