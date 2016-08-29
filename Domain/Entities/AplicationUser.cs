using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AplicationUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Email {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
        public bool Active {get; set;}
    }
}
