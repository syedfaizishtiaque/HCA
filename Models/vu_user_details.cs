namespace HCA.Models
{
    public class vu_user_details
    {
        public int application_sk { get; set; }
        public int department_sk { get; set; }
        public int designation_sk { get; set; }
        public int location_sk { get; set; }
        public string user_name { get; set; } = null!;
        public string user_full_name { get; set; } = null!;
        public string password { get; set; } = null!;
        public DateTime password_expiry { get; set; }
        public string application_name { get; set; } =null!;
        public string application_desc { get; set; } =null!;
        public string department_name { get; set; }  =null!;
        public string department_desc { get; set; }  =null!;
        public string designation_name { get; set; } =null!;
        public string designation_desc { get; set; } =null!;
        public string location_name { get; set; }    =null!;
        public string location_desc { get; set; } = null!;
    }
}
