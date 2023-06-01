using System.ComponentModel.DataAnnotations;

namespace Airbnb.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Yorum")]
        public string Content { get; set; }
        [Display(Name = "Makale")]
        public int PlaceToRentId { get; set; }
        public virtual PlaceToRent PlaceToRent { get; set; }
        [Display(Name = "Kişi")]
        //public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime Date { get; set; }
    }
}
