using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.ViewModels.Employee
{
    public class ImportEmployeeViewModel
    {
        [Required(ErrorMessage="O arquivo para Importação é obrigatório.")]
        [Display(Name="Arquivo Para Importação")]
        [DataType(DataType.Upload)]
        //[FileExtensions(ErrorMessage = "O arquivo deve ser uma extensão '{1}' ",Extensions = "csv,txt")]
        public IFormFile FileToImport {get; set;}
    }
}
