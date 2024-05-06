namespace HCA.Models
{
    public class vu_menu_details
    {
        public int user_sk { get; set; }
        public int menu_sk { get; set; }
        public string menu_title { get; set; } = null!;
        public string? menu_url { get; set; }
        public string menu_icon { get; set; } = null!;
        public int parent_sk { get; set; }
        public int child_seq { get; set; }
        public int parent_seq { get; set; }
        public bool can_create { get; set; }
        public bool can_delete { get; set; }
        public bool can_edit { get; set; }
        public bool can_view { get; set; }
    }
}
