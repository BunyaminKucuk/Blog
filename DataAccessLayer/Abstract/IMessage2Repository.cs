using System.Collections.Generic;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Repository : IGenericRepository<Message2>
    {
        List<Message2> GetListWithMessageByWriter(int id);
    }
}
