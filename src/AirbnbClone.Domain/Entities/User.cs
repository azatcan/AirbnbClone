
namespace Airbnb.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; }
       


        public virtual List<PlaceToRent> PlaceToRents { get; set; }
        public int? İnstitutionalId { get ; set; }
        public virtual İnstitutional İnstitutional { get; set; }
    }
}
