using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.User
{
    public class ResetPasswordUserViewModel
    {
        [Required]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirme a Senha:")]
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetPasswordToken { get; set; }

        public string CustomErros { get; set; }
    }
}
