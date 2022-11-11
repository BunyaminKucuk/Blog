using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommnetManager : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommnetManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void CommentAdd(Comment comment)
        {
            _commentRepository.Insert(comment);
        }

        public List<Comment> GetList(int id)
        {
            return _commentRepository.GetListAll(x => x.BlogId == id);
        }

    }
}
