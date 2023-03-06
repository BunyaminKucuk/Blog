using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        List<Blog> GetListWithCategory();

        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
