using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.ViewModels.Employee
{
    public class ImportEmployeeViewModel
    {
        [Required(ErrorMessage="O arquivo para Importação é obrigatório.")]
        [Display(Name="Arquivo Para Importação")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "csv")]
        public IFormFile FileToImport {get; set;}
    }
}
