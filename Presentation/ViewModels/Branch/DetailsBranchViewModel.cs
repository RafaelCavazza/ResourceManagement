using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Branch
{
    public class DetailsBranchViewModel
    {
        public Guid Id { get; set; }

        [DisplayAttribute(Name = "Nome")]
        public string Name { get; set; }

        [DisplayAttribute(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [DisplayAttribute(Name = "Criado em")]
        public DateTime CreatedOn { get; set; }

        [DisplayAttribute(Name = "Modificado em")]
        public DateTime ModifiedOn { get; set; }
        public virtual ICollection<Domain.Entities.Employee> Employees { get; set; }
    }
}
