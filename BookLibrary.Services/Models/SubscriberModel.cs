namespace BookLibrary.Services.Models
{
    public class SubscriberModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? NumberOfBooks { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
    }
}
