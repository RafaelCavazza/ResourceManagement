using System;
using System.Linq;
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

        public static string GenerateRandomPassword()
        {
            var random = new Random();
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var numbersAndSpecialCaracters = "0123456789!@#$%*()_+{}[]?/:;><.,\\|'";
            var passwordCharacters = letters + numbersAndSpecialCaracters;
            return new string(Enumerable.Repeat(passwordCharacters, 250).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
