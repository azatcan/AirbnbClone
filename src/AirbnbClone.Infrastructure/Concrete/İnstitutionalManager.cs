using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class İnstitutionalManager : İnstitutionalService
    {
        IİnstitutionalRepository _institutionalRepository;

        public İnstitutionalManager(IİnstitutionalRepository institutionalRepository)
        {
            _institutionalRepository = institutionalRepository;
        }

        public void Add(İnstitutional p)
        {
            _institutionalRepository.Add(p);
        }

        public void Delete(İnstitutional p)
        {
          _institutionalRepository.Delete(p);
        }

        public İnstitutional GetById(int id)
        {
            return _institutionalRepository.GetById(id);
        }

        public List<İnstitutional> List()
        {
           return _institutionalRepository.List();
        }

        public List<İnstitutional> List(Expression<Func<İnstitutional, bool>> filter)
        {
            return _institutionalRepository.List(filter);
        }

        public void Update(İnstitutional p)
        {
            _institutionalRepository.Update(p);
        }
    }
}
