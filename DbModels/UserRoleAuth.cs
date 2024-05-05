using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class UserRoleAuth
    {
        public int UserRoleSk { get; set; }
        public int? UserSk { get; set; }
        public int? RoleSk { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
    }
}
