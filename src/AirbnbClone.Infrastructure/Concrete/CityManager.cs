using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class CityManager : CityService
    {
        ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Add(City p)
        {
            _cityRepository.Add(p);
        }

        public void Delete(City p)
        {
            _cityRepository.Delete(p);
        }

        public City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public List<City> List()
        {
           return _cityRepository.List();
        }

        public List<City> List(Expression<Func<City, bool>> filter)
        {
            return _cityRepository.List(filter);
        }

        public void Update(City p)
        {
            _cityRepository.Update(p);
        }
    }
}
