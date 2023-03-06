using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        //void CommentUpdate(Comment comment);
        //void CommentDelete(Comment comment);
        List<Comment> GetBlogById(int id);

    }
}
