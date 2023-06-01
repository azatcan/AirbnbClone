namespace Airbnb.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<District> Districts { get; set; }
    }
}
