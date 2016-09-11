using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
    }
}
