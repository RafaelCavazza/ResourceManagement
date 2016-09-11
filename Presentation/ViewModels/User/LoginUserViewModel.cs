using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.User
{
    public class LoginUserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool RememberMe {get;set;}
    }
}
