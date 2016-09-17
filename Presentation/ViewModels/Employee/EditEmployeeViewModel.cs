using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Employee
{
    public class EditEmployeeViewModel
    {
        public Guid Id {get; set;}

        [DisplayAttribute(Name="Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Nome é obrigatório")]
        public string Name {get; set;}

        [DisplayAttribute(Name="Cpf")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Cpf é obrigatório")]
        public string Cpf {get; set;}

        [DisplayAttribute(Name="Identificador")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Identificador é obrigatório")]
        public string Identifier {get; set;}

        [DisplayAttribute(Name="Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage="O campo Date de Nascimento é obrigatório")]
        public string DateOfBirth {get; set;}
    }
}
