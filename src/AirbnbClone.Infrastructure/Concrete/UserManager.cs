using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class UserManager : UserService
    {
        IUserRepository userRepository;
        public void Add(User p)
        {
            throw new NotImplementedException();
        }

        public void Delete(User p)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }

        public List<User> List(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(User p)
        {
            throw new NotImplementedException();
        }
    }
}
