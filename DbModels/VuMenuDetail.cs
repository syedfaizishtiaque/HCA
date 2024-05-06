using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class VuMenuDetail
    {
        public int UserSk { get; set; }
        public int MenuSk { get; set; }
        public string? MenuTitle { get; set; }
        public string? MenuUrl { get; set; }
        public string? MenuIcon { get; set; }
        public int? ParentSk { get; set; }
        public int? ChildSeq { get; set; }
        public int? ParentSeq { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanView { get; set; }
    }
}
