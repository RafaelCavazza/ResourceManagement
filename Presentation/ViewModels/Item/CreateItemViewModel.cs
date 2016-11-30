using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels.Item
{
    public class CreateItemViewModel
    {
        public CreateItemViewModel()
        {
            this.Itens = new List<ItemInfo>();
        }

        [DisplayAttribute(Name = "Produto")]
        [Required(ErrorMessage = "O campo Produto é obrigatório")]
        public Guid ProductId { get; set; }

        [DisplayAttribute(Name = "Data de compra")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo Data de compra é obrigatório")]
        public DateTime? PurchasedOn { get; set; }

        public IEnumerable<ItemInfo> Itens { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
