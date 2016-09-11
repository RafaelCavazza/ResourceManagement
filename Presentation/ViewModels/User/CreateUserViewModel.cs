using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.User
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirme o E-mail")]
        [DataType(DataType.EmailAddress)]
        public string EmailConfirm { get; set; }
        
        [Required]
        [Display(Name = "Telefone Celular")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Nome do Usuário")]
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Display(Name = "Senha")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Funcionário Vinculado ao Usuáio: ID")]
        public ICollection<Employee> Employee {get; set;}

        
        [DataType(DataType.Text)]
        [Required]
        public Guid EmployeeId {get;set;}
    }
}
