using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class İnstitutionalRepesitory : GenericRepository<İnstitutional, DataContext>, IİnstitutionalRepository
    {

        private DataContext context;
        public İnstitutionalRepesitory(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
