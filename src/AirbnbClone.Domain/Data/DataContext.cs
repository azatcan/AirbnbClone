using Airbnb.Domain.Data.Seed;
using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Domain.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedUser();
            base.OnModelCreating(builder);
        }


        public DbSet<PlaceToRent> PlaceToRents { get; set; }
        public DbSet<İnstitutional> İnstitutionals { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
