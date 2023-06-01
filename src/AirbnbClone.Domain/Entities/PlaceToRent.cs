using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Domain.Entities
{
    public class PlaceToRent
    {
        public PlaceToRent()
        {
            Images = new List<Images>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Furnished { get; set; }
        public bool Wifi { get; set; }
        public bool Seciruty { get; set; }
        public bool Pool { get; set; }
        public bool Garden { get; set; }
        public int NumberOfrooms { get; set; }
        public int BathroomNumbers { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistricttId { get; set; }

        

        [NotMapped]
        public IEnumerable<IFormFile> Image { get; set; } 
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Country Country  { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual User User { get; set; }
        public virtual List<Images> Images { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}
