using System.ComponentModel.DataAnnotations;

namespace testsite.models.views.account
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "The password must be at least 80 character long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get 
            {
                return Password;
            }
            set
            {
                if (value.IndexOf(" ") == -1) {
                    Password = value;
                }
            }
        }

        [StringLength(100, ErrorMessage = "The username must be at least 100 character long.")]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username
        {
            get 
            {
                return Username;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    Username = Email;
                } else {
                    Username = value;
                }
            }
        }
    }
}