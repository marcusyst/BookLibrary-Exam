using System;

#nullable disable

namespace BookLibrary.DAL.Entities
{
    public partial class Loan
    {
        public int Id { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BookId { get; set; }
        public int? SubscriberId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}
