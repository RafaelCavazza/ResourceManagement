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
            var upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowerCase = "abcdefghijklmnopqrstuvwxyz";
            var number = "0123456789";
            var specialCaracters = "!@#$%*()_+{}[]?/:;><.,\\|'"; 
            var length = 15;
            var pass1 = new string(Enumerable.Repeat(upperCase, length).Select(s => s[random.Next(s.Length)]).ToArray());
            var pass2 = new string(Enumerable.Repeat(lowerCase, length).Select(s => s[random.Next(s.Length)]).ToArray());
            var pass3 = new string(Enumerable.Repeat(number, length).Select(s => s[random.Next(s.Length)]).ToArray());
            var pass4 = new string(Enumerable.Repeat(specialCaracters, length).Select(s => s[random.Next(s.Length)]).ToArray());
             
            return pass1 + pass2 + pass3 + pass4; 
        }
    }
}
