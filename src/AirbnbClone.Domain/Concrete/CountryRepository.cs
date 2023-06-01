using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class CountryRepository:GenericRepository<Country, DataContext>, ICountryRepository
    {       

         private DataContext context;
        public CountryRepository(DataContext context) : base(context)
        {
            this.context = context;
         }
    
    }
}
