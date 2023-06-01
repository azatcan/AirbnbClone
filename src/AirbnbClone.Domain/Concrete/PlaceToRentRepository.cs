using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class PlaceToRentRepository : GenericRepository<PlaceToRent, DataContext>, IPlaceToRentRepository
    {
        private DataContext context;
        public PlaceToRentRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
