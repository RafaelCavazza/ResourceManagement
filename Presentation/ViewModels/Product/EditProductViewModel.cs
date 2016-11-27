using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Product
{
    public class EditProductViewModel
    {
        [Required]
        public Guid Id {get; set;}

        [DisplayAttribute(Name="Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Nome é obrigatório")]
        public string Name {get; set;}

        [DisplayAttribute(Name="Descrição")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="O campo Descrição é obrigatório")]
        public string Description {get; set;}

        [Range(1, 1000, ErrorMessage = "O valor do '{0}' deve estar entre {1} e {2}.")]
        [DisplayAttribute(Name="Tempo de Depreciação (Em meses)")]
        [DataType(DataType.Duration)]
        [Required(ErrorMessage="O campo Tempo de Depreciação é obrigatório")]
        public int? ProductDepreciationTimeInMonths {get; set;}
    }
}