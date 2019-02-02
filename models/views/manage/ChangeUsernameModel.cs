using System.ComponentModel.DataAnnotations;

namespace testsite.models.views.manage
{
    public class ChangeUsernameModel
    {
        private string _username;
        private string _email;

        [DataType(DataType.Text)]
        [Display(Name = "Current username")]
        public string CurrentUsername { get; set; } 

        [StringLength(100, ErrorMessage = "The username must be at least 100 character long.")]
        [DataType(DataType.Text)]
        [Display(Name = "New username")]
        public string NewUsername 
        {
            get 
            {
                return _username;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    _username = _email;
                } else {
                    _username = value;
                }
            }
        }
    }
}