using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class Menu
    {
        public int? MenuSk { get; set; }
        public int? ApplicationSk { get; set; }
        public string? MenuTitle { get; set; }
        public string? MenuUrl { get; set; }
        public int? ParentSk { get; set; }
        public string? MenuIcon { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
