using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Loan
{
    public class LoanViewModel
    {
        public Guid Id {get; set;}
        
        [DisplayAttribute(Name="Funcionário")]
        [DataType(DataType.Text)]
        public string Employee {get; set;}

        [DisplayAttribute(Name="Produto")]
        [DataType(DataType.Text)]
        public string Product {get; set;}

        [DisplayAttribute(Name="Patrimonio")]
        [DataType(DataType.Text)]
        public string Patrimonio {get; set;}

        [DisplayAttribute(Name = "Data de Início")]
        public DateTime StartDate { get; set; }

        [DisplayAttribute(Name = "Data de Termino")]
        public DateTime EndDate { get; set; }

        [DisplayAttribute(Name = "Criado em")]
        public DateTime CreatedOn { get; set; }

        [DisplayAttribute(Name = "Modificado em")]
        public DateTime ModifiedOn { get; set; }
    }
}