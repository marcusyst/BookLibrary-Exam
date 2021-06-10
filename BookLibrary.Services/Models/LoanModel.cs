using System;

namespace BookLibrary.Services.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BookId { get; set; }
        public int? SubscriberId { get; set; }
    }
}
