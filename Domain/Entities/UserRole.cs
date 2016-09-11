using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public Guid Id {get; set;}
        public virtual User User {get; set;}
        public virtual Role Role {get; set;}         
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
    }
}

