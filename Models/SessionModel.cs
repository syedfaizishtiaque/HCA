namespace HCA.Models
{
    public class SessionModel
    {
        public int usr_sk { get; set; }
        public string usr_nme { get; set; } = null!;
        public string usr_full_nme { get; set; } = null!;
        public int app_sk { get; set; }
        public string app_desc { get; set; } = null!;
        public int role_sk { get; set; }
        public string role_desc { get; set; } = null!;
        public int mnu_sk { get; set; }
        public string mnu_desc { get; set; } = null!;
        public string mnu_url { get; set; } = null!;
        public string mnu_icon { get; set; } = null!;
        public int parent_mnu_sk { get; set; }
        public int seq_no { get; set; }
        public bool can_slct { get; set; }
        public bool can_insrt { get; set; }
        public bool can_updt { get; set; }
        public bool can_del { get; set; }
        public int dept_sk { get; set; }
        public string dept_name { get; set; } = null!;
        public int branch_code { get; set; }
        public string bran_name { get; set; } = null!;
        public int dept_type_sk { get; set; }
        public string dept_type_name { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;

    }
}
