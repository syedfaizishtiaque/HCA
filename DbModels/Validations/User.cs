using System.ComponentModel.DataAnnotations;

namespace HCA.DbModels
{
    [MetadataType(typeof(User_Validation))]
    public partial class User
    {
        
    }
    public class User_Validation
    {
        [Editable(false)]
        public int UserSk { get; set; }
        [Editable(false)]
        public int? ApplicationSk { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Location")]
        public int? LocationSk { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Department")]
        public int? DepartmentSk { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Designation")]
        public int? DesignationSk { get; set; }
        [Editable(false)]
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "User Full Name")]
        public string UserFullName { get; set; } = null!;
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "User Password")]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Password Expiry")]
        public DateTime PasswordExpiry { get; set; }
        [Editable(false)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [Editable(false)]
        public int CreatedBy { get; set; } = 1;
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
