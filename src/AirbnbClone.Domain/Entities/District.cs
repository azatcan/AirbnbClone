namespace Airbnb.Domain.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
