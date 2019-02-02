using System.ComponentModel.DataAnnotations;

namespace testsite.models.views.manage
{
    public class AccountModel
    {
        private string _username;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
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