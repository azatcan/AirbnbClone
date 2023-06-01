namespace Airbnb.Domain.Entities
{
    public class İnstitutional
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Capasity { get; set; }
        public string NumberOfrooms { get; set; }
        public User User { get; set; }

    }
}
