using System.Collections.Generic;

#nullable disable

namespace BookLibrary.DAL.Entities
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? NumberOfBooks { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
