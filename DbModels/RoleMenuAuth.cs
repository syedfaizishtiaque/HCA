using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class RoleMenuAuth
    {
        public int RoleMenuSk { get; set; }
        public int? RoleSk { get; set; }
        public int? MenuSk { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanView { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
    }
}
