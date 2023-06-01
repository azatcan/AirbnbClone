namespace Airbnb.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual List<PlaceToRent> PlaceToRent { get; set; }

    }
}
