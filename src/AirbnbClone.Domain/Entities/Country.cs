namespace Airbnb.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
