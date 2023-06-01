using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class DistrictRepository : GenericRepository<District, DataContext>, IDistrictRepository
    {

        private DataContext context;
        public DistrictRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
