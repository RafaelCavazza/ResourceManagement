using System;

namespace Domain.Entities
{
    public class Item
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
    }
}
