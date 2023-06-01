using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class CityRepository : GenericRepository<City, DataContext>, ICityRepository
    {      
        private DataContext context;
        public CityRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}

