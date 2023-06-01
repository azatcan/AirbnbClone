using Airbnb.Domain.Abstract;
using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Concrete
{
    public class CommentRepository : GenericRepository<Comment, DataContext>, ICommentRepository
    {

        private DataContext context;
        public CommentRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
