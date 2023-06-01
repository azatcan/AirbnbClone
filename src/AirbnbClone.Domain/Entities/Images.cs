namespace Airbnb.Domain.Entities
{
    public class Images
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int PlaceToRentId { get; set; }
        public virtual PlaceToRent PlaceToRent { get; set; }
    }
}
