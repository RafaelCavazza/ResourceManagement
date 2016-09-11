using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
        public bool Active {get; set;}

        public Guid EmployeeId {get;set;}
        public virtual Employee Employee {get;set;}
    }
}
