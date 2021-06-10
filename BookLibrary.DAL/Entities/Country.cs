using System.Collections.Generic;

#nullable disable

namespace BookLibrary.DAL.Entities
{
    public partial class Country
    {
        public Country()
        {
            Subscribers = new HashSet<Subscriber>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TotalPopulation { get; set; }

        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
