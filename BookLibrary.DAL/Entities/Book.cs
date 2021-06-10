using System;
using System.Collections.Generic;

#nullable disable

namespace BookLibrary.DAL.Entities
{
    public partial class Book
    {
        public Book()
        {
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? Date { get; set; }
        public int? StockLevel { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
