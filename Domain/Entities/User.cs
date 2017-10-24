using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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
            var numbers = "0123456789";
            var specialCaracters = "!@#$%*()_+{}[]?/:;><.,\\|'";

            return Shuffle(letters + numbers + specialCaracters);
        }

        private static string Shuffle(string str)
        {
            var array = str.ToCharArray();
            var rng = new Random();
            var n = array.Length;

            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
    }
}
