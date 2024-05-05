using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class Application
    {
        public int ApplicationSk { get; set; }
        public int? CompanySk { get; set; }
        public string? ApplicationName { get; set; }
        public string? ApplicationDesc { get; set; }
        public string? ApplicationLogo { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
