using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels.Item
{
    public class CreateItemViewModel
    {
        [DisplayAttribute(Name = "Produto")]
        [Required(ErrorMessage = "O campo Produto é obrigatório")]
        public Guid ProductId { get; set; }

        [DisplayAttribute(Name = "Data de compra")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo Data de compra é obrigatório")]
        public DateTime? PurchasedOn { get; set; }

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

        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
