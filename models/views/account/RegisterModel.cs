using System.ComponentModel.DataAnnotations;

namespace testsite.models.views.account
{
    public class RegisterModel
    {
        private string _username;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [RegularExpression(@"^[^-\s]*$")]
        [Required]
        [StringLength(80, MinimumLength = 6, 
        ErrorMessage = "The password must be between 6 and 80 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [StringLength(100, ErrorMessage = "The username must be at least 100 character long.")]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username 
        {
            get 
            {
                return _username;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    _username = Email;
                } else {
                    _username = value;
                }
            }
        }
    }
}