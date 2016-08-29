using System;

namespace Domain.Entities
{
    public class Employee
    {
        public Guid Id {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
