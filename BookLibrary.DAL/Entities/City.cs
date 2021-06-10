using System;
using System.Collections.Generic;

#nullable disable

namespace BookLibrary.DAL.Entities
{
    public partial class City
    {
        public City()
        {
            Subscribers = new HashSet<Subscriber>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
