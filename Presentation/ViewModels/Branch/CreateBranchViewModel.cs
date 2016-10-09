using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Branch
{
    public class CreateBranchViewModel
    {
        [DisplayAttribute(Name = "Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }

        [RegularExpression(@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)", ErrorMessage = "O campo CNPJ deve estar no formato XX.XXX.XXX/XXXX-XX")]
        [DisplayAttribute(Name = "CNPJ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O campo CNPJ é obrigatório")]
        public string Cnpj { get; set; }
    }
}
