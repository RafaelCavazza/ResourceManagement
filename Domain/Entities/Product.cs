using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id {get; set;}
        public string Description {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime ModifiedOn {get; set;}
        public int ProductDepreciationTimeInMonths {get; set;}
        public virtual ICollection<Item> Items {get;set;}
    }
}
