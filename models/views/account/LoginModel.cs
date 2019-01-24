using System.ComponentModel.DataAnnotations;

namespace testsite.models.views.account
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username/Email")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool Remember { get; set; }
    }
}