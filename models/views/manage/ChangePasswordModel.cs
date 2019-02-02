using System.ComponentModel.DataAnnotations;

namespace testsite.models.views.manage
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string CurrentPassword { get; set; }

        [RegularExpression(@"^[^-\s]*$")]
        [Required]
        [StringLength(80, MinimumLength = 6, 
        ErrorMessage = "The password must be between 6 and 80 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
    }
}