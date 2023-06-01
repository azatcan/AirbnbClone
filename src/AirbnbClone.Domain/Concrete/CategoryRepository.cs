using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class CategoryRepository: GenericRepository<Category, DataContext>, ICategoryRepository
    {

        private DataContext context;
        public CategoryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
