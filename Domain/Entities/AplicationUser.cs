using System;

namespace Domain.Entities
{
    public class AplicationUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active {get; set;}

        //Identity Atributes
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Email {get; set;}
    }
}
