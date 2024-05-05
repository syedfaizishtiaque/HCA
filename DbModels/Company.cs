using System;
using System.Collections.Generic;

namespace HCA.DbModels
{
    public partial class Company
    {
        public int CompanySk { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyLetterCode { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;
        public string CompanyLogo { get; set; } = null!;
        public string CompanyDesc { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
    }
}
