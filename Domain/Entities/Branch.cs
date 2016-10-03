using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Branch
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Cnpj {get; set;}

        public virtual ICollection<Employee> Employees {get; set;}
    }
}
