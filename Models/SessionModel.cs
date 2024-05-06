namespace HCA.Models
{
    public class SessionModel
    {
        public vu_user_details user { get; set; } = null!;
        public List<vu_menu_details> menus { get; set; } = null!;
           

    }
}
