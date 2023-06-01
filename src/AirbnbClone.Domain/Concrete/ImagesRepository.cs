using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class ImagesRepository : GenericRepository<Images, DataContext>, IImagesRepository
    {

        private DataContext context;
        public ImagesRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
