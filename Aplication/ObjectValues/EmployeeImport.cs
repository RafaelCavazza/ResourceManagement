using System;

namespace Aplication.ObjectValues
{
    public class EmployeeImport
    {
        public Guid BranchId {get; set;}
        public string EmployeeIdentifier {get; set;}
        public string Name {get; set;}
        public string Cpf {get; set;}
        public DateTime AdimissionDate {get; set;}
        public string Email {get; set;}
        public string StatusMessage {get; set;}
        public bool Status {get; set;}
    }
}