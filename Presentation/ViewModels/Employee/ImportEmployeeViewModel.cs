using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.ViewModels.Employee
{
    public class ImportEmployeeViewModel
    {
        [DisplayAttribute(Name="Arquivo Para Importação")]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage="O arquivo para Importação é obrigatório.")]
        public IFormFile FiletToImport {get; set;}
    }
}
