using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommnetManager : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommnetManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<Comment> GetList()
        {
            return _commentRepository.GetListAll();
        }

        public void TAdd(Comment t)
        {
            _commentRepository.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentRepository.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _commentRepository.GetById(id);
        }

        public void TUpdate(Comment t)
        {
            _commentRepository.Update(t);
        }

        public List<Comment> GetBlogById(int id)
        {
            return _commentRepository.GetListAllByFilter(x => x.BlogId == id);
        }

    }
}
