using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class UserRepository : GenericRepository<User, DataContext>, IUserRepository
    {
        private DataContext context;
        public UserRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
