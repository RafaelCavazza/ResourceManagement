using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Employee
{
    public class DetailsEmployeeViewModel
    {
        public Guid Id {get; set;}

        [DisplayAttribute(Name="Nome")]
        [DataType(DataType.Text)]
        public string Name {get; set;}

        [DisplayAttribute(Name="Cpf")]
        [DataType(DataType.Text)]
        public string Cpf {get; set;}

        [DisplayAttribute(Name="Matrícula")]
        [DataType(DataType.Text)]
        public string Identifier {get; set;}

        [DisplayAttribute(Name="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;}

        [DisplayAttribute(Name="Data de Admissão")]
        [DataType(DataType.DateTime)]
        public DateTime AdmissionDate {get; set;}

        [DisplayAttribute(Name="Data de Criação")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn {get; set;}

        [DisplayAttribute(Name="Data de Modificação")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn {get; set;}


        [Display(Name = "Filial:")]
        [DataType(DataType.Text)]
        public string Branch {get; set;}

        [Display(Name = "Status:")]
        public bool Active {get; set;}
    }
}
