using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels.User
{
    public class CreateUserViewModel
    {
        [Display(Name = "Usuáio Vinculado ao Funcionário:")]
        [DataType(DataType.Text)]
        public IEnumerable<SelectListItem> Employee {get; set;}
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage="Não é possível criar um usuário sem vinculo a um Funcionário.")]
        public Guid EmployeeId {get;set;}
    }
}
