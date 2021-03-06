using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Cpf {get; set;}
        public string Identifier {get; set;}
        public DateTime AdmissionDate {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
        public String Email {get; set;}
        public bool Active {get; set;}

        public Guid BranchId {get; set;}
        public Branch Branch {get; set;}

        public virtual ICollection<User> Users {get; set;}
        public virtual ICollection<Loan> Loans {get; set;}
    }
}
