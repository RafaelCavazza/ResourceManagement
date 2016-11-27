using System;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Presentation.ViewModels.Item
{
    public class EditItemViewModel
    {
        public Guid Id { get; set; }
        public DateTime PurchasedOn { get; set; }
        public ItemStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        [DisplayAttribute(Name = "Nota fiscal")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O campo Nota fiscal é obrigatório")]
        public string NF { get; set; }

        [DisplayAttribute(Name = "Número serial")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O campo Número serial é obrigatório")]
        public string SerialNumber { get; set; }

        [DisplayAttribute(Name = "Patrimônio")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O campo Patrimônio é obrigatório")]
        public string Patrimonio { get; set; }
    }
}
