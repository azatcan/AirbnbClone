using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class DistrictManager : DistrictService
    {
        IDistrictRepository  _districtRepository;

        public DistrictManager(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public void Add(District p)
        {
            _districtRepository.Add(p);
        }

        public void Delete(District p)
        {
            _districtRepository.Delete(p);
        }

        public District GetById(int id)
        {
            return _districtRepository.GetById(id);
        }

        public List<District> List()
        {
            return _districtRepository.List();
        }

        public List<District> List(Expression<Func<District, bool>> filter)
        {
           return _districtRepository.List(filter);
        }

        public void Update(District p)
        {
           _districtRepository.Update(p);
        }
    }
}
