using System;

namespace Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public DateTime PurchasedOn { get; set; }
        public string NF { get; set; }
        public string SerialNumber { get; set; }
        public string Patrimonio { get; set; }
        public ItemStatus Status { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
