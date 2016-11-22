using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductViewModel
{
    public Guid Id {get; set;}

    [DisplayAttribute(Name="Nome")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage="O campo Nome é obrigatório")]
    public string Name {get; set;}

    [DisplayAttribute(Name="Descrição")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage="O campo Descrição é obrigatório")]
    public string Description {get; set;}

    [DisplayAttribute(Name="Tempo de Depreciação (Em meses)")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage="O campo Tempo de Depreciação é obrigatório")]
    public int ProductDepreciationTimeInMonths {get; set;}
}