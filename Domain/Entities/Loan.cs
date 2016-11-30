using System;

namespace Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }
        public Guid EmployeeId { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool HasFinished {get; set;}

        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
