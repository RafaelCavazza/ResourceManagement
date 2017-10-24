using Domain.Entities;
using System.Linq;
using Xunit;

namespace Test.Domain
{
    public class UserTest
    {
        [Fact]
        public void PasswordTest()
        {
            var password = User.GenerateRandomPassword();

            Assert.False(string.IsNullOrWhiteSpace(password));
            Assert.True(ContaisLettersNumbersAndSpecialCaracters(password));
        }

        private bool ContaisLettersNumbersAndSpecialCaracters(string password)
        {
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var numbers = "0123456789";
            var specialCaracters = "!@#$%*()_+{}[]?/:;><.,\\|'";
            var characters = letters + numbers + specialCaracters;

            return characters.All(c => password.Contains(c));
        }
    }
}
