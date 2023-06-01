using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class PlaceToRentManager : PlaceToRentService
    {
        IPlaceToRentRepository _placeToRentRepository;

        public PlaceToRentManager(IPlaceToRentRepository placeToRentRepository)
        {
            this._placeToRentRepository = placeToRentRepository;
        }

        public void Add(PlaceToRent p)
        {
            _placeToRentRepository.Add(p);
        }

        public void Delete(PlaceToRent p)
        {
            _placeToRentRepository.Delete(p);
        }

        public PlaceToRent GetById(int id)
        {
            return _placeToRentRepository.GetById(id);
        }

        public List<PlaceToRent> List()
        {
            return _placeToRentRepository.List();
        }

        public List<PlaceToRent> List(Expression<Func<PlaceToRent, bool>> filter)
        {
            return _placeToRentRepository.List(filter);
        }

        public void Update(PlaceToRent p)
        {
            _placeToRentRepository.Update(p);
        }
    }
}
