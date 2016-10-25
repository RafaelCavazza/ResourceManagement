using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.User
{
    public class ResetPasswordUserViewModel
    {
        [Required]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [DataType(DataType.Text)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirme a Senha:")]
        [DataType(DataType.Text)]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
