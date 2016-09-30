using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Employee
{
    public class CreateEmployeeViewModel
    {
        [DisplayAttribute(Name="Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Nome é obrigatório")]
        public string Name {get; set;}

        [RegularExpression(@"^([0-9]){3}\.([0-9]){3}\.([0-9]){3}-([0-9]){2}$", ErrorMessage = "O campo CPF deve estar no formato XXX.XXX.XXX-XX")]
        [DisplayAttribute(Name="Cpf")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Cpf é obrigatório")]
        public string Cpf {get; set;}

        [DisplayAttribute(Name="Matrícula")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Matrícula é obrigatório")]
        public string Identifier {get; set;}


        [DisplayAttribute(Name="E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage="O campo E-mail é obrigatório")]
        public string Email {get; set;}

        [DisplayAttribute(Name="Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage="O campo Date de Nascimento é obrigatório")]
        public string DateOfBirth {get; set;}
    }
}
