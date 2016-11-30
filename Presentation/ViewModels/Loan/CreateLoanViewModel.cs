using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Loan
{
    public class CreateLoanViewModel
    {
        [DisplayAttribute(Name="Funcionário")]
        [Required(ErrorMessage = "O campo Funcionário obrigatório")]
        [DataType(DataType.Text)]
        public Guid EmployeeId {get; set;}

        [DisplayAttribute(Name="Item")]
        [Required(ErrorMessage = "O campo Item obrigatório")]
        [DataType(DataType.Text)]
        public Guid ItemId {get; set;}


        [DisplayAttribute(Name = "Data de Início")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo Data de Início é obrigatório")]
        public DateTime? StartDate { get; set; }

        [DisplayAttribute(Name = "Data de Termino")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo Data de Termino é obrigatório")]
        public DateTime? EndDate { get; set; }

        public IEnumerable<Domain.Entities.Item> Items { get; set; }
        public IEnumerable<Domain.Entities.Employee> Employees {get; set;}
    }
}