using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class CountryManager : CountryService
    {
        ICountryRepository  _countryRepository;

        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public void Add(Country p)
        {
            _countryRepository.Add(p);
        }

        public void Delete(Country p)
        {
           _countryRepository.Delete(p);
        }

        public Country GetById(int id)
        {
            return _countryRepository.GetById(id);
        }

        public List<Country> List()
        {
            return _countryRepository.List();
        }

        public List<Country> List(Expression<Func<Country, bool>> filter)
        {
            return _countryRepository.List(filter);
        }

        public void Update(Country p)
        {
            _countryRepository.Update(p);
        }
    }
}
