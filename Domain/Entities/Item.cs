using System;

namespace Domain.Entities
{
    public class Item
    {
        public Guid Id {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
        public Guid ProductId {get; set;}
        public virtual Product Product {get; set;}
    }
}
