using Airbnb.Domain.Abstract;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace Airbnb.Infrastructure.Concrete
{
    public class CommentManager : CommentService
    {
        ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }

        public void Add(Comment p)
        {
            _commentRepository.Add(p);
        }

        public void Delete(Comment p)
        {
           _commentRepository.Delete(p);
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public List<Comment> List()
        {
            return _commentRepository.List();
        }

        public List<Comment> List(Expression<Func<Comment, bool>> filter)
        {
           return _commentRepository.List(filter);
        }

        public void Update(Comment p)
        {
            _commentRepository.Update(p);
        }
    }
}
