using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee
    {
        public Guid Id {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}

        public virtual ICollection<User> Users {get; set;}
    }
}
