using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class CategoryManager : CategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category p)
        {
            _categoryRepository.Add(p);
        }

        public void Delete(Category p)
        {
            _categoryRepository.Delete(p);
        }

        public Category GetById(int id)
        {
           return _categoryRepository.GetById(id);
        }

        public List<Category> List()
        {
            return _categoryRepository.List();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
           return _categoryRepository.List(filter);
        }

        public void Update(Category p)
        {
            _categoryRepository.Update(p);
        }
    }
}
