using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class ImagesManager : ImagesService
    {
        IImagesRepository _ımagesRepository;

        public ImagesManager(IImagesRepository ımagesRepository)
        {
            _ımagesRepository = ımagesRepository;
        }

        public void Add(Images p)
        {
            _ımagesRepository.Add(p);
        }

        public void Delete(Images p)
        {
            _ımagesRepository.Delete(p);
        }

        public Images GetById(int id)
        {
           return _ımagesRepository.GetById(id);
        }

        public List<Images> List()
        {
           return _ımagesRepository.List();
        }

        public List<Images> List(Expression<Func<Images, bool>> filter)
        {
            return _ımagesRepository.List(filter);
        }

        public void Update(Images p)
        {
           _ımagesRepository.Update(p);
        }
    }
}
