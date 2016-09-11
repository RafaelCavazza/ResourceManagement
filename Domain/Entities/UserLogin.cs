using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public Guid Id {get; set;}
        public virtual User User {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
    }
}
